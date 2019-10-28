namespace AplicacaoBancoExtrato.WebApi {
    using Autofac;

    public class WebApiModule : Autofac.Module {
        protected override void Load (ContainerBuilder builder) {
            //
            // Register all Types in AplicacaoBancoExtrato.WebApi
            builder.RegisterAssemblyTypes (typeof (Startup).Assembly)
                .AsSelf ()
                .InstancePerLifetimeScope ();
        }
    }
}