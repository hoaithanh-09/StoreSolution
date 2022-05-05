using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Data.Configurations;
using Store.Data.Entities;
using Store.Data.Entities.Common;

namespace Store.Data.DataAccess
{
    public class SqlDbContext: DbContext
    {
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options): base(options)
        {
        }

        #region --- Authentication ---
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        #endregion

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderCoupon> OrderCoupons { get; set; }
        public virtual DbSet<OrderPayment> OrderPayments { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region --- Authentication ---
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new RoleConfigurations());
            modelBuilder.ApplyConfiguration(new PermissionConfigurations());
            modelBuilder.ApplyConfiguration(new UserPermissionConfigurations());
            modelBuilder.ApplyConfiguration(new RolePermissionConfigurations());
            modelBuilder.ApplyConfiguration(new UserRoleConfigurations());
            #endregion

            modelBuilder.ApplyConfiguration(new AddressConfigurations());
            modelBuilder.ApplyConfiguration(new CartConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryProductConfigurations());
            modelBuilder.ApplyConfiguration(new CouponConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            modelBuilder.ApplyConfiguration(new DetailConfigurations());
            modelBuilder.ApplyConfiguration(new NotificationConfigurations());
            modelBuilder.ApplyConfiguration(new OrderConfigurations());
            modelBuilder.ApplyConfiguration(new OrderCouponConfigurations());
            modelBuilder.ApplyConfiguration(new OrderPaymentConfigurations());
            modelBuilder.ApplyConfiguration(new OrderProductConfigurations());
            modelBuilder.ApplyConfiguration(new OrderStatusConfigurations());
            modelBuilder.ApplyConfiguration(new PaymentConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new ProductDetailConfigurations());
            modelBuilder.ApplyConfiguration(new ProductImageConfigurations());
            modelBuilder.ApplyConfiguration(new ProductPriceConfigurations());
            modelBuilder.ApplyConfiguration(new ShipperConfigurations());
            modelBuilder.ApplyConfiguration(new SupplierConfigurations());
            
            #region Seed
            User user = new User()
            {
                Id = 1,
                Username = "admin",
                Password = "$2a$10$Vp37Kfp5vdUfTKIXAEOByegT7qruOE96ysBfKxV5ai/J1/sjZMEJK",
                Fullname = "admin",
            };

            modelBuilder.Entity<User>().HasData(user);
            #endregion
        }
    }
}