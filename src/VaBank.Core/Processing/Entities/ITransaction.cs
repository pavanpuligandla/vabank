﻿using System;
using VaBank.Core.Accounting.Entities;

namespace VaBank.Core.Processing.Entities
{
    public interface ITransaction
    {
        string AccountNo { get; }
        Currency Currency { get; }
        decimal TransactionAmount { get; }
        decimal AccountAmount { get; }
        decimal RemainingBalance { get; }
        DateTime CreatedDateUtc { get; }
        DateTime? PostDateUtc { get; }
        string Description { get; }
        string Location { get; }
        string ErrorMessage { get; }
        ProcessStatus Status { get; }
        Guid Id { get; }
    }
}