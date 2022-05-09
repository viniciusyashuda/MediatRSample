﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatRSample.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task AddAsync(T item);
        Task EditAsync(T item);
        Task DeleteAsync(int id);
    }
}