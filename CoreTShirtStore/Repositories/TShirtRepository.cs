using CoreTShirtStore.Data;
using CoreTShirtStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTShirtStore.Repositories;

namespace CoreTShirtStore.Repositories
{
    public class TShirtRepository: GenericRepository<TShirt>
    {
        public TShirtRepository(TShirtContext context) : base(context)
        {
        }

        public override bool CheckTShirtExists(int id)
        {
            return _context.TShirts.Any(e => e.ID == id);
        }
    }
}
