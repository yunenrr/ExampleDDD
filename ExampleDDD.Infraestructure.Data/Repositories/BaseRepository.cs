using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ExampleDDD.Domain.Interfaces.Repositories;

namespace ExampleDDD.Infraestructure.Data.Repositories
{
    /**
     * <summary>Clase genérica que puede ser utilizado por cualquier entidad, se encarga de realizar las consultas a Entity Framework.</summary>
     */
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        /**
         * <summary>Método que permite ingresar una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea agregar</param>
         */
        public void add(TEntity entity)
        {
            //Se ejecuta dentro de un atrapador de errores
            try
            {
                using (var context = new dbhotelEntities())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                }
            }//Fin del try
            catch (Exception ex)
            {
                throw new Exception("No se puede guardar el registro", ex);
            }//Fin del catch
        }//Fin del método

        /**
         * <summary>Método que permite eliminar una entidad</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea eliminar</param>
         */
        public void delete(int id)
        {
            //Se ejecuta dentro de un atrapador de errores
            try
            {
                using (var context = new dbhotelEntities())
                {
                    var entity = context.Set<TEntity>().Find(id);
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro", ex);
            }//Fin del catch
        }//Fin del método

        public void Dispose()
        {
            throw new NotImplementedException();
        }//Fin del método

        /**
         * <summary>Método que permite obtener todos los registros pertenecientes a esa entidad</summary>
         * <returns>Todos los objetos de ese tipo de entidad</returns>
         */
        public IEnumerable<TEntity> getAll()
        {
            //Se ejecuta dentro de un atrapador de errores
            try
            {
                using (var context = new dbhotelEntities())
                {
                    return context.Set<TEntity>().ToList();
                }
            }//Fin del try
            catch (Exception ex)
            {
                throw new Exception("No se pudieron recuperar los registros", ex);
            }//Fin del catch
        }//Fin del método

        /**
         * <summary>Método que permite obtener la información correspondiente a la entidad solicitada</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea obtener</param>
         * <returns>La información de la correspondiente entidad</returns>
         */
        public TEntity getById(int id)
        {
            //Se ejecuta dentro de un atrapador de errores
            try
            {
                using (var context = new dbhotelEntities())
                {
                    return context.Set<TEntity>().Find(id);
                }
            }//Fin del try
            catch (Exception ex)
            {
                throw new Exception("No se pudo recuperar el registro", ex);
            }//Fin del catch
        }//Fin del método

        /**
         * <summary>Método que permite actualizar la información una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea modificar</param>
         */
        public void modify(TEntity entity)
        {
            //Se ejecuta dentro de un atrapador de errores
            try
            {
                using (var context = new dbhotelEntities())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }//Fin del try
            catch (Exception ex)
            {
                throw new Exception("No se puede actualizar el registro", ex);
            }//Fin del catch
        }//Fin del método
    }//Fin de la clase BaseRepository
}//Fin del namespace