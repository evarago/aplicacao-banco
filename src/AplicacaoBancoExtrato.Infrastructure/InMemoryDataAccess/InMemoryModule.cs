namespace AplicacaoBancoExtrato.Infrastructure.InMemoryDataAccess {
    using Autofac;

    public class InMemoryModule : Autofac.Module {
        protected override void Load (ContainerBuilder builder) {
            builder.RegisterType<AplicacaoBancoExtratoContext> ()
                .As<AplicacaoBancoExtratoContext> ()
                .SingleInstance ();

            builder.RegisterAssemblyTypes (typeof (InfrastructureException).Assembly)
                .Where (type => type.Namespace.Contains ("InMemoryDataAccess"))
                .AsImplementedInterfaces ()
                .InstancePerLifetimeScope ();
        }
    }
}