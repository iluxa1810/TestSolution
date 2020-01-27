using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestSolution
{
    public partial class StorageContext : DbContext
    {
        public StorageContext()
        {
        }

        public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChangeLocationHistory> ChangeLocationHistory { get; set; }
        public virtual DbSet<FileDetail> FileDetail { get; set; }
        public virtual DbSet<Folder> Folder { get; set; }
        public virtual DbSet<FolderScanHistory> FolderScanHistory { get; set; }
        public virtual DbSet<Locaction> Locaction { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<StorageType> StorageType { get; set; }
        public virtual DbSet<StorageUserHolderHistory> StorageUserHolderHistory { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=iluxa1810\\iluxa1810;Database=Storage;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChangeLocationHistory>(entity =>
            {
                entity.Property(e => e.ChangeLocationHistoryId).HasColumnName("ChangeLocationHistory_id");

                entity.Property(e => e.DateChange).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("Location_id");

                entity.Property(e => e.StorageId).HasColumnName("Storage_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ChangeLocationHistory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChangeLocationHistory_Location");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.ChangeLocationHistory)
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChangeLocationHistory_Storage");
            });

            modelBuilder.Entity<FileDetail>(entity =>
            {
                entity.Property(e => e.FileDetailId).HasColumnName("FileDetail_id");

                entity.Property(e => e.ExtensionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FolderId).HasColumnName("Folder_id");

                entity.Property(e => e.FolderScanHistoryId).HasColumnName("FolderScanHistory_id");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => new { d.FolderScanHistoryId, d.FolderId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FileDetail_Folder");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.HasKey(e => new { e.FolderScanHistoryId, e.FolderId });

                entity.HasIndex(e => e.DateDeleted)
                    .HasName("NonClusteredIndex-20170604-202451");

                entity.HasIndex(e => e.StorageId)
                    .HasName("IX_Storage_id");

                entity.Property(e => e.FolderScanHistoryId).HasColumnName("FolderScanHistory_id");

                entity.Property(e => e.FolderId).HasColumnName("Folder_id");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.FolderPath)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ParentFolderId).HasColumnName("ParentFolder_id");

                entity.Property(e => e.StorageId).HasColumnName("Storage_id");

                entity.HasOne(d => d.FolderScanHistory)
                    .WithMany(p => p.Folder)
                    .HasForeignKey(d => d.FolderScanHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Folder_FolderScanHistory");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Folder)
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Folder_Storage");

                entity.HasOne(d => d.FolderNavigation)
                    .WithMany(p => p.InverseFolderNavigation)
                    .HasForeignKey(d => new { d.FolderScanHistoryId, d.ParentFolderId })
                    .HasConstraintName("FK_Folder");
            });

            modelBuilder.Entity<FolderScanHistory>(entity =>
            {
                entity.Property(e => e.FolderScanHistoryId).HasColumnName("FolderScanHistory_id");

                entity.Property(e => e.CreatorUserId).HasColumnName("CreatorUser_id");

                entity.Property(e => e.DateEndScan).HasColumnType("datetime");

                entity.Property(e => e.DateStartScan).HasColumnType("datetime");

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.FolderScanHistory)
                    .HasForeignKey(d => d.CreatorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FolderScanHistory_User");
            });

            modelBuilder.Entity<Locaction>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Locaction_Name")
                    .IsUnique();

                entity.Property(e => e.LocationId).HasColumnName("Location_id");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LocationTypeId).HasColumnName("LocationType_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.LocationType)
                    .WithMany(p => p.Locaction)
                    .HasForeignKey(d => d.LocationTypeId)
                    .HasConstraintName("FK_Locaction_LocationType");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ_LocationType_Name")
                    .IsUnique();

                entity.Property(e => e.LocationTypeId)
                    .HasColumnName("LocationType_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.Property(e => e.StorageId).HasColumnName("Storage_id");

                entity.Property(e => e.CurrentHolderUserId).HasColumnName("CurrentHolderUser_id");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateOfLastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.LocationId).HasColumnName("Location_id");

                entity.Property(e => e.OwnerUserId).HasColumnName("OwnerUser_id");

                entity.Property(e => e.SerialNumber).HasMaxLength(255);

                entity.Property(e => e.StorageTypeId).HasColumnName("StorageType_id");

                entity.HasOne(d => d.CurrentHolderUser)
                    .WithMany(p => p.StorageCurrentHolderUser)
                    .HasForeignKey(d => d.CurrentHolderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Storage_User2");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Storage)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Storage_Locaction");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Storage)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Storage_StorageType");

                entity.HasOne(d => d.OwnerUser)
                    .WithMany(p => p.StorageOwnerUser)
                    .HasForeignKey(d => d.OwnerUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Storage_User1");
            });

            modelBuilder.Entity<StorageType>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ_StorageType_Name")
                    .IsUnique();

                entity.Property(e => e.StorageTypeId)
                    .HasColumnName("StorageType_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<StorageUserHolderHistory>(entity =>
            {
                entity.Property(e => e.StorageUserHolderHistoryId).HasColumnName("StorageUserHolderHistory_id");

                entity.Property(e => e.DateChange).HasColumnType("datetime");

                entity.Property(e => e.FromUserId).HasColumnName("FromUser_id");

                entity.Property(e => e.StorageId).HasColumnName("Storage_id");

                entity.Property(e => e.ToUserId).HasColumnName("ToUser_id");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.StorageUserHolderHistoryFromUser)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StorageUserHolderHistory_User_1");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.StorageUserHolderHistoryToUser)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StorageUserHolderHistory_User_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login)
                    .HasName("UQ_User_Login")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
