using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CosmosPreview
{
    class BaseService<TEntity> where TEntity : class
    {
        private readonly SchroedingerContext _schroedingerCtx;

        public DbSet<TEntity> Repository { get; }

        public BaseService(SchroedingerContext schroedingerCtx)
        {
            _schroedingerCtx = schroedingerCtx;
            Repository = _schroedingerCtx.Set<TEntity>();
        }

        public Task AddEntityAsync(TEntity entity)
        {
            Helper.PrintBlock(string.Format("Das Objekt {0} wurde dem Context hinzugefügt.", entity.ToString()) );
            return Repository.AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            Stopwatch timer = Stopwatch.StartNew();
            
            var count = await _schroedingerCtx.SaveChangesAsync();

            timer.Stop();

            Helper.PrintBlock(string.Format("{0} Entitäten wurden in {1} Sekunden vom Context in die Datenbank übertragen und persistiert.", count.ToString(), timer.Elapsed.TotalSeconds));

            return count;
        }
    }
}
