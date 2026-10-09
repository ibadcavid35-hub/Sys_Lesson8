using Microsoft.EntityFrameworkCore;
using Sys_Lesson8.Generics;
using Sys_Lesson8.Models;
using Sys_Lesson8.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys_Lesson8.Repositories.Concretes;

public class SCardRepository : GenericRepository<SCard>, ISCardRepository
{
    public SCardRepository(DbContext context) : base(context)
    {
    }
}
