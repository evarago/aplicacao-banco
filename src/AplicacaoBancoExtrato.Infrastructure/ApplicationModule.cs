namespace AplicacaoBancoExtrato.Infrastructure {
    using Autofac;
    using AplicacaoBancoExtrato.Application;

    public class ApplicationModule : Module {
        protected override void Load (ContainerBuilder builder) {
            //
            // Register all Types in AplicacaoBancoExtrato.Application
            builder.RegisterAssemblyTypes (typeof (ApplicationException).Assembly)
                .AsImplementedInterfaces ()
                .InstancePerLifetimeScope ();
        }
    }
}