using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthJWT.DataAccess.Models
{
    public class CoreModel : ICoreModel
    {

        /// <summary>
        /// Contexto de la base de datos
        /// </summary>
        private readonly DbContext db;


        public CoreModel()
        {
            //  this.db = new Db_SaguirContext();
        }
        public async Task<bool> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var context = this.db.Set<TEntity>();
            await context.AddAsync(entity);
            return await this.SaveAsync();
        }
        /// <summary>
        /// Metoeo encargado de consultar todo los registros
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>Una entidad Iquerable</returns>
        public IQueryable<TEntity> GetAllAsync<TEntity>() where TEntity : class
        {
            //Obtenemos todos los elementos de la base de datos
            return this.db.Set<TEntity>();
        }

        /// <summary>
        /// Metodo encargado de buscar registros segun la predicado
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitiy = this.db.Set<TEntity>().Where(predicate);

            var result = await entitiy.ToListAsync();

            return result;
        }

        /// <summary>
        /// Método Encargado de retornar una sola unidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> GetOneAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var entitiy = this.db.Set<TEntity>().Where(predicate);

            return await entitiy.FirstOrDefaultAsync();

        }

        /// <summary>
        /// Metodo encargado de actualizar una entidad
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var context = this.db.Set<TEntity>();
            context.Update(entity);
            return this.SaveAsync();

        }

        /// <summary>
        /// Metodo encargado de eliminar una entidad en la base de datos
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var context = this.db.Set<TEntity>();
            context.Remove(entity);

            return await this.SaveAsync();
        }

        /// <summary>
        /// Método Encargado de borrar una lista de entidades
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<bool> DeleteListAsync<TEntity>(List<TEntity> entities) where TEntity : class
        {
            //Attachamos el contexto
            var context = db.Set<TEntity>();

            //Eliminamos la lista de entidades
            context.RemoveRange(entities);

            return await this.SaveAsync();
        }

        /// <summary>
        /// Metodo encargado de obtener un conteo de filas de las filas
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de guardar los cambios en la base de datos
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> SaveAsync()
        {
            //Guardamos los cambios en la base de datos
            var save = await this.db.SaveChangesAsync() > 0;
            this.db.Dispose();
            return save;
        }

        /// <summary>
        /// Busca un iqueryable de registros
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            //Obtenemos todos los elementos de la base de datos
            return this.db.Set<TEntity>();
        }
    }
}
