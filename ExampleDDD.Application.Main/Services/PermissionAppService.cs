using ExampleDDD.Domain.Entities;
using ExampleDDD.Domain.Interfaces.Services;
using ExampleDDD.Application.Main.Interfaces;

namespace ExampleDDD.Application.Main.Services
{
    /**
     * <summary>Clase que contiene los métodos de la entidad permiso, se encarga de realizar la conexión entre los servicios de la aplicación con los servicios del dominio.</summary>
     */
    public class PermissionAppService : BaseAppService<tbpermission>, IPermissionAppService
    {
        //Declaración de variables globales
        private readonly IPermissionService permissionService;

        /**
         * <summary>Método constructor</summary>
         * <param name="permissionRepository">Corresponde al tipo de interfaz de tipo IPermissionRepository</param>
         */
        public PermissionAppService(IPermissionService permissionService):base(permissionService)
        {
            this.permissionService = permissionService;
        }//Fin del método
    }//Fin de la clase PermissionAppService
}//Fin del namespace