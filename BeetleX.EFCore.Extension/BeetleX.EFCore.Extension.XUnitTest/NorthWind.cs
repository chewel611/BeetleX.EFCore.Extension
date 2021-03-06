﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeetleX.EFCore.Extension.XUnitTest
{
    public class NorthWind : DbContext
    {
        public DbSet<customers> Customers { get; set; }

        public DbSet<employees> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=192.168.2.19;port=3306;user=root;password=123456; database=northwind;");
        }
    }

    public class customers
    {
        public int id { get; set; }

        public string company { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email_address { get; set; }

        public string job_title { get; set; }

        public string bussiness_phone { get; set; }

        public string home_phone { get; set; }

        public string mobile_phone { get; set; }

        public string fax_number { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state_province { get; set; }

    }

    public class employees
    {
        public int id { get; set; }

        public string company { get; set; }

        public string last_name { get; set; }

        public string first_name { get; set; }

        public string email_address { get; set; }

        public string job_title { get; set; }

        public string business_phone { get; set; }

        public string home_phone { get; set; }

        public string mobile_phone { get; set; }

        public string fax_number { get; set; }
    }


}
