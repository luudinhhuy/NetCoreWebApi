﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace coreApi.Domain.Models
{
    public class AppDBContext: DbContext
    {
        private readonly DbContextOptions _options;
        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }
        public DbSet<Member> members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
