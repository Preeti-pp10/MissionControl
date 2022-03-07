using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class MissionControlContext : DbContext
    {
        public MissionControlContext()
        {
        }

        public MissionControlContext(DbContextOptions<MissionControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DwhPeriod> DwhPeriods { get; set; } = null!;
        public virtual DbSet<McAppCustomerAggregation> McAppCustomerAggregations { get; set; } = null!;
        public virtual DbSet<McAppCustomerAggregationAudit> McAppCustomerAggregationAudits { get; set; } = null!;
        public virtual DbSet<Method> Methods { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderAudit> OrderAudits { get; set; } = null!;
        public virtual DbSet<OrderRemap> OrderRemaps { get; set; } = null!;
        public virtual DbSet<RoleAccessMapping> RoleAccessMappings { get; set; } = null!;
        public virtual DbSet<SbodbCustomerAggregationFy22Update> SbodbCustomerAggregationFy22Updates { get; set; } = null!;
        public virtual DbSet<SbodwV5SalesLeaderHierarchyV> SbodwV5SalesLeaderHierarchyVs { get; set; } = null!;
        public virtual DbSet<StandardReason> StandardReasons { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<V5McAppAdminModule> V5McAppAdminModules { get; set; } = null!;
        public virtual DbSet<V5McAppAdminModuleRoleAccessMapping> V5McAppAdminModuleRoleAccessMappings { get; set; } = null!;
        public virtual DbSet<V5McAppAdminRole> V5McAppAdminRoles { get; set; } = null!;
        public virtual DbSet<V5McAppAdminSystemUserRole> V5McAppAdminSystemUserRoles { get; set; } = null!;
        public virtual DbSet<V5McAppAdminUser> V5McAppAdminUsers { get; set; } = null!;
        public virtual DbSet<V5McAppConfigFunnelCoverage> V5McAppConfigFunnelCoverages { get; set; } = null!;
        public virtual DbSet<V5McAppConfigFunnelCoverageAudit> V5McAppConfigFunnelCoverageAudits { get; set; } = null!;
        public virtual DbSet<V5McAppCustomerAggregation> V5McAppCustomerAggregations { get; set; } = null!;
        public virtual DbSet<V5McAppCustomerAggregationAudit> V5McAppCustomerAggregationAudits { get; set; } = null!;
        public virtual DbSet<V5McAppOrderSplitBookingsAdjustment> V5McAppOrderSplitBookingsAdjustments { get; set; } = null!;
        public virtual DbSet<V5McAppOrderSplitBookingsAdjustmentsAudit> V5McAppOrderSplitBookingsAdjustmentsAudits { get; set; } = null!;
        public virtual DbSet<V5McAppReportPeriod> V5McAppReportPeriods { get; set; } = null!;
        public virtual DbSet<V5McAppReportPeriodAudit> V5McAppReportPeriodAudits { get; set; } = null!;
        public virtual DbSet<V5McAppReportStatus> V5McAppReportStatuses { get; set; } = null!;
        public virtual DbSet<V5McAppReportStatusAudit> V5McAppReportStatusAudits { get; set; } = null!;
        public virtual DbSet<V5McAppSbodbReportStatus> V5McAppSbodbReportStatuses { get; set; } = null!;
        public virtual DbSet<V5McAppSbodwReportPeriod> V5McAppSbodwReportPeriods { get; set; } = null!;
        public virtual DbSet<V5McAppUpdateReportPeriod> V5McAppUpdateReportPeriods { get; set; } = null!;
        public virtual DbSet<V5McAppUpdateReportPeriodAudit> V5McAppUpdateReportPeriodAudits { get; set; } = null!;
        public virtual DbSet<V5ShDftFy19> V5ShDftFy19s { get; set; } = null!;
        public virtual DbSet<V6DwhBookingsOracleNVia> V6DwhBookingsOracleNVias { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JUFTQM0\\SQLEXPRESS;Database=MissionControl;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DwhPeriod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_periods");

                entity.Property(e => e.Period)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD");

                entity.Property(e => e.PeriodEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PERIOD_END_DATE");

                entity.Property(e => e.PeriodKey)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_KEY");

                entity.Property(e => e.PeriodName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_NAME");

                entity.Property(e => e.PeriodStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PERIOD_START_DATE");

                entity.Property(e => e.PeriodType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PERIOD_TYPE");

                entity.Property(e => e.Quarter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("QUARTER");

                entity.Property(e => e.QuarterStartDate)
                    .HasPrecision(0)
                    .HasColumnName("QUARTER_START_DATE");

                entity.Property(e => e.Year).HasColumnName("YEAR");

                entity.Property(e => e.YearPeriod)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("YEAR_PERIOD");

                entity.Property(e => e.YearQuarter)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("YEAR_QUARTER");

                entity.Property(e => e.YearStartDate)
                    .HasPrecision(0)
                    .HasColumnName("YEAR_START_DATE");
            });

            modelBuilder.Entity<McAppCustomerAggregation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MC_App_Customer_Aggregation");

                entity.Property(e => e.AggregatedCustomer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("aggregated_customer");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Customer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customer");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("entry_date");

                entity.Property(e => e.FiscalYear)
                    .HasMaxLength(25)
                    .HasColumnName("fiscal_year");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_on");
            });

            modelBuilder.Entity<McAppCustomerAggregationAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MC_App_Customer_Aggregation_Audit");

                entity.Property(e => e.AggregatedCustomer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("aggregated_customer");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Customer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customer");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("entry_date");

                entity.Property(e => e.FiscalYear)
                    .HasMaxLength(25)
                    .HasColumnName("fiscal_year");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).HasMaxLength(25);
            });

            modelBuilder.Entity<Method>(entity =>
            {
                entity.Property(e => e.Method1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Method");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ActualShipmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ACTUAL_SHIPMENT_DATE");

                entity.Property(e => e.ArInvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AR_INVOICE_NUMBER");

                entity.Property(e => e.BilltoAddr1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR1");

                entity.Property(e => e.BilltoAddr2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR2");

                entity.Property(e => e.BilltoAddr3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR3");

                entity.Property(e => e.BilltoAddr4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR4");

                entity.Property(e => e.BilltoCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_CITY");

                entity.Property(e => e.BilltoCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_COUNTRY");

                entity.Property(e => e.BilltoCountryDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_COUNTRY_DESC");

                entity.Property(e => e.BilltoId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ID");

                entity.Property(e => e.BilltoName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_NAME");

                entity.Property(e => e.BilltoState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_STATE");

                entity.Property(e => e.BilltoZip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ZIP");

                entity.Property(e => e.CatalogPartNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATALOG_PART_NUMBER");

                entity.Property(e => e.CcAmtGlAcctBalActCogs).HasColumnName("CC_AMT_GL_ACCT_BAL_ACT_COGS");

                entity.Property(e => e.CcAmtGlAcctBalActRev).HasColumnName("CC_AMT_GL_ACCT_BAL_ACT_REV");

                entity.Property(e => e.CcAmtGrossBookings).HasColumnName("CC_AMT_GROSS_BOOKINGS");

                entity.Property(e => e.CcCurrency)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CC_CURRENCY");

                entity.Property(e => e.CcExchangeRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("CC_EXCHANGE_RATE");

                entity.Property(e => e.CcUnitListPrice).HasColumnName("CC_UNIT_LIST_PRICE");

                entity.Property(e => e.CcUnitSellingPrice).HasColumnName("CC_UNIT_SELLING_PRICE");

                entity.Property(e => e.ContractorEndCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_END_CUSTOMER");

                entity.Property(e => e.CustomerClass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_CLASS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TYPE");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DATA_SOURCE");

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EID");

                entity.Property(e => e.EndCustClass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("END_CUST_CLASS");

                entity.Property(e => e.EndCustomerClass)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_CLASS");

                entity.Property(e => e.EndCustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_NAME");

                entity.Property(e => e.EndCustomerNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_NUMBER");

                entity.Property(e => e.EndCustomerSector)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_SECTOR");

                entity.Property(e => e.EndCustomerType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER__TYPE");

                entity.Property(e => e.FreightCarrierCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FREIGHT_CARRIER_CODE");

                entity.Property(e => e.GlAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GL_ACCOUNT");

                entity.Property(e => e.GlAccountDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GL_ACCOUNT_DESC");

                entity.Property(e => e.GlProdLineCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GL_PROD_LINE_CODE");

                entity.Property(e => e.GlProdLineDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GL_PROD_LINE_DESC");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.InventoryItem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INVENTORY_ITEM");

                entity.Property(e => e.InventoryItemDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INVENTORY_ITEM_DESC");

                entity.Property(e => e.L2MarketSegment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L2_MARKET_SEGMENT");

                entity.Property(e => e.L3BusinessGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L3_BUSINESS_GROUP");

                entity.Property(e => e.L45)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L4_5");

                entity.Property(e => e.L4BusinessUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L4_BUSINESS_UNIT");

                entity.Property(e => e.L4Edw)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L4_EDW");

                entity.Property(e => e.L5ProductLine)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L5_PRODUCT_LINE");

                entity.Property(e => e.L6ProductFamily)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("L6_PRODUCT_FAMILY");

                entity.Property(e => e.LineBookedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LINE_BOOKED_DATE");

                entity.Property(e => e.OaState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OA state");

                entity.Property(e => e.OrderHoldStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_HOLD_STATUS");

                entity.Property(e => e.OrderLineNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_LINE_NUMBER");

                entity.Property(e => e.OrderLineType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_LINE_TYPE");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.OrderPromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ORDER_PROM_DATE");

                entity.Property(e => e.PoNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PO_NUMBER");

                entity.Property(e => e.QuantityGrossBookings).HasColumnName("QUANTITY_GROSS_BOOKINGS");

                entity.Property(e => e.QuantityOrdered).HasColumnName("QUANTITY_ORDERED");

                entity.Property(e => e.QuantityShipped).HasColumnName("QUANTITY_SHIPPED");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGION");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQUEST_DATE");

                entity.Property(e => e.SalesCommissionsKey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SALES_COMMISSIONS_KEY");

                entity.Property(e => e.SalesRepName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SALES_REP_NAME");

                entity.Property(e => e.SalesRepNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SALES_REP_NUMBER");

                entity.Property(e => e.SchedShipDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SCHED_SHIP_DATE");

                entity.Property(e => e.ShipmentPriority)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPMENT_PRIORITY");

                entity.Property(e => e.ShiptoAddr1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR1");

                entity.Property(e => e.ShiptoAddr2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR2");

                entity.Property(e => e.ShiptoAddr3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR3");

                entity.Property(e => e.ShiptoAddr4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR4");

                entity.Property(e => e.ShiptoCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_CITY");

                entity.Property(e => e.ShiptoCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_COUNTRY");

                entity.Property(e => e.ShiptoId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ID");

                entity.Property(e => e.ShiptoName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_NAME");

                entity.Property(e => e.ShiptoState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_STATE");

                entity.Property(e => e.ShiptoZip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ZIP");

                entity.Property(e => e.SoldtoAddr1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR1");

                entity.Property(e => e.SoldtoAddr2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR2");

                entity.Property(e => e.SoldtoAddr3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR3");

                entity.Property(e => e.SoldtoAddr4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR4");

                entity.Property(e => e.SoldtoCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_CITY");

                entity.Property(e => e.SoldtoCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_COUNTRY");

                entity.Property(e => e.SoldtoId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ID");

                entity.Property(e => e.SoldtoName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_NAME");

                entity.Property(e => e.SoldtoState)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_STATE");

                entity.Property(e => e.SoldtoZip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ZIP");

                entity.Property(e => e.SourceSystemId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_SYSTEM_ID");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_TYPE");

                entity.Property(e => e.SubDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUB_DISTRICT");

                entity.Property(e => e.SubRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUB_REGION");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANS_DATE");

                entity.Property(e => e.TransDatePeriodName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_PERIOD_NAME");

                entity.Property(e => e.TransDateWeekEnding)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANS_DATE_WEEK_ENDING");

                entity.Property(e => e.TransDateWeekNum)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_WEEK_NUM");

                entity.Property(e => e.TransDateYearQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_YEAR_QUARTER");

                entity.Property(e => e.TtlOrderVal).HasColumnName("TTL order Val");

                entity.Property(e => e.ViasClientCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_CLIENT_CODE");

                entity.Property(e => e.ViasEndCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_END_CUSTOMER");

                entity.Property(e => e.ViasLocalCurrencyCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_LOCAL_CURRENCY_CODE");

                entity.Property(e => e.ViasMajorCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_MAJOR_CUSTOMER");

                entity.Property(e => e.ViasPartNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_PART_NUMBER");

                entity.Property(e => e.ViasSalesRepNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_SALES_REP_NO");

                entity.Property(e => e.WaybillNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WAYBILL_NUMBER");
            });

            modelBuilder.Entity<OrderAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_Audit");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.EndQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("End_Quarter");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.IsAnaplanTqm).HasColumnName("Is_Anaplan_TQM");

                entity.Property(e => e.IsApprovedMoveToNewRegion).HasColumnName("Is_Approved_Move_To_New_Region");

                entity.Property(e => e.Method)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewDistrict)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("New_District");

                entity.Property(e => e.NewRegion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("New_Region");

                entity.Property(e => e.NewSubregion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("New_Subregion");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.Period)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PO_NUMBER");

                entity.Property(e => e.Region)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REGION");

                entity.Property(e => e.RemapDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Remap_Date");

                entity.Property(e => e.RemapPerson)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Remap_Person");

                entity.Property(e => e.RemapType)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Remap_Type");

                entity.Property(e => e.SalesRepNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Sales_Rep_Number");

                entity.Property(e => e.StandardReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Standard_Reason");

                entity.Property(e => e.StartQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Start_Quarter");

                entity.Property(e => e.SubRegion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SUB_REGION");
            });

            modelBuilder.Entity<OrderRemap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_Remap");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.EndQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("End_Quarter");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsAnaplanTqm).HasColumnName("Is_Anaplan_TQM");

                entity.Property(e => e.IsApprovedMoveToNewRegion).HasColumnName("Is_Approved_Move_To_New_Region");

                entity.Property(e => e.Method)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NewDistrict)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("New_District");

                entity.Property(e => e.NewRegion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("New_Region");

                entity.Property(e => e.NewSubregion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("New_Subregion");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.Period)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PO_NUMBER");

                entity.Property(e => e.Region)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REGION");

                entity.Property(e => e.RemapDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Remap_Date");

                entity.Property(e => e.SalesRepNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Sales_Rep_Number");

                entity.Property(e => e.StandardReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Standard_Reason");

                entity.Property(e => e.StartQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Start_Quarter");

                entity.Property(e => e.SubRegion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SUB_REGION");
            });

            modelBuilder.Entity<RoleAccessMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Role_Access_Mapping");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SbodbCustomerAggregationFy22Update>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sbodb_customer_aggregation_FY22_update");

                entity.Property(e => e.AggregatedCustomer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("aggregated_customer");

                entity.Property(e => e.Customer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customer");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("entry_date");

                entity.Property(e => e.FiscalYear)
                    .HasMaxLength(25)
                    .HasColumnName("fiscal_year");
            });

            modelBuilder.Entity<SbodwV5SalesLeaderHierarchyV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sbodw_V5_Sales_Leader_Hierarchy_v");

                entity.Property(e => e.District)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Region)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("REGION");

                entity.Property(e => e.SubRegion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SUB_REGION");
            });

            modelBuilder.Entity<StandardReason>(entity =>
            {
                entity.ToTable("Standard_Reasons");

                entity.Property(e => e.StanddardReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Standdard_Reason");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_Role");

                entity.Property(e => e.No).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<V5McAppAdminModule>(entity =>
            {
                entity.ToTable("V5_MC_App_Admin_Module");

                entity.Property(e => e.ModuleCode).HasMaxLength(50);

                entity.Property(e => e.ModuleName).HasMaxLength(50);
            });

            modelBuilder.Entity<V5McAppAdminModuleRoleAccessMapping>(entity =>
            {
                entity.ToTable("V5_MC_App_Admin_Module_Role_Access_Mapping");
            });

            modelBuilder.Entity<V5McAppAdminRole>(entity =>
            {
                entity.ToTable("V5_MC_App_Admin_Roles");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.RoleCode).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<V5McAppAdminSystemUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Admin_System_User_Roles");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<V5McAppAdminUser>(entity =>
            {
                entity.ToTable("V5_MC_App_Admin_Users");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<V5McAppConfigFunnelCoverage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Config_Funnel_Coverage");

                entity.Property(e => e.CurrentQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Current_Quarter");

                entity.Property(e => e.EndQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("End_Quarter");

                entity.Property(e => e.FcstYqM)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FCST_YQ_M");

                entity.Property(e => e.ForecastMonth)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Month");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.NumQtrs)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Qtrs");

                entity.Property(e => e.StartQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Start_Quarter");
            });

            modelBuilder.Entity<V5McAppConfigFunnelCoverageAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Config_Funnel_Coverage_Audit");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.CurrentQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Current_Quarter");

                entity.Property(e => e.EndQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("End_Quarter");

                entity.Property(e => e.FcId).HasColumnName("FcID");

                entity.Property(e => e.FcstYqM)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FCST_YQ_M");

                entity.Property(e => e.ForecastMonth)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Month");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.NumQtrs)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Num_Qtrs");

                entity.Property(e => e.StartQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Start_Quarter");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<V5McAppCustomerAggregation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Customer_Aggregation");

                entity.Property(e => e.AggregatedCustomer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Customer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.FiscalYear).HasMaxLength(25);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<V5McAppCustomerAggregationAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Customer_Aggregation_Audit");

                entity.Property(e => e.AggregatedCustomer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Customer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.FiscalYear).HasMaxLength(25);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<V5McAppOrderSplitBookingsAdjustment>(entity =>
            {
                entity.ToTable("V5_MC_App_Order_Split_Bookings_Adjustments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bookings).HasColumnName("BOOKINGS");

                entity.Property(e => e.CcAmtGrossBookings).HasColumnName("CC_AMT_GROSS_BOOKINGS");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ENTRY_BY");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRY_DATE");

                entity.Property(e => e.FiscalPeriod)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FISCAL_PERIOD");

                entity.Property(e => e.L3BusinessGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L3_BUSINESS_GROUP");

                entity.Property(e => e.L4BusinessUnit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L4_BUSINESS_UNIT");

                entity.Property(e => e.L5ProductLine)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L5_PRODUCT_LINE");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(255)
                    .HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .HasColumnName("REGION");

                entity.Property(e => e.SplitPercent)
                    .HasMaxLength(255)
                    .HasColumnName("SPLIT_PERCENT");

                entity.Property(e => e.SplitType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SPLIT_TYPE");

                entity.Property(e => e.SubRegion)
                    .HasMaxLength(255)
                    .HasColumnName("SUB_REGION");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRANS_DATE");

                entity.Property(e => e.Transcation)
                    .HasMaxLength(255)
                    .HasColumnName("TRANSCATION");
            });

            modelBuilder.Entity<V5McAppOrderSplitBookingsAdjustmentsAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Order_Split_Bookings_Adjustments_Audit");

                entity.Property(e => e.Comments).HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CurrentCcbperiod)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CurrentCCBPeriod");

                entity.Property(e => e.CurrentDistrict).HasMaxLength(255);

                entity.Property(e => e.District1).HasMaxLength(255);

                entity.Property(e => e.District2).HasMaxLength(255);

                entity.Property(e => e.District3).HasMaxLength(255);

                entity.Property(e => e.District4).HasMaxLength(255);

                entity.Property(e => e.District5).HasMaxLength(255);

                entity.Property(e => e.FiscalPeriod)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.L3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.L5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNumber).HasMaxLength(255);

                entity.Property(e => e.OriginalBookedDate).HasColumnType("datetime");

                entity.Property(e => e.SplitPercent).HasMaxLength(255);

                entity.Property(e => e.SplitPercent1).HasMaxLength(255);

                entity.Property(e => e.SplitPercent2).HasMaxLength(255);

                entity.Property(e => e.SplitPercent3).HasMaxLength(255);

                entity.Property(e => e.SplitPercent4).HasMaxLength(255);

                entity.Property(e => e.SplitPercent5).HasMaxLength(255);

                entity.Property(e => e.SplitType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SplitValue1).HasMaxLength(255);

                entity.Property(e => e.SplitValue2).HasMaxLength(255);

                entity.Property(e => e.SplitValue3).HasMaxLength(255);

                entity.Property(e => e.SplitValue4).HasMaxLength(255);

                entity.Property(e => e.SplitValue5).HasMaxLength(255);

                entity.Property(e => e.TransDate).HasColumnType("datetime");

                entity.Property(e => e.Transaction).HasMaxLength(255);
            });

            modelBuilder.Entity<V5McAppReportPeriod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Report_Period");

                entity.Property(e => e.Active)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LastQuarterReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_quarter_report_year_period");

                entity.Property(e => e.LastReportPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_report_period");

                entity.Property(e => e.LastReportYear).HasColumnName("last_report_year");

                entity.Property(e => e.LastReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_report_year_period");

                entity.Property(e => e.LastReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_report_year_quarter");

                entity.Property(e => e.LastYearLastReportQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_year_last_report_quarter");

                entity.Property(e => e.LastYearReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_year_report_year_period");

                entity.Property(e => e.LastYearReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_year_report_year_quarter");

                entity.Property(e => e.NextReportPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("next_report_period");

                entity.Property(e => e.NextReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("next_report_year_quarter");

                entity.Property(e => e.NextYearReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("next_year_report_year_quarter");

                entity.Property(e => e.ReportPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_period");

                entity.Property(e => e.ReportYear).HasColumnName("report_year");

                entity.Property(e => e.ReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_year_period");

                entity.Property(e => e.ReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_year_quarter");
            });

            modelBuilder.Entity<V5McAppReportPeriodAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Report_Period_Audit");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.ReportPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_period");

                entity.Property(e => e.ReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_year_period");

                entity.Property(e => e.ReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_year_quarter");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<V5McAppReportStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Report_Status");

                entity.Property(e => e.Active)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ForecastQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Quarter");

                entity.Property(e => e.ForecastStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Status");

                entity.Property(e => e.ForecastYearLastPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Year_Last_Period");

                entity.Property(e => e.ForecastYearPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Year_Period");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Quarter");

                entity.Property(e => e.M1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.M2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.M3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NextQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Next_Quarter");

                entity.Property(e => e.Nm1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NM1");

                entity.Property(e => e.Nm2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NM2");

                entity.Property(e => e.Nm3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NM3");

                entity.Property(e => e.PrelimForecastYearPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Prelim_Forecast_Year_Period");

                entity.Property(e => e.ReportedForecastPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reported_Forecast_Period");

                entity.Property(e => e.ReportedForecastYearPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reported_Forecast_Year_Period");
            });

            modelBuilder.Entity<V5McAppReportStatusAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Report_Status_Audit");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.ForecastQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Quarter");

                entity.Property(e => e.ForecastYearPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Year_Period");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ReportedForecastPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reported_Forecast_Period");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<V5McAppSbodbReportStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_sbodb_report_status");

                entity.Property(e => e.ForecastQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Quarter");

                entity.Property(e => e.ForecastStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Status");

                entity.Property(e => e.ForecastYearLastPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Year_Last_Period");

                entity.Property(e => e.ForecastYearPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Forecast_Year_Period");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Quarter");

                entity.Property(e => e.M1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.M2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.M3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NextQuarter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Next_Quarter");

                entity.Property(e => e.Nm1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NM1");

                entity.Property(e => e.Nm2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NM2");

                entity.Property(e => e.Nm3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NM3");

                entity.Property(e => e.PrelimForecastYearPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Prelim_Forecast_Year_Period");

                entity.Property(e => e.ReportedForecastPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reported_Forecast_Period");

                entity.Property(e => e.ReportedForecastYearPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reported_Forecast_Year_Period");
            });

            modelBuilder.Entity<V5McAppSbodwReportPeriod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_sbodw_report_period");

                entity.Property(e => e.Active)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastQuarterReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_quarter_report_year_period");

                entity.Property(e => e.LastReportPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_report_period");

                entity.Property(e => e.LastReportYear).HasColumnName("last_report_year");

                entity.Property(e => e.LastReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_report_year_period");

                entity.Property(e => e.LastReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_report_year_quarter");

                entity.Property(e => e.LastYearLastReportQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_year_last_report_quarter");

                entity.Property(e => e.LastYearReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_year_report_year_period");

                entity.Property(e => e.LastYearReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_year_report_year_quarter");

                entity.Property(e => e.NextReportPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("next_report_period");

                entity.Property(e => e.NextReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("next_report_year_quarter");

                entity.Property(e => e.NextYearReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("next_year_report_year_quarter");

                entity.Property(e => e.ReportPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_period");

                entity.Property(e => e.ReportYear).HasColumnName("report_year");

                entity.Property(e => e.ReportYearPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_year_period");

                entity.Property(e => e.ReportYearQuarter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("report_year_quarter");
            });

            modelBuilder.Entity<V5McAppUpdateReportPeriod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Update_Report_Period");

                entity.Property(e => e.Active)
                    .HasMaxLength(5)
                    .HasColumnName("active");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TransDatePeriodName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_PERIOD_NAME");

                entity.Property(e => e.TransDateYearPeriod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_YEAR_PERIOD");

                entity.Property(e => e.TransDateYearQuarter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_YEAR_QUARTER");
            });

            modelBuilder.Entity<V5McAppUpdateReportPeriodAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_MC_App_Update_Report_Period_Audit");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_By");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TransDatePeriodName)
                    .HasMaxLength(50)
                    .HasColumnName("TRANS_DATE_PERIOD_NAME");

                entity.Property(e => e.TransDateYearPeriod)
                    .HasMaxLength(50)
                    .HasColumnName("TRANS_DATE_YEAR_PERIOD");

                entity.Property(e => e.TransDateYearQuarter)
                    .HasMaxLength(50)
                    .HasColumnName("TRANS_DATE_YEAR_QUARTER");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<V5ShDftFy19>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V5_SH_DFT_FY19");

                entity.Property(e => e.BwlAggregatedLevel)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BWL_Aggregated_Level");

                entity.Property(e => e.BwlDistrictNameChange)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BWL_DistrictNameChange");

                entity.Property(e => e.BwlTeam)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BWL_TEAM");

                entity.Property(e => e.District)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.ExrptAgg8)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EXRPT_AGG8");

                entity.Property(e => e.ExrptRegion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EXRPT_Region");

                entity.Property(e => e.ExrptSubRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXRPT_Sub_Region");

                entity.Property(e => e.Fy18District)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FY18_District");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OldDistrict)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Old_District");

                entity.Property(e => e.OldRegion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Old_Region");

                entity.Property(e => e.OldSubRegion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Old_Sub_Region");
            });

            modelBuilder.Entity<V6DwhBookingsOracleNVia>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("V6_dwh_bookings_oracle_n_vias");

                entity.Property(e => e.ActualShipmentDate)
                    .HasPrecision(0)
                    .HasColumnName("ACTUAL_SHIPMENT_DATE");

                entity.Property(e => e.ArInvoiceNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AR_INVOICE_NUMBER");

                entity.Property(e => e.BilltoAddr1)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR1");

                entity.Property(e => e.BilltoAddr2)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR2");

                entity.Property(e => e.BilltoAddr3)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR3");

                entity.Property(e => e.BilltoAddr4)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ADDR4");

                entity.Property(e => e.BilltoCity)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_CITY");

                entity.Property(e => e.BilltoCountry)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_COUNTRY");

                entity.Property(e => e.BilltoCountryDesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_COUNTRY_DESC");

                entity.Property(e => e.BilltoId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ID");

                entity.Property(e => e.BilltoName)
                    .HasMaxLength(360)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_NAME");

                entity.Property(e => e.BilltoState)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_STATE");

                entity.Property(e => e.BilltoZip)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO_ZIP");

                entity.Property(e => e.CatalogPartNumber)
                    .HasMaxLength(82)
                    .IsUnicode(false)
                    .HasColumnName("CATALOG_PART_NUMBER");

                entity.Property(e => e.CcAmtGlAcctBalActCogs).HasColumnName("CC_AMT_GL_ACCT_BAL_ACT_COGS");

                entity.Property(e => e.CcAmtGlAcctBalActRev).HasColumnName("CC_AMT_GL_ACCT_BAL_ACT_REV");

                entity.Property(e => e.CcAmtGrossBookings).HasColumnName("CC_AMT_GROSS_BOOKINGS");

                entity.Property(e => e.CcCurrency)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CC_CURRENCY");

                entity.Property(e => e.CcExchangeRate)
                    .HasColumnType("decimal(22, 5)")
                    .HasColumnName("CC_EXCHANGE_RATE");

                entity.Property(e => e.CcUnitListPrice).HasColumnName("CC_UNIT_LIST_PRICE");

                entity.Property(e => e.CcUnitSellingPrice).HasColumnName("CC_UNIT_SELLING_PRICE");

                entity.Property(e => e.ContractorEndCustomer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTOR_END_CUSTOMER");

                entity.Property(e => e.CustomerClass)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_CLASS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TYPE");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DATA_SOURCE")
                    .IsFixedLength();

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT");

                entity.Property(e => e.Eid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EID");

                entity.Property(e => e.EndCustClass)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("END_CUST_CLASS");

                entity.Property(e => e.EndCustomerClass)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_CLASS");

                entity.Property(e => e.EndCustomerName)
                    .HasMaxLength(360)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_NAME");

                entity.Property(e => e.EndCustomerNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_NUMBER");

                entity.Property(e => e.EndCustomerSector)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER_SECTOR");

                entity.Property(e => e.EndCustomerType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("END_CUSTOMER__TYPE");

                entity.Property(e => e.FreightCarrierCode)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("FREIGHT_CARRIER_CODE");

                entity.Property(e => e.GlAccount)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GL_ACCOUNT");

                entity.Property(e => e.GlAccountDesc)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("GL_ACCOUNT_DESC");

                entity.Property(e => e.GlProdLineCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GL_PROD_LINE_CODE");

                entity.Property(e => e.GlProdLineDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GL_PROD_LINE_DESC");

                entity.Property(e => e.InventoryItem)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("INVENTORY_ITEM");

                entity.Property(e => e.InventoryItemDesc)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("INVENTORY_ITEM_DESC");

                entity.Property(e => e.L2MarketSegment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L2_MARKET_SEGMENT");

                entity.Property(e => e.L3BusinessGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L3_BUSINESS_GROUP");

                entity.Property(e => e.L45)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L4_5");

                entity.Property(e => e.L4BusinessUnit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L4_BUSINESS_UNIT");

                entity.Property(e => e.L4Edw)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L4_EDW");

                entity.Property(e => e.L5ProductLine)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L5_PRODUCT_LINE");

                entity.Property(e => e.L6ProductFamily)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("L6_PRODUCT_FAMILY");

                entity.Property(e => e.LineBookedDate)
                    .HasPrecision(0)
                    .HasColumnName("LINE_BOOKED_DATE");

                entity.Property(e => e.OaState)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OA state");

                entity.Property(e => e.OrderHoldStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_HOLD_STATUS");

                entity.Property(e => e.OrderLineNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_LINE_NUMBER");

                entity.Property(e => e.OrderLineType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_LINE_TYPE");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_NUMBER");

                entity.Property(e => e.OrderPromDate)
                    .HasPrecision(0)
                    .HasColumnName("ORDER_PROM_DATE");

                entity.Property(e => e.PoNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PO_NUMBER");

                entity.Property(e => e.QuantityGrossBookings).HasColumnName("QUANTITY_GROSS_BOOKINGS");

                entity.Property(e => e.QuantityOrdered).HasColumnName("QUANTITY_ORDERED");

                entity.Property(e => e.QuantityShipped).HasColumnName("QUANTITY_SHIPPED");

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGION");

                entity.Property(e => e.RequestDate)
                    .HasPrecision(0)
                    .HasColumnName("REQUEST_DATE");

                entity.Property(e => e.SalesCommissionsKey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SALES_COMMISSIONS_KEY");

                entity.Property(e => e.SalesRepName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SALES_REP_NAME");

                entity.Property(e => e.SalesRepNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SALES_REP_NUMBER");

                entity.Property(e => e.SchedShipDate)
                    .HasPrecision(0)
                    .HasColumnName("SCHED_SHIP_DATE");

                entity.Property(e => e.ShipmentPriority)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIPMENT_PRIORITY");

                entity.Property(e => e.ShiptoAddr1)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR1");

                entity.Property(e => e.ShiptoAddr2)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR2");

                entity.Property(e => e.ShiptoAddr3)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR3");

                entity.Property(e => e.ShiptoAddr4)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ADDR4");

                entity.Property(e => e.ShiptoCity)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_CITY");

                entity.Property(e => e.ShiptoCountry)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_COUNTRY");

                entity.Property(e => e.ShiptoId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ID");

                entity.Property(e => e.ShiptoName)
                    .HasMaxLength(360)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_NAME");

                entity.Property(e => e.ShiptoState)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_STATE");

                entity.Property(e => e.ShiptoZip)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SHIPTO_ZIP");

                entity.Property(e => e.SoldtoAddr1)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR1");

                entity.Property(e => e.SoldtoAddr2)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR2");

                entity.Property(e => e.SoldtoAddr3)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR3");

                entity.Property(e => e.SoldtoAddr4)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ADDR4");

                entity.Property(e => e.SoldtoCity)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_CITY");

                entity.Property(e => e.SoldtoCountry)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_COUNTRY");

                entity.Property(e => e.SoldtoId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ID");

                entity.Property(e => e.SoldtoName)
                    .HasMaxLength(360)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_NAME");

                entity.Property(e => e.SoldtoState)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_STATE");

                entity.Property(e => e.SoldtoZip)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SOLDTO_ZIP");

                entity.Property(e => e.SourceSystemId)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_SYSTEM_ID");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_TYPE");

                entity.Property(e => e.SubDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUB_DISTRICT");

                entity.Property(e => e.SubRegion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SUB_REGION");

                entity.Property(e => e.TransDate)
                    .HasPrecision(0)
                    .HasColumnName("TRANS_DATE");

                entity.Property(e => e.TransDatePeriodName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_PERIOD_NAME");

                entity.Property(e => e.TransDateWeekEnding)
                    .HasPrecision(0)
                    .HasColumnName("TRANS_DATE_WEEK_ENDING");

                entity.Property(e => e.TransDateWeekNum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_WEEK_NUM");

                entity.Property(e => e.TransDateYearQuarter)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_DATE_YEAR_QUARTER");

                entity.Property(e => e.TtlOrderVal).HasColumnName("TTL order Val");

                entity.Property(e => e.ViasClientCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_CLIENT_CODE");

                entity.Property(e => e.ViasEndCustomer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_END_CUSTOMER");

                entity.Property(e => e.ViasLocalCurrencyCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_LOCAL_CURRENCY_CODE");

                entity.Property(e => e.ViasMajorCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_MAJOR_CUSTOMER");

                entity.Property(e => e.ViasPartNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_PART_NUMBER");

                entity.Property(e => e.ViasSalesRepNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VIAS_SALES_REP_NO");

                entity.Property(e => e.WaybillNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WAYBILL_NUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
