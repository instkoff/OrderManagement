using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OrderManagement.DataAccess.Entities;

namespace OrderManagement.DataAccess
{
    /// <summary>
    /// Абстракция для репозитория
    /// </summary>
    public interface IDbRepository
    {
        /// <summary>
        /// Получение всех записей
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <returns>Коолекция записей</returns>
        IQueryable<T> GetAll<T>() where T : class, IEntity;
        /// <summary>
        /// Получение записи по условию
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="selector">Условие</param>
        /// <returns></returns>
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity;
        /// <summary>
        /// Добавление обекта в БД
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="newEntity">Экземпляр объекта</param>
        /// <returns>Id созданного объекта</returns>
        Task<int> AddAsync<T>(T newEntity) where T : class, IEntity;
        /// <summary>
        /// Удаление записи из базы
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="id">Id объекта</param>
        /// <returns></returns>
        Task RemoveAsync<T>(int id) where T : class, IEntity;

        /// <summary>
        /// Обновление записи в БД
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="entity">Объект для обновления</param>
        /// <returns></returns>
        Task RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity;
        Task UpdateAsync<T>(T entity) where T : class, IEntity;
        /// <summary>
        /// Сохрание изменений
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}