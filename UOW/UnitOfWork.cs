using Microsoft.EntityFrameworkCore.Storage;
using Sys_Lesson8.DbContexts;
using Sys_Lesson8.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys_Lesson8.UOW;

public class UnitOfWork<T> : IUnitOfWork<T> where T : class,Sys_Lesson8.Models.Base.IEntity
{
    private readonly LibraryContext _context;
    private IDbContextTransaction _transaction;
    public IGenericRepository<T> _repository { get; }
    public UnitOfWork(LibraryContext context) 
    {
        _context = context;
        _repository = new GenericRepository<T>(_context);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.SaveChangesAsync();
        await _transaction.CommitAsync();
    }

    public async void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
