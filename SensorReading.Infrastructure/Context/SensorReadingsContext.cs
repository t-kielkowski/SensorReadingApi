using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SensorReading.Domain.Models;

namespace SensorReading.InfrastructureChart
{
    public partial class SensorReadingsContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public SensorReadingsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region DbSet

        public virtual DbSet<CentralGateway> CentralGateways { get; set; }
        public virtual DbSet<GatewayInformation> GatewayInformations { get; set; }
        public virtual DbSet<Sht31> Sht31s { get; set; }
        public virtual DbSet<Sht31test> Sht31tests { get; set; }
        public virtual DbSet<WeightReading> WeightReadings { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Configuration.GetConnectionString("MySqlDatabase");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<CentralGateway>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("CentralGateway");

                entity.HasIndex(e => e.GatewayId, "GatewayId");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");
                entity.Property(e => e.BatteryLevel).HasMaxLength(6);
                entity.Property(e => e.Bh1750Luks)
                    .HasMaxLength(10)
                    .HasColumnName("BH1750_Luks");
                entity.Property(e => e.Bmp280Pressure)
                    .HasMaxLength(10)
                    .HasColumnName("BMP280_Pressure");
                entity.Property(e => e.Bmp280Temperature)
                    .HasMaxLength(10)
                    .HasColumnName("BMP280_Temperature");
                entity.Property(e => e.GatewayId).HasMaxLength(15);
                entity.Property(e => e.ReadingTime)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp");
                entity.Property(e => e.Sht31Moisture)
                    .HasMaxLength(10)
                    .HasColumnName("SHT31_Moisture");
                entity.Property(e => e.Sht31Temperature)
                    .HasMaxLength(10)
                    .HasColumnName("SHT31_Temperature");
                entity.Property(e => e.SoilMoisture).HasMaxLength(10);

                entity.HasOne(d => d.Gateway).WithMany(p => p.CentralGateways)
                    .HasForeignKey(d => d.GatewayId)
                    .HasConstraintName("CentralGateway_ibfk_1");
            });

            modelBuilder.Entity<GatewayInformation>(entity =>
            {
                entity.HasKey(e => e.GatewayId).HasName("PRIMARY");

                entity.ToTable("GatewayInformation");

                entity.Property(e => e.GatewayId).HasMaxLength(15);
                entity.Property(e => e.Latitude).HasMaxLength(10);
                entity.Property(e => e.Longitude).HasMaxLength(10);
            });

            modelBuilder.Entity<Sht31>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("SHT31");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");
                entity.Property(e => e.Moisture).HasMaxLength(10);
                entity.Property(e => e.ReadingTime)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp");
                entity.Property(e => e.Temperature).HasMaxLength(10);
            });

            modelBuilder.Entity<Sht31test>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("SHT31TEST");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");
                entity.Property(e => e.BatteryLevel).HasMaxLength(6);
                entity.Property(e => e.Moisture).HasMaxLength(10);
                entity.Property(e => e.ReadingTime)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp");
                entity.Property(e => e.Sensor).HasMaxLength(10);
                entity.Property(e => e.Temperature).HasMaxLength(10);
            });

            modelBuilder.Entity<WeightReading>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.Property(e => e.Id).HasColumnType("int(6) unsigned");
                entity.Property(e => e.BatteryLevel).HasMaxLength(6);
                entity.Property(e => e.Moisture).HasMaxLength(10);
                entity.Property(e => e.ReadingTime)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("current_timestamp()")
                    .HasColumnType("timestamp");
                entity.Property(e => e.Temperature).HasMaxLength(10);
                entity.Property(e => e.Weight).HasMaxLength(10);
                entity.Property(e => e.WeightId).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
