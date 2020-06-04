using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminAPI2.Models
{
    public partial class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext()
        {
        }

        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountDetails> AccountDetails { get; set; }
        public virtual DbSet<ActiveSessions> ActiveSessions { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<BoardInstruments> BoardInstruments { get; set; }
        public virtual DbSet<Boards> Boards { get; set; }
        public virtual DbSet<ClearingAccounts> ClearingAccounts { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<DealerAccounts> DealerAccounts { get; set; }
        public virtual DbSet<Deals> Deals { get; set; }
        public virtual DbSet<Fee> Fee { get; set; }
        public virtual DbSet<Interests> Interests { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Margins> Margins { get; set; }
        public virtual DbSet<MarketMakers> MarketMakers { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Reason> Reason { get; set; }
        public virtual DbSet<RefPrice> RefPrice { get; set; }
        public virtual DbSet<Securities> Securities { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Spreads> Spreads { get; set; }
        public virtual DbSet<TickSizeTable> TickSizeTable { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Ttable> Ttable { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=172.16.1.100;Database=MainDatabase;user id=sa;password=P@ssw0rd@MSX;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccNumber)
                    .HasColumnName("accNumber")
                    .HasMaxLength(16);

                entity.Property(e => e.AccountType).HasColumnName("accountType");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Mask)
                    .HasColumnName("mask")
                    .HasMaxLength(20);

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<AccountDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.FreezeValue)
                    .HasColumnName("freezeValue")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<ActiveSessions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Sessionid });

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");

                entity.Property(e => e.Endtime).HasColumnName("endtime");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Matched).HasColumnName("matched");

                entity.Property(e => e.Starttime).HasColumnName("starttime");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Tduration).HasColumnName("tduration");
            });

            modelBuilder.Entity<Assets>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(16);

                entity.Property(e => e.ExpireDate).HasColumnName("expireDate");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Ratio)
                    .HasColumnName("ratio")
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Volume).HasColumnName("volume");
            });

            modelBuilder.Entity<BoardInstruments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Boardid).HasColumnName("boardid");

                entity.Property(e => e.Instrumentid).HasColumnName("instrumentid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<Boards>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DealType).HasColumnName("dealType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1024);

                entity.Property(e => e.ExpDate).HasColumnName("expDate");

                entity.Property(e => e.ExpTime).HasColumnName("expTime");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Tdays)
                    .IsRequired()
                    .HasColumnName("tdays")
                    .HasMaxLength(128)
                    .HasComment("0,1,3,4,5,6");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasComment("week, workdays ");
            });

            modelBuilder.Entity<ClearingAccounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(10);

                entity.Property(e => e.Blnc)
                    .HasColumnName("blnc")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.Linkaccount).HasColumnName("linkaccount");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sblnc)
                    .HasColumnName("sblnc")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(16);

                entity.Property(e => e.Edate)
                    .HasColumnName("edate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupId).HasColumnName("groupId");

                entity.Property(e => e.Lot)
                    .HasColumnName("lot")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MmorderLimit).HasColumnName("mmorderLimit");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderLimit).HasColumnName("orderLimit");

                entity.Property(e => e.RefpriceParam)
                    .HasColumnName("refpriceParam")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Sdate)
                    .HasColumnName("sdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SecurityId).HasColumnName("securityId");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TickTable).HasColumnName("tickTable");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<DealerAccounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<Deals>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.Boardid).HasColumnName("boardid");

                entity.Property(e => e.Connect)
                    .HasColumnName("connect")
                    .HasMaxLength(16);

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.DealType).HasColumnName("dealType");

                entity.Property(e => e.Dealno)
                    .HasColumnName("dealno")
                    .HasMaxLength(16);

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Interests)
                    .HasColumnName("interests")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.M2m)
                    .HasColumnName("m2m")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.RefPrice)
                    .HasColumnName("refPrice")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Side).HasColumnName("side");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.ToPay)
                    .HasColumnName("toPay")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("totalPrice")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Value).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Interests>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.Interest)
                    .HasColumnName("interest")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LoanInterset)
                    .HasColumnName("loanInterset")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MaxValue)
                    .HasColumnName("maxValue")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MinValue)
                    .HasColumnName("minValue")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.RepoInterset)
                    .HasColumnName("repoInterset")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.DealNo).HasColumnName("dealNo");

                entity.Property(e => e.Invoiceid).HasColumnName("invoiceid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Invoiceno })
                    .HasName("PK_invoices");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Invoiceno)
                    .HasColumnName("invoiceno")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(datepart(nanosecond,getdate()))");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.Boardid).HasColumnName("boardid");

                entity.Property(e => e.DealType).HasColumnName("dealType");

                entity.Property(e => e.Dealno).HasColumnName("dealno");

                entity.Property(e => e.Expiredate)
                    .HasColumnName("expiredate")
                    .HasColumnType("date");

                entity.Property(e => e.Expiretime).HasColumnName("expiretime");

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Invoicedate)
                    .HasColumnName("invoicedate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Side).HasColumnName("side");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("totalPrice")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Margins>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.Property(e => e.ContractId).HasColumnName("contractId");

                entity.Property(e => e.Buy)
                    .HasColumnName("buy")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Buytype).HasColumnName("buytype");

                entity.Property(e => e.Coid).HasColumnName("coid");

                entity.Property(e => e.Mbuy)
                    .HasColumnName("mbuy")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Msell)
                    .HasColumnName("msell")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Sell)
                    .HasColumnName("sell")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Selltype).HasColumnName("selltype");
            });

            modelBuilder.Entity<MarketMakers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Contactid).HasColumnName("contactid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Orderlimit).HasColumnName("orderlimit");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Ticks)
                    .HasColumnName("ticks")
                    .HasDefaultValueSql("((10))");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ander).HasColumnName("ander");

                entity.Property(e => e.Broker).HasColumnName("broker");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(6);

                entity.Property(e => e.Dealer).HasColumnName("dealer");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.LinkMember).HasColumnName("linkMember");

                entity.Property(e => e.Mask)
                    .HasColumnName("mask")
                    .HasMaxLength(20);

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Nominal).HasColumnName("nominal");

                entity.Property(e => e.Partid).HasColumnName("partid");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.Assetid2).HasColumnName("assetid2");

                entity.Property(e => e.BoardId).HasColumnName("boardId");

                entity.Property(e => e.Connect)
                    .HasColumnName("connect")
                    .HasMaxLength(20);

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.DealType).HasColumnName("dealType");

                entity.Property(e => e.Fee)
                    .HasColumnName("fee")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Interests)
                    .HasColumnName("interests")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Qty2).HasColumnName("qty2");

                entity.Property(e => e.Side).HasColumnName("side");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.ToPay)
                    .HasColumnName("toPay")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TotSum)
                    .HasColumnName("totSum")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Participants>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyType).HasColumnName("companyType");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Csid).HasColumnName("csid");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Numofemp)
                    .HasColumnName("numofemp")
                    .HasMaxLength(20);

                entity.Property(e => e.Pcity)
                    .HasColumnName("pcity")
                    .HasMaxLength(20);

                entity.Property(e => e.Pdistr)
                    .HasColumnName("pdistr")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(30);

                entity.Property(e => e.Phoroo)
                    .HasColumnName("phoroo")
                    .HasMaxLength(20);

                entity.Property(e => e.Pstreet)
                    .HasColumnName("pstreet")
                    .HasMaxLength(100);

                entity.Property(e => e.Pwebpage)
                    .HasColumnName("pwebpage")
                    .HasMaxLength(50);

                entity.Property(e => e.SpecialType).HasColumnName("specialType");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Webid).HasColumnName("webid");
            });

            modelBuilder.Entity<Reason>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RefPrice>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.Property(e => e.ContractId)
                    .HasColumnName("contractId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Refprice1)
                    .HasColumnName("refprice")
                    .HasColumnType("decimal(18, 6)");
            });

            modelBuilder.Entity<Securities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(16);

                entity.Property(e => e.Edate)
                    .HasColumnName("edate")
                    .HasColumnType("date");

                entity.Property(e => e.FirstPrice)
                    .HasColumnName("firstPrice")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.IntRate)
                    .HasColumnName("intRate")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Partid).HasColumnName("partid");

                entity.Property(e => e.Sdate)
                    .HasColumnName("sdate")
                    .HasColumnType("date");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.TotalQty).HasColumnName("totalQty");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Algorithm).HasColumnName("algorithm");

                entity.Property(e => e.Allowedtypes).HasColumnName("allowedtypes");

                entity.Property(e => e.Boardid).HasColumnName("boardid");

                entity.Property(e => e.Delorder).HasColumnName("delorder");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1024);

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Editorder).HasColumnName("editorder");

                entity.Property(e => e.Endtime)
                    .HasColumnName("endtime")
                    .HasColumnType("date");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Markettype).HasColumnName("markettype");

                entity.Property(e => e.Match).HasColumnName("match");

                entity.Property(e => e.Matched).HasColumnName("matched");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasColumnType("date");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Stime).HasColumnName("stime");

                entity.Property(e => e.Tduration)
                    .HasColumnName("tduration")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Spreads>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contractid).HasColumnName("contractid");

                entity.Property(e => e.Ispread).HasColumnName("ispread");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rparam).HasColumnName("rparam");

                entity.Property(e => e.Rspread).HasColumnName("rspread");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");
            });

            modelBuilder.Entity<TickSizeTable>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AssetId).HasColumnName("assetId");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(20);

                entity.Property(e => e.Memberid).HasColumnName("memberid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Tdate)
                    .HasColumnName("tdate")
                    .HasColumnType("date");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Type1).HasColumnName("type1");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Ttable>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArrangePrice)
                    .HasColumnName("arrangePrice")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Assetid).HasColumnName("assetid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.TickSize)
                    .HasColumnName("tickSize")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MemId).HasColumnName("memId");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50);

                entity.Property(e => e.ServerDatabase)
                    .HasColumnName("serverDatabase")
                    .HasMaxLength(30);

                entity.Property(e => e.ServerPassword)
                    .HasColumnName("serverPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.ServerUname)
                    .HasColumnName("serverUname")
                    .HasMaxLength(30);

                entity.Property(e => e.Serverip)
                    .HasColumnName("serverip")
                    .HasMaxLength(30);

                entity.Property(e => e.Uname)
                    .HasColumnName("uname")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
