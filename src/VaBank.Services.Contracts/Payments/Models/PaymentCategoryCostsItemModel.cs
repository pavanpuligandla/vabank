﻿namespace VaBank.Services.Contracts.Payments.Models
{
    public class PaymentCategoryCostsItemModel
    {
        public PaymentCategoryModel Category { get; set; }

        public decimal Spent { get; set; }
    }
}
