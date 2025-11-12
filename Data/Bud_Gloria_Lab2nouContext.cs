using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bud_Gloria_Lab2nou.Models;

namespace Bud_Gloria_Lab2nou.Data
{
    public class Bud_Gloria_Lab2nouContext : DbContext
    {
        public Bud_Gloria_Lab2nouContext(DbContextOptions<Bud_Gloria_Lab2nouContext> options)
            : base(options)
        {
        }

        public DbSet<Bud_Gloria_Lab2nou.Models.Book> Book { get; set; } = default!;
        public DbSet<Bud_Gloria_Lab2nou.Models.Publisher> Publisher { get; set; } = default!;

        // ACEASTĂ LINIE ESTE CEA MAI IMPORTANTĂ PENTRU A REZOLVA EROAREA
        public DbSet<Bud_Gloria_Lab2nou.Models.Author> Author { get; set; } = default!;
    }
}