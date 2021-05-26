using System;
using System.Data.Entity;
using System.Linq;
using Wiky.Models;

namespace Wiky
{
    public class Wikydb : DbContext
    {
        // Your context has been configured to use a 'wikydb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Wiky.wikydb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'wikydb' 
        // connection string in the application configuration file.
        public Wikydb()
            : base("name=wikydb")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Commentaire> Commentaire { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}