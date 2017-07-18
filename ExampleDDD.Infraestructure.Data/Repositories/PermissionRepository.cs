using ExampleDDD.Domain.Entities;
using ExampleDDD.Domain.Interfaces.Repositories;

namespace ExampleDDD.Infraestructure.Data.Repositories
{
    /**
     * <summary>Clase que contiene los métodos de la entidad permiso, se encarga de realizar las consultas a Entity Framework.</summary>
     */
    public class PermissionRepository : BaseRepository<tbpermission>, IPermissionRepository
    {
    }//Fin de la clase PermissionService
}//Fin del namespace