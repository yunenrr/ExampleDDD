using ExampleDDD.Domain.Interfaces.Repositories;
using ExampleDDD.Domain.Interfaces.Services;
using ExampleDDD.Domain.Entities;

namespace ExampleDDD.Domain.Core
{
    /**
     * <summary>Clase que contiene los métodos de la entidad permiso, se encarga de realizar la conexión entre los servicios y los repositorios.</summary>
     */
    public class PermissionService:BaseService<tbpermission>, IPermissionService
    {
        //Declaración de variables globales
        private readonly IPermissionRepository permissionRepository;

        /**
         * <summary>Método constructor</summary>
         * <param name="permissionRepository">Corresponde al tipo de interfaz de tipo IPermissionRepository</param>
         */
        public PermissionService(IPermissionRepository permissionRepository):base(permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }//Fin del método
    }//Fin de la clase PermissionService
}//Fin del namespace