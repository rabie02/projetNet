﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace backend.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<adminn> Admins { get; set; }
    }
}