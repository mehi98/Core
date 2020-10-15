using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace MyCms.DataLayer.Context
{
    public class MyWebContext:DbContext
    {
        public MyWebContext(DbContextOptions<MyWebContext> options):base(options)
        {

        }

        public DbSet<Page> pages { get; set; }
        public DbSet<PageGroup.PageGroup> pageGroups { get; set; }

    }
}
