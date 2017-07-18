using System;
using System.Collections.Generic;
using ExampleDDD.Application.Main.Interfaces;
using ExampleDDD.Domain.Interfaces.Services;

namespace ExampleDDD.Application.Main.Services
{
    /**
     * <summary>Clase genérica que puede ser utilizado por cualquier entidad, se encarga de realizar la conexión entre los servicios de la capa de aplicación con los servicios del dominio.</summary>
     */
    public class BaseAppService<TEntity> : IDisposable, IBaseAppService<TEntity> where TEntity : class
    {
        //Declaración de variables globales
        private readonly IBaseService<TEntity> baseService;

        /**
         * <summary>Método constructor</summary>
         * <param name="baseService">Corresponde a la interfaz de tipo IBaseRepository</param>
         */
        public BaseAppService(IBaseService<TEntity> baseService)
        {
            this.baseService = baseService;
        }//Fin del método

        /**
         * <summary>Método que permite ingresar una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea agregar</param>
         */
        public void add(TEntity entity)
        {
            this.baseService.add(entity);
        }//Fin del método

        /**
         * <summary>Método que permite eliminar una entidad</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea eliminar</param>
         */
        public void delete(int id)
        {
            this.baseService.delete(id);
        }//Fin del método

        public void Dispose()
        {
            this.baseService.Dispose();
        }//Fin del método

        /**
         * <summary>Método que permite obtener todos los registros pertenecientes a esa entidad</summary>
         * <returns>Todos los objetos de ese tipo de entidad</returns>
         */
        public IEnumerable<TEntity> getAll()
        {
            return this.baseService.getAll();
        }//Fin del método

        /**
         * <summary>Método que permite obtener la información correspondiente a la entidad solicitada</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea obtener</param>
         * <returns>La información de la correspondiente entidad</returns>
         */
        public TEntity getById(int id)
        {
            return this.baseService.getById(id);
        }//Fin del método

        /**
         * <summary>Método que permite actualizar la información una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea modificar</param>
         */
        public void modify(TEntity entity)
        {
            this.baseService.modify(entity);
        }//Fin del método
    }//Fin de la clase BaseAppService
}//Fin del namespace