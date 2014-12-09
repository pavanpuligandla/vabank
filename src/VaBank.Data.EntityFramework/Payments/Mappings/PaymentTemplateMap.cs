﻿using System.Data.Entity.ModelConfiguration;
using VaBank.Core.Payments.Entities;

namespace VaBank.Data.EntityFramework.Payments.Mappings
{
    public class PaymentTemplateMap : EntityTypeConfiguration<PaymentTemplate>
    {
        public PaymentTemplateMap()
        {
            ToTable("PaymentTemplate", "Payments").HasKey(x => x.Code);
            Property(x => x.Form).IsRequired().IsMaxLength();

            HasRequired(x => x.Category).WithRequiredPrincipal();
        }
    }
}