﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaBank.Common.Data.Repositories;
using VaBank.Common.IoC;
using VaBank.Common.Validation;
using VaBank.Core.Accounting.Entities;
using VaBank.Core.Payments.Entities;
using VaBank.Core.Processing;
using VaBank.Core.Processing.Entities;
using VaBank.Services.Contracts.Common.Events;

namespace VaBank.Services.Processing.Operations
{
    [Injectable]
    internal class CardPaymentProcessor : TransferProcessor
    {
        private const int DelaySecons = 15;

        private readonly IRepository<PaymentTransactionLink> _paymentTransactionLinkRepository;

        public CardPaymentProcessor(BaseOperationProcessorDependencies baseDependencies, 
            IRepository<Transfer> transferRepository,
            IRepository<PaymentTransactionLink> paymentTransactionLinkRepository)
            : base(baseDependencies, transferRepository)
        {
            Argument.NotNull(paymentTransactionLinkRepository, "paymentTransactionLinkRepository");
            _paymentTransactionLinkRepository = paymentTransactionLinkRepository;
        }

        public override bool CanProcess(BankOperation operation)
        {
            return operation.Category.Code.StartsWith("PAYMENT") && operation is CardPayment;
        }

        protected override DateTime? PostponeDateOrNull(BankOperation operation)
        {
            return null;
        }

        protected override Transaction Deposit(Account account, Transfer transfer, string code, string description)
        {
            var payment = (CardPayment) transfer;
            var depositTransaction = account.Deposit(code, description, Settings.Location, new Money(transfer.Currency, transfer.Amount), MoneyConverter);
            var paymentLink = new PaymentTransactionLink(depositTransaction, payment.Order);
            _paymentTransactionLinkRepository.Create(paymentLink);
            return depositTransaction;
        }

        protected override Transaction Compensate(Account account, Transfer transfer, string code, string description)
        {
            var payment = (CardPayment) transfer;
            var compensatingTransaction = account.Deposit(payment.Card, code, description, Settings.Location,
                new Money(transfer.Currency, transfer.Amount), MoneyConverter);
            var paymentLink = new PaymentTransactionLink(compensatingTransaction, payment.Order);
            _paymentTransactionLinkRepository.Create(paymentLink);
            return compensatingTransaction;
        }

        protected override IEnumerable<ApplicationEvent> WhenWithdrawalPending(Guid appOperationId, Transfer transfer)
        {
            Task.Delay(TimeSpan.FromSeconds(DelaySecons)).Wait();
            return base.WhenWithdrawalPending(appOperationId, transfer);
        }

        protected override IEnumerable<ApplicationEvent> WhenWithdrawalCompleted(Guid appOperationId, Transfer transfer)
        {
            Task.Delay(TimeSpan.FromSeconds(DelaySecons)).Wait();
            return base.WhenWithdrawalCompleted(appOperationId, transfer);
        }
    }
}
