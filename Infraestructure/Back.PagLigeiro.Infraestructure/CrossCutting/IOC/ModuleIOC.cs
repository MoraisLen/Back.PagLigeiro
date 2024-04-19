using Autofac;

namespace Back.PagLigeiro.Infraestructure.CrossCutting.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Configuration.Load(builder);
        }
    }
}
