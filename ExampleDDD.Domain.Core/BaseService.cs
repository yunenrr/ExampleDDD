using System;
using System.Collections.Generic;
using ExampleDDD.Domain.Interfaces.Repositories;
using ExampleDDD.Domain.Interfaces.Services;

namespace ExampleDDD.Domain.Core
{
    /**
     * <typeparam name="TEntity">Corresponde a la entidad con la cual van a trabajar los métodos de esta interfaz, por ejemplo: entidad de tipo “Permiso”/”Persona”/”Usuario”.</typeparam>
     * <summary>Clase genérica que puede ser utilizado por cualquier entidad, se encarga de realizar la conexión entre los servicios y los repositorios.</summary>
     */
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        //Declaración de variables globales
        private readonly IBaseRepository<TEntity> baseRepository;

        /**
         * <summary>Método constructor</summary>
         * <param name="baseRepository">Corresponde a la interfaz de tipo IBaseRepository</param>
         */
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }//Fin del método

        /**
         * <summary>Método que permite ingresar una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea agregar</param>
         */
        public void add(TEntity entity)
        {
            this.baseRepository.add(entity);
        }//Fin del método

        /**
         * <summary>Método que permite eliminar una entidad</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea eliminar</param>
         */
        public void delete(int id)
        {
            this.baseRepository.delete(id);
        }//Fin del método

        public void Dispose()
        {
            this.baseRepository.Dispose();
        }//Fin del método

        /**
         * <summary>Método que permite obtener todos los registros pertenecientes a esa entidad</summary>
         * <returns>Todos los objetos de ese tipo de entidad</returns>
         */
        public IEnumerable<TEntity> getAll()
        {
            return this.baseRepository.getAll();
        }//Fin del método

        /**
         * <summary>Método que permite obtener la información correspondiente a la entidad solicitada</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea obtener</param>
         * <returns>La información de la correspondiente entidad</returns>
         */
        public TEntity getById(int id)
        {
            return this.baseRepository.getById(id);
        }//Fin del método

        /**
         * <summary>Método que permite actualizar la información una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea modificar</param>
         */
        public void modify(TEntity entity)
        {
            this.baseRepository.modify(entity);
        }//Fin del método
    }//Fin de la clase BaseService
}//Fin del namespace