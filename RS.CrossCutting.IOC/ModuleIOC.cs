using Autofac;
using RS.CrossCutting.IOC;
using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Infra.CrossCutting.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Carrega IOC

            ConfigurationIOC.Load(builder);

            #endregion
        }
    }
}
