namespace autotune.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class ProjectContext : DbContext
    {
        // Your context has been configured to use a 'ProjectContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'autotune.Models.ProjectContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProjectContext' 
        // connection string in the application configuration file.
        public ProjectContext()
            : base("name=ProjectContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter product's name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter product's description!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select product's category!")]
        public Category Category { get; set; }

        public string SmallImage { get; set; }

        public string BigImage { get; set; }
    }

    public enum Category
    {
        Front,
        Rear,
        Footer,
        Other
    }
}