﻿using System;
using VaBank.Common.Data;
using VaBank.Common.Data.Repositories;
using VaBank.Core.Accounting.Entities;
using VaBank.Core.Processing.Entities;
using VaBank.Services.Common;
using VaBank.Services.Common.Exceptions;
using VaBank.Services.Contracts.Common;
using VaBank.Services.Contracts.Processing;
using VaBank.Services.Contracts.Processing.Commands;
using VaBank.Services.Contracts.Processing.Events;
using VaBank.Services.Contracts.Processing.Models;

namespace VaBank.Services.Processing
{
    public class CardTransferClientService : BaseService, ICardTransferClientService
    {
        private readonly CardTransferClientServiceDependencies _deps;

        public CardTransferClientService(BaseServiceDependencies baseDeps, CardTransferClientServiceDependencies serviceDeps)
            : base(baseDeps)
        {
            serviceDeps.EnsureIsResolved();
            _deps = serviceDeps;
        }

        public BankOperationModel Transfer(PersonalCardTransferCommand command)
        {
            EnsureIsValid(command);            
            try
            {
                var fromCard = _deps.UserCards.SurelyFind(command.FromCardId);
                var toCard = _deps.UserCards.SurelyFind(command.ToCardId);
                var transfer = _deps.CardTransferFactory.Create(fromCard, toCard, command.Amount);
                
                _deps.CardTransfers.Create(transfer);                
                Commit();
                
                var model = transfer.ToModel<BankOperation, BankOperationModel>();
                PublishTransferEvent(model);

                return model;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Can't create transfer.", ex);
            }
        }

        public BankOperationModel Transfer(InterbankCardTransferCommand command)
        {
            EnsureIsValid(command);            
            try
            {
                var fromCard = _deps.UserCards.SurelyFind(command.FromCardId);                
                var toCard = _deps.UserCards.QueryOne(DbQuery.For<UserCard>().FilterBy(x => x.CardNo == command.ToCardNo));
                if (toCard == null)
                    throw NotFound.ExceptionFor<UserCard>();
                var transfer = _deps.CardTransferFactory.Create(fromCard, toCard, command.Amount);

                _deps.CardTransfers.Create(transfer);
                Commit();

                var model = transfer.ToModel<BankOperation, BankOperationModel>();
                PublishTransferEvent(model);

                return model;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Can't create transfer.", ex);
            }
        }

        protected void PublishTransferEvent(BankOperationModel model)
        {
            Publish(new OperationStartedEvent(Operation.Id, model));
        }
    }
}
