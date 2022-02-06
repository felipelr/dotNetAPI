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

        public DbSet<User> Users { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<Client> Clients { get; private set; }
        public DbSet<Professional> Professionals { get; private set; }
    }
}