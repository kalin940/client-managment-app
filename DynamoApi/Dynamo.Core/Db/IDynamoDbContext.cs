using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Core.Db
{
    public interface IDynamoDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Country> Countries { get; set; }
        DbContext Context { get; }
    }
}
