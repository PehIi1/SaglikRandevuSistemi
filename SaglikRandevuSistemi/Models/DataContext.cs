using Microsoft.EntityFrameworkCore;

namespace SaglikRandevuSistemi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base( options ) { }

        public DbSet<Cinsiyetler> Cinsiyetlers { get; set; }
        public DbSet<Doktorlar> Doktorlars { get; set; }
        public DbSet<Hastalar> Hastalars { get; set; }
        public DbSet<HastaneKlinikleri> HastaneKlinikleris { get; set; }
        public DbSet<Hastaneler> Hastanelers { get; set; }
        public DbSet<Ilceler> Ilcelers { get; set; }
        public DbSet<Klinikler> Kliniklers { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<RandevuDurumlari> RandevuDurumlaris { get; set; }
        public DbSet<Randevular> Randevulars { get; set; }
        public DbSet<RandevuSaatleri> RandevuSaatleris { get; set; }
        public DbSet<Roller> Rollers { get; set; }
        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<Randevu> Randevu { get; set; }
        public DbSet<DrOptions> DrOptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Randevu>(entity =>
            {
                // Primary Key: Randevular Tablosunun Primary Key'i 'RandID' olarak belirlenmiş
                entity.HasKey(r => r.RandID);
                entity.Property(r => r.RandID).ValueGeneratedOnAdd();  // 'RandID' otomatik olarak artacak.

                // Nullable Alanlar için gerekli yapılandırmalar
                entity.Property(r => r.HastaID).IsRequired(false);  // HastaID nullable
                entity.Property(r => r.DoktorID).IsRequired(false); // DoktorID nullable
                entity.Property(r => r.HastaneID).IsRequired(false); // HastaneID nullable
                entity.Property(r => r.RandSaatID).IsRequired(false); // RandSaatID nullable
                entity.Property(r => r.RandDurumID).IsRequired(false); // RandDurumID nullable
                entity.Property(r => r.KlinikID).IsRequired(false); // KlinikID nullable
                entity.Property(r => r.RandevuGun); // KlinikID nullable
            });

            modelBuilder.Entity<DrOptions>(entity =>
            {
                entity.HasKey(r => r.OptionsID);
                entity.Property(r => r.OptionsID).ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Cinsiyetler>() // Cinsiyetler'in primary keyi
                .HasKey(c => c.CinsiyetID);


            modelBuilder.Entity<Doktorlar>(entity =>
            {
                entity.HasKey(d => d.DrID); // Doktorlar'in primary keyi
                entity.Property(d => d.DrID).ValueGeneratedOnAdd(); // Primary keye serial ozelligi ekleme
            });
            modelBuilder.Entity<Doktorlar>() // Doktorlar ve cinsiyetler iliskisi
                .HasOne(d => d.Cinsiyetler)
                .WithMany(c => c.Doktorlars)
                .HasForeignKey(d => d.CinsiyetID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Doktorlar>() // Doktorlar ve klinikler iliskisi
                .HasOne(d => d.Klinikler)
                .WithMany(kl => kl.Doktorlars)
                .HasForeignKey(d => d.KlinikID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Doktorlar>() // Doktorlar ve Hastaneler iliskisi
                .HasOne(d => d.Hastaneler)
                .WithMany(hs => hs.Doktorlars)
                .HasForeignKey(d => d.HastaneID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Doktorlar>() // Doktorlar ve Kullanicilar iliskisi (birebir)
                .HasOne(d => d.Kullanicilar)
                .WithOne(ku => ku.Doktorlar)
                .HasForeignKey<Doktorlar>(d => d.KullaniciID);


            modelBuilder.Entity<Hastalar>(entity =>
            {
                entity.HasKey(h => h.HastaID); // Hastalar'in primary keyi
                entity.Property(h => h.HastaID).ValueGeneratedOnAdd(); // Primary keye serial ozelligi ekleme
            });
            modelBuilder.Entity<Hastalar>() // Hastalar ve cinsiyetler iliskisi
                .HasOne(h => h.Cinsiyetler)
                .WithMany(c => c.Hastalars)
                .HasForeignKey(h => h.CinsiyetID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Hastalar>() // Hastalar ve ilceler iliskisi
                .HasOne(h => h.Ilceler)
                .WithMany(i => i.Hastalars)
                .HasForeignKey(h => h.IlceID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Hastalar>() // Hastalar ve sehirler iliskisi
                .HasOne(h => h.Sehirler)
                .WithMany(s => s.Hastalars)
                .HasForeignKey(h => h.SehirID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Hastalar>() // Hastalar ve kullanicilar iliskisi (birebir)
                .HasOne(h => h.Kullanicilar)
                .WithOne(ku => ku.Hastalar)
                .HasForeignKey<Hastalar>(h => h.KullaniciID);


            modelBuilder.Entity<HastaneKlinikleri>() // Hastaneklinikleri'nin bilesik primary keyi
                .HasKey(hk => new {hk.HastaneID, hk.KlinikID});
            modelBuilder.Entity<HastaneKlinikleri>() // Hastaneklinikleri ve Hastaneler iliskisi (hastaneler ve klinikler arasindaki coka cok)
                .HasOne(hk => hk.Hastaneler)
                .WithMany(hs => hs.HastaneKlinikleris)
                .HasForeignKey(hk => hk.HastaneID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HastaneKlinikleri>() // Hastaneklinikleri ve Klinikler iliskisi (hastaneler ve klinikler arasindaki coka cok)
                .HasOne(hk => hk.Klinikler)
                .WithMany(kl => kl.HastaneKlinikleris)
                .HasForeignKey(hk => hk.KlinikID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Hastaneler>(entity =>
            {
                entity.HasKey(hs => hs.HastaneID); // Hastaneler'in primary keyi
                entity.Property(hs => hs.HastaneID).ValueGeneratedOnAdd(); // Primary keye serial ozelligi ekleme
            });
            modelBuilder.Entity<Hastaneler>() // Hastaneler ve ilceler iliskisi
                .HasOne(hs => hs.Ilceler)
                .WithMany(i => i.Hastanelers)
                .HasForeignKey(hs => hs.IlceID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Hastaneler>() // Hastaneler ve sehirler iliskisi
                .HasOne(hs => hs.Sehirler)
                .WithMany(s => s.Hastanelers)
                .HasForeignKey(hs => hs.SehirID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Ilceler>(entity =>
            {
                entity.HasKey(i => i.IlceID); // Ilceler'in primary keyi
                entity.Property(i => i.IlceID).ValueGeneratedOnAdd(); // Primary keye serial ozelligi ekleme
            });
            modelBuilder.Entity<Ilceler>() // Ilceler ve Sehirler iliskisi
                .HasOne(i => i.Sehirler)
                .WithMany(s => s.Ilcelers)
                .HasForeignKey(i => i.SehirID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Klinikler>(entity =>
            {
                entity.HasKey(kl => kl.KlinikID); // Klinikler'in primary keyi
                entity.Property(kl => kl.KlinikID).ValueGeneratedOnAdd(); // Primary keye serial ozelligi ekleme
            });


            modelBuilder.Entity<Kullanicilar>(entity =>
            {
                entity.HasKey(ku => ku.KullaniciID); // Kullanicilar'in primary keyi
                entity.Property(ku => ku.KullaniciID).ValueGeneratedOnAdd(); // Primary keye serial ozelligi ekleme
            });
            modelBuilder.Entity<Kullanicilar>() // Kullanicilar ve Roller iliskisi
                .HasOne(ku => ku.Roller)
                .WithMany(rol => rol.Kullanicilars)
                .HasForeignKey(ku =>  ku.RolID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RandevuDurumlari>() // RandevuDurumlari'nin primary keyi
                .HasKey(rd => rd.RandDurumID);


            modelBuilder.Entity<Randevular>() // Randevular'in Primary keyi
                .HasKey(r =>  r.RandID);

            modelBuilder.Entity<Randevular>() // Randevular ve Doktorlar iliskisi
                .HasOne(r => r.Doktorlar)
                .WithMany(d => d.Randevulars)
                .HasForeignKey(r => r.DoktorID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Randevular>() // Randevular ve Hastalar iliskisi
                .HasOne(r => r.Hastalar)
                .WithMany(h => h.Randevulars)
                .HasForeignKey(r => r.HastaID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Randevular>() // Randevular ve Hastaneler iliskisi
                .HasOne(r => r.Hastaneler)
                .WithMany(hs => hs.Randevulars)
                .HasForeignKey(r => r.HastaneID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Randevular>() // Randevular ve Klinikler iliskisi
                .HasOne(r => r.Klinikler)
                .WithMany(kl => kl.Randevulars)
                .HasForeignKey(r => r.KlinikID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Randevular>() // Randevular ve RandevuDurumlari iliskisi
                .HasOne(r => r.RandevuDurumlari)
                .WithMany(rd => rd.Randevulars)
                .HasForeignKey(r => r.RandDurumID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Randevular>() // Randevular ve RandevuSaatleri iliskisi
                .HasOne(r => r.RandevuSaatleri)
                .WithMany(rs => rs.Randevulars)
                .HasForeignKey(r => r.RandSaatID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RandevuSaatleri>() // RandevuSaatleri'nin primary keyi
                .HasKey(rs => rs.RandSaatID);


            modelBuilder.Entity<Roller>() // Roller'in primary keyi
                .HasKey(rol => rol.RolID);


            modelBuilder.Entity<Sehirler>() // Sehirler'in primary keyi
                .HasKey(s => s.SehirID);

        }

    }
}
