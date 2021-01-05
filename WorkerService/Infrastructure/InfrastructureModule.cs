using Autofac;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.UnitOfWorks;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkerContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            //Registering repositories
            builder.RegisterType<LoggingRepository>().As<ILoggingRepository>()
                .SingleInstance();

            //Registering UnitOfWorks
            builder.RegisterType<WorkerUnitOfWork>().As<IWorkerUnitOfWork>()
                .SingleInstance();

            //Registering services
            builder.RegisterType<LoggingService>().As<ILoggingService>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
