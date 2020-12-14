using Curriculo.Business.Interfaces;
using Curriculo.Business.Models;
using Curriculo.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curriculo.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task Remover(TEntity entity)
        {
            Db.Set<TEntity>().Remove(entity);
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
                 
        }

        public void Dispose()
        {
            Db?.Dispose();
        }


        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
