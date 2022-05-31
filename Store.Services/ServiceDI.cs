using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Data.Entities;
using Store.Data.Repositories.Common;
using Store.Services.Catalog.Carts;
using Store.Services.Catalog.Categories;
using Store.Services.Catalog.CategoryProducts;
using Store.Services.Catalog.OrderPayments;
using Store.Services.Catalog.OrderProducts;
using Store.Services.Catalog.Orders;
using Store.Services.Catalog.OrderStatuses;
using Store.Services.Catalog.ProductImages;
using Store.Services.Catalog.ProductPrices;
using Store.Services.Catalog.Products;
using Store.Services.Catalog.Shippers;
using Store.Services.Catalog.Suppliers;
using Store.Services.Core;
using Store.ViewModels.Catalog.Carts;
using Store.ViewModels.Catalog.Categories;
using Store.ViewModels.Catalog.Coupons;
using Store.ViewModels.Catalog.Customers;
using Store.ViewModels.Catalog.Details;
using Store.ViewModels.Catalog.Notifications;
using Store.ViewModels.Catalog.Orders;
using Store.ViewModels.Catalog.Payments;
using Store.ViewModels.Catalog.Products;
using Store.ViewModels.Catalog.Shippers;
using Store.ViewModels.Catalog.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
    public class ServiceDI
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<User>,BaseRepository< User>>();
            services.AddTransient<IBaseRepository<Permission>, BaseRepository<Permission>>();
            services.AddTransient<IBaseRepository<Role>, BaseRepository<Role>>();

            //services.AddTransient<ICartService, CartService>();
            //services.AddTransient<IOrderService, OrderService>();
            //services.AddTransient<IProductService, ProductService>();
            //services.AddTransient<ICategoryService, CategoryService>();
            //services.AddTransient<IShipperService, ShipperService>();
            //services.AddTransient<ISupplierService, SupplierService>();

            services.AddTransient<IBaseRepository<Cart>, BaseRepository<Cart>>();
            services.AddTransient<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddTransient<IBaseRepository<Coupon>, BaseRepository<Coupon>>();
            services.AddTransient<IBaseRepository<Customer>, BaseRepository<Customer>>();
            services.AddTransient<IBaseRepository<Detail>, BaseRepository<Detail>>();
            services.AddTransient<IBaseRepository<Notification>, BaseRepository<Notification>>();
            services.AddTransient<IBaseRepository<Order>, BaseRepository<Order>>();
            services.AddTransient<IBaseRepository<Payment>, BaseRepository<Payment>>();
            services.AddTransient<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddTransient<IBaseRepository<Shipper>, BaseRepository<Shipper>>();
            services.AddTransient<IBaseRepository<Supplier>, BaseRepository<Supplier>>();


            //services.AddScoped<IProductPriceService, ProductPriceService>();
            //services.AddScoped<IOrderPaymentService, OrderPaymentService>();
            //services.AddScoped<IOrderPrdoductService, OrderProductService>();
            //services.AddScoped<IOrderStatusService, OrderStatusService>();
            //services.AddScoped<IProductImageService, ProductImageService>();
            //services.AddScoped<ICategoryProductService, CategoryProductService>();




        }
    }
}
