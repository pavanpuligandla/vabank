﻿using System;
using Autofac;
using FluentValidation;
using VaBank.Services.Common;
using VaBank.Services.Contracts.Common.Validation;

namespace VaBank.UI.Web.Api.Infrastructure.IoC
{
    public class AutofacFactory : IObjectFactory, IValidatorFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacFactory(ILifetimeScope lifetimeScope)
        {
            if (lifetimeScope == null)
                throw new ArgumentNullException("lifetimeScope", "Lifetime Scope can't be null");
            _lifetimeScope = lifetimeScope;
        }

        public IValidator<T> GetValidator<T>()
        {
            return _lifetimeScope.IsRegistered<IValidator<T>>() 
                ? _lifetimeScope.Resolve<IValidator<T>>() 
                : new AlwaysTrueValidator<T>();
        }

        public IValidator GetValidator(Type validatedType)
        {
            var type = typeof (IValidator<>).MakeGenericType(validatedType);
            return _lifetimeScope.IsRegistered(type)
                ? (IValidator) _lifetimeScope.Resolve(type)
                : null;
        }

        public object Create(Type objectType)
        {
            return _lifetimeScope.Resolve(objectType);
        }
    }
}