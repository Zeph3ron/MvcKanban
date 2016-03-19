using KanbanProjectMvc.Models;
using KanbanProjectMvc.Models.POCOs;

namespace KanbanProjectMvc.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KanbanDbContext : DbContext
    {
        // Your context has been configured to use a 'KanbanDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KanbanProjectMvc.EF.KanbanDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KanbanDbContext' 
        // connection string in the application configuration file.
        public KanbanDbContext()
            : base("name=KanbanDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<KanbanBoard> Boards { get; set; }
        public DbSet<BoardColumn> Columns { get; set; }
        public DbSet<BoardSticker> Stickers { get; set; }
        public DbSet<StickerAssignment> Assignments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}