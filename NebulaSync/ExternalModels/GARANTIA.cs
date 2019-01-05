using System.Data.Entity;
namespace NebulaSync.ExternalModels
{

    public partial class GARANTIA : DbContext
    {
        public GARANTIA()
            : base("name=GARANTIA")
        {
        }

        public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public virtual DbSet<CashBook> CashBooks { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrenciesHistory> CurrenciesHistories { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<ECRReceipt> ECRReceipts { get; set; }
        public virtual DbSet<EGAISExcise> EGAISExcises { get; set; }
        public virtual DbSet<EGAISObjectRegistration> EGAISObjectRegistrations { get; set; }
        public virtual DbSet<EGAISOperationsEx> EGAISOperationsExes { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<GoodsGroup> GoodsGroups { get; set; }
        public virtual DbSet<InternalLog> InternalLogs { get; set; }
        public virtual DbSet<Lot> Lots { get; set; }
        public virtual DbSet<Network> Networks { get; set; }
        public virtual DbSet<NextAcct> NextAccts { get; set; }
        public virtual DbSet<Objec> Objects { get; set; }
        public virtual DbSet<ObjectsGroup> ObjectsGroups { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<OperationType> OperationTypes { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<PartnersGroup> PartnersGroups { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PriceRule> PriceRules { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<System> Systems { get; set; }
        public virtual DbSet<Transformation> Transformations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersGroup> UsersGroups { get; set; }
        public virtual DbSet<UsersSecurity> UsersSecurities { get; set; }
        public virtual DbSet<VATGroup> VATGroups { get; set; }
        public virtual DbSet<EGAISystem> EGAISystems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EGAISExcise>()
                .Property(e => e.FORMB)
                .IsUnicode(false);

            modelBuilder.Entity<EGAISExcise>()
                .Property(e => e.FORMA)
                .IsUnicode(false);

            modelBuilder.Entity<EGAISExcise>()
                .Property(e => e.Excise)
                .IsUnicode(false);

            modelBuilder.Entity<EGAISOperationsEx>()
                .Property(e => e.FORMA)
                .IsUnicode(false);

            modelBuilder.Entity<EGAISOperationsEx>()
                .Property(e => e.FORMB)
                .IsUnicode(false);

            modelBuilder.Entity<EGAISystem>()
                .Property(e => e.Version)
                .IsUnicode(false);
        }
    }
}
