using System;

namespace EAI.Template.Data.Repository
{
   
    public interface IUnitOfWork : IDisposable
    {
      
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

     
        int Commit();
    }
}