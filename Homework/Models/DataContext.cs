﻿using Homework.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
    }
}
