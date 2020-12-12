using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Server.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) :base(option)
        {

        }

        public DbSet<ArticleMaster> Article_Masters { get; set; }
        public DbSet<BusinessPartner> Business_Partners { get; set; }
        public DbSet<SalesInvoice_Details> SalesInvoice_Details { get; set; }
        public DbSet<SalesInvoice_Headers> SalesInvoice_Headers { get; set; }
        public DbSet<SalesInvoice> Sales_Invoice { get; set; }
        public DbSet<SalesmanMaster> Salesman_Masters { get; set; }
        public DbSet<PurchaseOrder> Purchase_Orders { get; set; }
        public DbSet<PurchaseDetails> Purchase_Details { get; set; }
        public DbSet<PurchaseHeaders> Purchase_Headers { get; set; }
        public DbSet<SalesOrder> Sales_Orders { get; set; }
        public DbSet<SalesOrderHeaders> SalesOrder_Headers { get; set; }
        public DbSet<SalesOrderDetails> SalesOrder_Details { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DeliveryReceipt> Delivery_Receipts { get; set; }
        public DbSet<BusinessUnit> Business_Units { get; set; }
        public DbSet<SAPSalesmanMaster> SAP_SalesmanMasters { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryHeader> Inventory_Headers { get; set; }
        public DbSet<InventoryDetails> Inventory_Details { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<U_Channel> Channels { get; set; }
        public DbSet<Group_Codes> Group_Codes { get; set; }
        public DbSet<Payment_Terms> Payment_Terms { get; set; }
        public DbSet<Uploads> Upload { get; set; }
        public DbSet<Pending_BP> Pending_BPs { get; set; }
    }
}
