using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL.Initializers
{
    public class MyInit : DropCreateDatabaseIfModelChanges<DBase>
    {
        protected override void Seed(DBase context)
        {
          

            context.SaveChanges();
        }
    }
}
