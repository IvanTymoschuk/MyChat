using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repos<T>
      where T : class
    {
        public DbContext db;
        DbSet<T> Set;

        public Repos(DbContext _db)
        {
            db = _db;
            Set = db.Set<T>();
        }

        public void Create(T Entity)
        {
            Set.Add(Entity);
            db.SaveChanges();
        }

        public List<T> ReadAll()
        {
            return Set.AsNoTracking().ToList();
        }

        public void Update(T Entity)
        {
            db.Entry(Entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(T Entity)
        {
            Set.Remove(Entity);
            db.SaveChanges();
        }


    }
}
