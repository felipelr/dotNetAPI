using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;

namespace Strab.Domain.Infra.Contexts
{
    public class StrabContext : DbContext
    {
        public StrabContext(DbContextOptions<StrabContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; private set; }
    }
}