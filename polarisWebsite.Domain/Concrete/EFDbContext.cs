﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using polarisWebsite.Domain.Entities;
using System.Data.Entity;

namespace polarisWebsite.Domain.Concrete
{
    public class EFDbContext :DbContext
    {
        public DbSet<Article> Articles { get; set; }
    }
}
