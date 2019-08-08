using Microsoft.Extensions.Configuration;
using TR.Domain.Entities;
using TR.Domain.Interfaces;
using TR.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TR.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SqlContext _context;

        public BaseRepository(string connectionString)
        {
            _context = new SqlContext(connectionString);
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<T> Select()
        {
            return _context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
