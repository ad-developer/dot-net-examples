using System;

namespace BaseRepositoryWithUnitOfWork;

public interface IUnitOfWork
{
    void SaveChanges();
}
