namespace DAL
{
    using DAL.Initializers;
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBase : DbContext
    {
        // Your context has been configured to use a 'DBase' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.DBase' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBase' 
        // connection string in the application configuration file.
        public DBase()
            : base("name=DBase")
        {
            Database.SetInitializer(new MyInit());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Attach> Attaches { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ConfirmCode> ConfirmCodes { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}