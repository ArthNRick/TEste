using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Insert(T obj);

        T Update(T obj);

        void Delete(int id);

        T Get(int id);

        IList<T> Get();
    }
}
