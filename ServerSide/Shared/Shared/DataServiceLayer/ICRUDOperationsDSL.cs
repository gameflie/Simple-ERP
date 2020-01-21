﻿using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataServiceLayer
{
    public interface ICRUDOperationsDSL<T>
    {
        Task<ResponseEntityList<T>> GetAll(T entity);
        Task<T> GetById(long id);
        Task<long> Update(T entity);
        Task<long> Add(T entity);
        Task<long> Delete(long id);
    }
}
