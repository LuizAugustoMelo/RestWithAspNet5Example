using Microsoft.EntityFrameworkCore;
using RestWithAspNet5Example.Model;
using RestWithAspNet5Example.Model.Base;
using RestWithAspNet5Example.Model.Context;
using System;

namespace RestWithAspNet5Example.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;

        private DbSet<T> _dbSet;


        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public T FindById(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = FindById(item.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return item;
        }

        public void Delete(long id)
        {
            var result = FindById(id);

            if (result != null)
            {
                try
                {
                    _dbSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dbSet.Any(x => x.Id.Equals(id));
        }
    }
}
