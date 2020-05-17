using Autofac;
using ReceitaSearch.Domain.Core.Interfaces.Repositorys;
using ReceitaSearch.Domain.Core.Interfaces.Services;
using ReceitaSearch.Infra.CrossCutting;
using RS.Aplication.Interfaces;
using RS.Aplication.Service;
using RS.Domain.Services.Services;
using RS.Infra.CrossCutting.Adapter.Interfaces;
using RS.Infra.CrossCutting.Adapter.Map;
using RS.Infra.Repository.Repositorys;
using System;

namespace RS.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceEntidade>().As<IApplicationServiceEntidade>();
            builder.RegisterType<ApplicationServiceEndereco>().As<IApplicationServiceEndereco>();
            builder.RegisterType<ApplicationServiceAtividade>().As<IApplicationServiceAtividade>();
            builder.RegisterType<ApplicationServiceQSA>().As<IApplicationServiceQSA>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceEntidade>().As<IServiceEntidade>();
            builder.RegisterType<ServiceAtividade>().As<IServiceAtividade>();
            builder.RegisterType<ServiceEndereco>().As<IServiceEndereco>();
            builder.RegisterType<ServiceQSA>().As<IServiceQSA>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryEntidade>().As<IRepositoryEntidade>();
            builder.RegisterType<RepositoryAtividade>().As<IRepositoryAtividade>();
            builder.RegisterType<RepositoryEndereco>().As<IRepositoryEndereco>();
            builder.RegisterType<RepositoryQSA>().As<IRepositoryQSA>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperEntidade>().As<IMapperEntidade>();
            builder.RegisterType<MapperAtividade>().As<IMapperAtividade>();
            builder.RegisterType<MapperEndereco>().As<IMapperEndereco>();
            builder.RegisterType<MapperQSA>().As<IMapperQSA>();
            #endregion

            #endregion

        }
    }
}
