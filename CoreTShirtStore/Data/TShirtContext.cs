using CoreTShirtStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTShirtStore.Data
{
    public class TShirtContext :DbContext
    {
        public TShirtContext(DbContextOptions<TShirtContext> options) : base(options)
        {
        }

        public DbSet<TShirt> TShirts { get; set; }
        public object TShirt { get; internal set; }
    }
}
