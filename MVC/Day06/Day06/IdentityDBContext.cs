using Day06.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day06
{
    public class IdentityDBContext:DbContext
    {
        public IdentityDBContext() : base("IdentityDBContext")
        {

        }

        public virtual DbSet<Client> Clients { get; set; }
    }
}