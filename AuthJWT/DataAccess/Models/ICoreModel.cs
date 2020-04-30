using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthJWT.DataAccess.Models
{
    public interface ICoreModel
    {

        /// <summary>
        /// Metodo encargado de agregar una entidad a la base de datos
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddAsync<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Método encargado de consultar todo los registros
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>Una entidad Iquerable</returns>
        IQueryable<TEntity> GetAllAsync<TEntity>() where TEntity : class;

        /// <summary>
        /// Metoeo encargado de consultar todo los registros
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>Una entidad Iquerable</returns>
        IQueryable<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;


        /// <summary>
        /// Metodo encargado de buscar registros segun la predicado
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        /// <summary>
        /// Metodo encargado de consultar un solo registro segun el predicado
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        /// <summary>
        /// Metodo encargado de actualizar una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Metodo encargado de eliminar una entidad en la base de datos
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Método Encargado de borrar una lista de entidades
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> DeleteListAsync<TEntity>(List<TEntity> entities) where TEntity : class;
        /// <summary>
        /// Metodo encargado de obtener un conteo de filas de las filas
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class;
        /// <summary>
        /// Metodo encargado de guardar los cambios en la base de datos
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
