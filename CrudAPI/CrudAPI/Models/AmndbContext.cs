using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Models;

public partial class AmndbContext : DbContext
{


    public AmndbContext(DbContextOptions<AmndbContext> options, IConfiguration configuration)
        : base(options)
    {

    }
    public virtual DbSet<File> Files { get; set; } 



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

}
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<File>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("files");

//            entity.Property(e => e.Id)
//                .ValueGeneratedOnAdd()
//                .HasColumnName("id");
//            entity.Property(e => e.Message)
//                .HasMaxLength(100)
//                .IsUnicode(false)
//                .HasColumnName("message");
//            entity.Property(e => e.Name)
//                .HasMaxLength(30)
//                .IsUnicode(false)
//                .HasColumnName("name");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
