using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        RepositoryResponse Delete(int id);

        RepositoryResponse Create(T entity);

        RepositoryResponse Edit(T entity);

        ICollection<T> GetAll();

        T GetById(int id);
    }
   
}
