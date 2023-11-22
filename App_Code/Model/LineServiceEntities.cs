using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

public partial class LineServiceEntities : DbContext
{
    public LineServiceEntities()
        : base("name=LineServiceEntities")
    {
    }

    public virtual DbSet<agent_data> agent_data { get; set; }
    public virtual DbSet<city_map> city_map { get; set; }
    public virtual DbSet<job_role> job_role { get; set; }
    public virtual DbSet<store_data> store_data { get; set; }
    public virtual DbSet<tree_menu> tree_menu { get; set; }
    public virtual DbSet<user_data> user_data { get; set; }
    public virtual DbSet<agent_apply> agent_apply { get; set; }
    public virtual DbSet<agent_record> agent_record { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        
    }
}