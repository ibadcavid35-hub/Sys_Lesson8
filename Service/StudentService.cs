using Sys_Lesson8.Models;
using Sys_Lesson8.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys_Lesson8.Service;

public class StudentService
{
    private readonly UnitOfWork<Student> _uow;

    public StudentService(UnitOfWork<Student> uow)
    {
        _uow = uow;
    }

    public async Task TransactionOperations(Student studentToUpdate, Student studentToAdd)
    {
        if (studentToUpdate == null) return;
        await _uow.BeginTransactionAsync();

        try
        {
            await _uow._repository.UpdateAsync(studentToUpdate);

            await _uow._repository.AddAsync(studentToAdd);

            await _uow.CommitTransactionAsync();

            Console.WriteLine("Completed Succesfully");
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            Console.WriteLine($"Transaction Failed: {ex.Message}");
        }
    }
}
