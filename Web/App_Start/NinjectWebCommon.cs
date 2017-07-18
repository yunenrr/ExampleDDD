[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ExampleDDD.Application.Main.Interfaces;
    using ExampleDDD.Application.Main.Services;
    using ExampleDDD.Domain.Interfaces.Services;
    using ExampleDDD.Domain.Core;
    using ExampleDDD.Domain.Interfaces.Repositories;
    using ExampleDDD.Infraestructure.Data.Repositories;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Servicios de la capa de aplicación
            kernel.Bind(typeof(IBaseAppService<>)).To(typeof(BaseAppService<>));
            kernel.Bind<IPermissionAppService>().To<PermissionAppService>();

            //Servicios de la capa de aplicación con servicios de dominio
            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            kernel.Bind<IPermissionService>().To<PermissionService>();

            //Repositorio del dominio a los de infraestructura
            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind<IPermissionRepository>().To<PermissionRepository>();
        }//Fin del método RegisterServices   
    }
}
