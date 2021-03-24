using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Core.Db
{
    public class DynamoDbContext : DbContext, IDynamoDbContext
    {
        public DynamoDbContext(DbContextOptions<DynamoDbContext> options)
            : base(options)
        {
        
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbContext Context => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .HasOne(e => e.Country);

            modelBuilder.Entity<Contact>()
            .HasOne(e => e.User)
            .WithMany(e => e.Contacts);
        }

        //public override int SaveChanges()
        //{
        //    try
        //    {
        //        return base.SaveChanges();
        //    }
        //    catch (DbEntityValidationException e)
        //    {
        //        throw new FormattedDbEntityValidationException(e);
        //    }
        //}
        
    }
}
