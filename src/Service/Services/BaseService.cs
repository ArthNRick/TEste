using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> _repository;

        public BaseService(IConfiguration configuration)
        {
            _repository = new BaseRepository<T>(configuration.GetConnectionString("Sistema"));
        }

        public T Insert(T obj)
        {
            _repository.Insert(obj);
            return obj;
        }

        public T Update(T obj)
        {
            _repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> Get() => _repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return _repository.Select(id);
        }


    }
}
