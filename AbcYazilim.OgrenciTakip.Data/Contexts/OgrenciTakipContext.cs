using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Emit;
using AbcYazilim.OgrenciTakip.Data.OgrenciTakipMigration;
using AbcYazilim.OgrenciTakip.Model.Entities;

namespace AbcYazilim.OgrenciTakip.Data.Contexts
{
    public class OgrenciTakipContext : BaseDbContext<OgrenciTakipContext, Configuration>
    {
        public OgrenciTakipContext()  //: base("name=OgrenciTakipContext") bu ilemi iptal ettik ��nk� baseDbContext te bu i�lemi yapt�k.
        {
            // �imdi burda okul entity sini d���n orda baz prop lar var bu proplar� select yaparken bunlar gelicek ama i�inde Il Il ve Ilce Ilce �eklinde de prop lar�m oldu�u i�in
            // b�t�n illeri ve il�eleri getirmek isticek. Buda bana yava�latma kazand�r�cak bu y�zden bu i�lemi false yap�yorum.
            // Performans kayb�na sebeb oluyor ve select i�leminin uzun s�rmesine sebeb oluyor.
            Configuration.LazyLoadingEnabled = false;
        }

        // bu constuctor un anlam� ise basedb �al��t��� anda bu constructoruda �al��t�rs�n diye
        public OgrenciTakipContext(string connectionString) : base(connectionString: connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // PluralizingTableNameConvention i�lemi database e bizim entity lerimizi �o�ul ek alarak gitmesini sa�l�yor ama biz burda bunu istemiyoruz o y�zden onu siliyoruz.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 1 e �ok ili�kili tablolarda mesela il il�e tablosu ben bursay� sildim otomatik bursan�n il�eleride gidiyor ama ben a�a��daki i�lemi silerek bunu engelledim.
            // bu i�lemi heryere de�il baz� yerlerde �zel tan�mlamalar yap�caz.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // yukar�dakinin ayn�s� �ok a �ok tablolarda
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        #region DbSet<>

        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }

        #endregion
    }
}

