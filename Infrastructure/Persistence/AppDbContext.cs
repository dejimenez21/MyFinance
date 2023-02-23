using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}