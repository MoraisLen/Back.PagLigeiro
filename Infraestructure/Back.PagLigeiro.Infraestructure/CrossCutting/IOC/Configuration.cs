using Autofac;
using Back.PagLigeiro.Application;
using Back.PagLigeiro.Application.Interfaces;
using Back.PagLigeiro.Domain.Core.Interfaces.Repository;
using Back.PagLigeiro.Domain.Core.Interfaces.Services;
using Back.PagLigeiro.Domain.Services;
using Back.PagLigeiro.Infraestructure.Data.Repository;

namespace Back.PagLigeiro.Infraestructure.CrossCutting.IOC
{
    public class Configuration
    {
        public static void Load(ContainerBuilder builder)
        {
            #region SERVICES
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ClienteService>().As<IClienteService>();
            builder.RegisterType<ServicoService>().As<IServicoService>();
            builder.RegisterType<BoletoService>().As<IBoletoService>();
            #endregion

            #region REPOSITORY
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            builder.RegisterType<ServicoRepository>().As<IServicoRepository>();
            builder.RegisterType<BoletoRepository>().As<IBoletoRepository>();
            #endregion

            #region APPLICATION
            builder.RegisterType<UserApplicationService>().As<IUserApplicationService>();
            #endregion

        }
    }
}
