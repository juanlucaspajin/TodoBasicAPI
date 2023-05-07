using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoBasicAPI.Models;

namespace TodoBasicAPI.Data;

public partial class TodoBasicAPIContext : DbContext
{
    public TodoBasicAPIContext(DbContextOptions<TodoBasicAPIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todo_item");

            entity.HasIndex(e => e.Uid, "uid_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsComplete).HasColumnName("is_complete");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Uid).HasColumnName("uid");

            entity.HasOne(d => d.user).WithMany(p => p.TodoItems)
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("uid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.ProfilePic)
                .HasMaxLength(255)
                .HasColumnName("profile_pic");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
