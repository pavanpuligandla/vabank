﻿using VaBank.Common.Validation;
using VaBank.Core.Accounting.Entities;
using VaBank.Core.Processing.Entities;

namespace VaBank.Core.Processing
{
    public static class ProcessingExtensions
    {
        public static CardTransaction Withdraw(
            this Account account,
            Card card,
            string code,
            string description,
            string location,
            Money money, 
            MoneyConverter moneyConverter)
        {
            Argument.NotNull(account, "account");
            Argument.NotNull(card, "card");
            Argument.NotEmpty(code, "code");
            Argument.NotEmpty(description, "description");
            Argument.NotNull(money, "money");
            Argument.NotNull(moneyConverter, "moneyConverter");
            Argument.Satisfies(money, x => x.Amount > 0, "money", "Money amount should be greater than 0.");

            var convertedMoney = moneyConverter.Convert(money, account.Currency.ISOName);
            return new CardTransaction(code, description, location, account, card, money.Currency, - money.Amount, - convertedMoney.Amount);
        }

        public static CardTransaction Deposit(
            this Account account,
            Card card,
            string code,
            string description,
            string location,
            Money money, 
            MoneyConverter moneyConverter)
        {
            Argument.NotNull(account, "account");
            Argument.NotNull(card, "card");
            Argument.NotEmpty(code, "code");
            Argument.NotEmpty(description, "description");
            Argument.NotNull(money, "money");
            Argument.NotNull(moneyConverter, "moneyConverter");
            Argument.Satisfies(money, x => x.Amount > 0, "money", "Money amount should be greater than 0.");

            var convertedMoney = moneyConverter.Convert(money, account.Currency.ISOName);
            return new CardTransaction(code, description, location, account, card, money.Currency, money.Amount, convertedMoney.Amount);
        }

        public static Transaction Deposit(this Account account,
            string code,
            string description,
            string location,
            Money money,
            MoneyConverter moneyConverter)
        {
            Argument.NotEmpty(code, "code");
            Argument.NotEmpty(description, "description");
            Argument.NotNull(account, "account");
            Argument.NotNull(money, "money");
            Argument.NotNull(moneyConverter, "moneyConverter");
            Argument.Satisfies(money, x => x.Amount > 0, "money", "Money amount should be greater than 0.");

            var convertedMoney = moneyConverter.Convert(money, account.Currency.ISOName);
            return new Transaction(account, money.Currency, money.Amount, convertedMoney.Amount, code, description, location);
        }

        public static Transaction Withdraw(this Account account,
            string code,
            string description,
            string location,
            Money money,
            MoneyConverter moneyConverter)
        {
            Argument.NotEmpty(code, "code");
            Argument.NotEmpty(description, "description");
            Argument.NotNull(account, "account");
            Argument.NotNull(money, "money");
            Argument.NotNull(moneyConverter, "moneyConverter");
            Argument.Satisfies(money, x => x.Amount > 0, "money", "Money amount should be greater than 0.");

            var convertedMoney = moneyConverter.Convert(money, account.Currency.ISOName);
            return new Transaction(account, money.Currency, - money.Amount, - convertedMoney.Amount, code, description, location);
        }
    }
}
