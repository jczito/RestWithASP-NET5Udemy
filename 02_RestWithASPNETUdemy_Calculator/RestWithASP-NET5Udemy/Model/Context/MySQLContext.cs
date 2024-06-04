﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace RestWithASP_NET5Udemy.Model.Context
{
    public class MySQLContext: DbContext
    {
        public MySQLContext()
        { 
        
        }
        public MySQLContext(DbContextOptions<MySQLContext> options): base(options) 
        {
            
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }


    }
}