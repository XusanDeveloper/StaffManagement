﻿using Microsoft.EntityFrameworkCore;
using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.DataAccess.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    FullName = "G'oziy",
                    Email = "usmon@mail.com",
                    Department = Departments.Admin
                },
                new Staff
                {
                    Id = 2,
                    FullName = "Jaloliddin",
                    Email = "jalol@mail.com",
                    Department = Departments.RnD
                }
                );
        }
    }
}