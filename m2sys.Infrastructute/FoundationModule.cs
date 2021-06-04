using Autofac;
using m2sys.Infrastructute.Contexts;
using m2sys.Infrastructute.Repositories;
using m2sys.Infrastructute.Repositories.Interface;
using m2sys.Infrastructute.Services;
using m2sys.Infrastructute.Services.Interface;
using m2sys.Infrastructute.UnitOfWorks;
using m2sys.Infrastructute.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace m2sys.Infrastructute
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            

            builder.RegisterType<ApiContext>()
              .WithParameter("connectionString", _connectionString)
              .WithParameter("migrationAssemblyName", _migrationAssemblyName)
              .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies); ;
            builder.RegisterType<LeaveRepository>().As<ILeaveRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies); ;

            //Registering UnitOfWorks
            builder.RegisterType<ApiUnitOfWork>().As<IApiUnitOfWork>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies); ;

            //Registering services
            builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            .InstancePerLifetimeScope()
            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<LeaveService>().As<ILeaveService>()
           .InstancePerLifetimeScope()
           .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            base.Load(builder);
        }
    }
}
