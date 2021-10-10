using CoreTShirtStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTShirtStore.Data
{
    public class DbInitializer
    {
        public static void Initialize(TShirtContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TShirts.Any())
            {
                return;   // DB has been seeded
            }

            var tshirts = new TShirt[]
            {
            new TShirt{Size=Size.Large,Color="Red", isTightFit=true, message="You've \n Got \n This"},
              new TShirt{Size=Size.Medium,Color="Blue", isTightFit=false, message="Never \n Give \n Up"},
                new TShirt{Size=Size.Small,Color="Yellow", isTightFit=true, message="Teamwork \n Makes the \n dream work"},
                  new TShirt{Size=Size.XLarge,Color="Green", isTightFit=false, message="Happy Days"}
            };
            foreach (TShirt t in tshirts)
            {
                context.TShirts.Add(t);
            }
            context.SaveChanges();

        }
    }
}
