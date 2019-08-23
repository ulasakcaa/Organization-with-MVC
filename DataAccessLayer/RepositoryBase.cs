﻿using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        MyOrganizationEntities _ctx;

        public RepositoryBase()
        {
            _ctx = new MyOrganizationEntities();
        }

        public T Get(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public List<T> List()
        {
            return _ctx.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = Get(id);
            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
