﻿using System;

namespace XxIoC
{
    internal class ObjectFactory : IObjectFactory
    {
        public IServicesProvider ServicesProvider { get; set; }
        public IAbstractTypeMapping TypeMapping { get; set; }

        public object Create(Type type, params object[] parameters)
        {
            Type implType = null;
            if (true != TypeMapping?.FindMapping(type, out implType)) implType = type;
            return DynamicActivator.Create(implType, ServicesProvider, parameters);
        }

        public TObject Create<TObject>(params object[] parameters) => (TObject)Create(typeof(TObject), parameters);
    }
}
