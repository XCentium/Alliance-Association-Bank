using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Services;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Queries;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using AllianceAssociationBank.Crm.Identity;
using Microsoft.Owin.Security;
using System.Web;
using System.DirectoryServices.AccountManagement;

namespace AllianceAssociationBank.Crm
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, CrmApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IProjectRepository, ProjectRepository>(new TransientLifetimeManager());
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(new TransientLifetimeManager());
            container.RegisterType<ISoftwareRepository, SoftwareRepository>(new TransientLifetimeManager());
            container.RegisterType<IProjectUserRepository, ProjectUserRepository>(new TransientLifetimeManager());
            container.RegisterType<ICheckScannerRepository, CheckScannerRepository>(new TransientLifetimeManager());
            container.RegisterType<INoteRepository, NoteRepository>(new TransientLifetimeManager());

            container.RegisterType<IReportQueries, ReportQueries>(new TransientLifetimeManager());
            container.RegisterType<IReportGenerationService, ReportGenerationService>(new TransientLifetimeManager());
            container.RegisterType<IDataExportService, DataExportService>(new TransientLifetimeManager());

            container.RegisterType<IAuthenticationManager>
            (
                new TransientLifetimeManager(),
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication)
            );
            container.RegisterType<PrincipalContext>
            (
                new HierarchicalLifetimeManager(),
                new InjectionFactory(c => new PrincipalContext(ContextType.Machine)) // TODO: this will change in production (ContextType.Domain)
            );
            container.RegisterType<IAuthenticationService, ADAuthenticationService>(new TransientLifetimeManager());

            container.RegisterInstance<IMapper>(CrmAutoMapperProfile.GetMapper());
            //container.RegisterType<UserController>(new InjectionConstructor());
        }
    }
}