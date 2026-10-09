using Sys_Lesson8.DbContexts;
using Sys_Lesson8.Models;
using Sys_Lesson8.Repositories.Concretes;
using Sys_Lesson8.Service;
using Sys_Lesson8.UOW;

class Program
{
    static async Task Main(string[] args)
    {
        ////Get All Student With Group Name

        var dbContext = new LibraryContext();

        //StudentRepository studentRepo = new StudentRepository(dbContext);

        //CategoryRepository categoryRepository = new CategoryRepository(dbContext);

        //var allStudent = await studentRepo.GetAllStudentWithGroupNameAsync();

        //foreach (var student in allStudent)
        //{
        //    Console.WriteLine($"{student.Name} {student.Surname} => {student.GroupName}");
        //}

        ////Get All Teacher With Department Name

        //TeacherRepository teacherRepo = new TeacherRepository(dbContext);
        //DepartmentRepository departmentRepository = new DepartmentRepository(dbContext);
        //var allTeacher = await teacherRepo.GetAllTeacherWithDepartmentNameAsync();

        //foreach (var teacher in allTeacher)
        //{
        //    Console.WriteLine($"{teacher.FirstName} {teacher.LastName} => {teacher.DepartmentName}");
        //}


        //Transaction

        var uow = new UnitOfWork<Student>(dbContext);
        var service = new StudentService(uow);

        var studentToUpdate = await uow._repository.GetByIdAsync(7);
        studentToUpdate.FirstName = "Arif";
        studentToUpdate.LastName = "Osmanli";

        var studentToAdd = new Student
        {
            FirstName = "Asif",
            LastName = "Orucov",
            IdGroup = 1,
            Term = 2
        };

        await service.TransactionOperations(studentToUpdate, studentToAdd);

    }
}