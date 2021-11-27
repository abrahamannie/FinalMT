using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagementWebAPI.Models
{
    public partial class AssetManagementDbContext : DbContext
    {
        public AssetManagementDbContext()
        {
        }

        public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetDefinition> AssetDefinition { get; set; }
        public virtual DbSet<AssetMaster> AssetMaster { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ANNIEABRAHAM\\SQLEXPRESS; Initial Catalog=AssetManagementDb; Integrated security=True");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetDefinition>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__AssetDef__CAA4A62797EDB0F4");

                entity.Property(e => e.AdId)
                    .HasColumnName("ad_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdName)
                    .HasColumnName("ad_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdTypeId)
                    .HasColumnName("ad_type_id")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.AdType)
                    .WithMany(p => p.AssetDefinition)
                    .HasForeignKey(d => d.AdTypeId)
                    .HasConstraintName("fk_assettype1");
            });

            modelBuilder.Entity<AssetMaster>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__AssetMas__B95A8ED04CC74359");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAdId)
                    .HasColumnName("am_ad_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AmAtypeId)
                    .HasColumnName("am_atype_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AmForm)
                    .HasColumnName("am_form")
                    .HasColumnType("date");

                entity.Property(e => e.AmMakeId)
                    .HasColumnName("am_make_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AmModel)
                    .HasColumnName("am_model")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmMyyear)
                    .HasColumnName("am_myyear")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AmPdate)
                    .HasColumnName("am_pdate")
                    .HasColumnType("date");

                entity.Property(e => e.AmSnumber)
                    .HasColumnName("am_snumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmTo)
                    .HasColumnName("am_to")
                    .HasColumnType("date");

                entity.Property(e => e.AmWaranty)
                    .HasColumnName("am_waranty")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AmAd)
                    .WithMany(p => p.AssetMasterAmAd)
                    .HasForeignKey(d => d.AmAdId)
                    .HasConstraintName("fk_assetdef2");

                entity.HasOne(d => d.AmAtype)
                    .WithMany(p => p.AssetMaster)
                    .HasForeignKey(d => d.AmAtypeId)
                    .HasConstraintName("fk_assettype3");

                entity.HasOne(d => d.AmMake)
                    .WithMany(p => p.AssetMasterAmMake)
                    .HasForeignKey(d => d.AmMakeId)
                    .HasConstraintName("fk_vendor2");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PK__AssetTyp__61F859884FE33CE8");

                entity.Property(e => e.AtId)
                    .HasColumnName("at_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AtName)
                    .HasColumnName("at_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F818C1E0E2");

                entity.Property(e => e.LId)
                    .HasColumnName("l_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PdId)
                    .HasName("PK__Purchase__F7562CCF9EA16802");

                entity.Property(e => e.PdId)
                    .HasColumnName("pd_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PdAdId)
                    .HasColumnName("pd_ad_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PdDate)
                    .HasColumnName("pd_date")
                    .HasColumnType("date");

                entity.Property(e => e.PdDdate)
                    .HasColumnName("pd_ddate")
                    .HasColumnType("date");

                entity.Property(e => e.PdOrderNo)
                    .HasColumnName("pd_order_no")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PdQty)
                    .HasColumnName("pd_qty")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PdStatus)
                    .HasColumnName("pd_status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PdTypeId)
                    .HasColumnName("pd_type_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PdVendorId)
                    .HasColumnName("pd_vendor_id")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.PdAd)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.PdAdId)
                    .HasConstraintName("fk_assetdef1");

                entity.HasOne(d => d.PdVendor)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.PdVendorId)
                    .HasConstraintName("fk_vendor1");
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserRegi__B51D3DEA4DB4101B");

                entity.Property(e => e.UId)
                    .HasColumnName("u_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId)
                    .HasColumnName("l_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("fk_login");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VdId)
                    .HasName("PK__Vendor__277BC6C03CDCD093");

                entity.Property(e => e.VdId)
                    .HasColumnName("vd_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VdAddress)
                    .HasColumnName("vd_address")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VdAtypeId)
                    .HasColumnName("vd_atype_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VdFrom)
                    .HasColumnName("vd_from")
                    .HasColumnType("date");

                entity.Property(e => e.VdName)
                    .HasColumnName("vd_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VdTo)
                    .HasColumnName("vd_to")
                    .HasColumnType("date");

                entity.Property(e => e.VdType)
                    .HasColumnName("vd_type")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.VdAtype)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.VdAtypeId)
                    .HasConstraintName("fk_assettype2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
