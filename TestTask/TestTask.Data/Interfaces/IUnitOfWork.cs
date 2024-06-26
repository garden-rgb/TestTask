﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IOrderRepository Orders { get; }
        Task<bool> SaveAsync();
    }
}
