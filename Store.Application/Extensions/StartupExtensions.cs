using NSwag;
using NSwag.Generation.Processors.Security;
using MongoDB.Driver;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Linq;
using Store.Data.DataAccess;
using Store.Data.Infrastructures;
using Store.Data.Entities;
using Store.Data.Repositories;
using Store.Data.Repositories.Common;
using Store.Services.Core;
using Store.Services.MappingProfiles;
using Store.Services.Catalog.ProductPrices;
using Store.Services.Catalog.OrderPayments;
using Store.Services.Catalog.OrderProducts;
using Store.Services.Catalog.OrderStatuses;
using Store.Services.Catalog.ProductImages;
using Store.Services.Catalog.CategoryProducts;
using Store.Services.Catalog.Carts;
using Store.Services.Catalog.Categories;
using Store.Services.Catalog.Coupons;
using Store.Services.Catalog.Customers;
using Store.Services.Catalog.Details;
using Store.Services.Catalog.Notifications;
using Store.Services.Catalog.Orders;
using Store.Services.Catalog.OrderCoupons;
using Store.Services.Catalog.Payments;
using Store.Services.Catalog.Products;
using Store.Services.Catalog.ProductDetails;
using Store.Services.Catalog.Shippers;
using Store.ViewModels.Catalog.Carts;
using Store.ViewModels.Catalog.Categories;
using Store.ViewModels.Catalog.Payments;

namespace Store.Application.Extensions
{
    public static class StartupExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            #region Common
            services.AddHttpClient<IHttpService, HttpService>();
            #endregion

            #region Standard
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IHangFireService, HangFireService>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, PermissionService>();
            #endregion

            #region Import
            #endregion

            #region Export
            #endregion

            #region For implement base controller
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICouponService, CouponService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IDetailService, DetailService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderCouponService, OrderCouponService>();
            services.AddTransient<IOrderPaymentService, OrderPaymentService>();
            services.AddTransient<IOrderPrdoductService, OrderProductService>();
            services.AddTransient<IOrderStatusService, OrderStatusService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductDetailService, ProductDetailService>();
            services.AddTransient<IProductImageService, ProductImageService>();
            services.AddTransient<IProductPriceService, ProductPriceService>();
            services.AddTransient<IShipperService, ShipperService>();

            //services.AddTransient<IBaseService<Cart, GetCartPagingRequest, CartViewModel, CartCreateRequest, CartUpdateRequest>, BaseService<Cart, GetCartPagingRequest, CartViewModel, CartCreateRequest, CartUpdateRequest>>();
            //services.AddTransient<IBaseService<Category, GetCategoryPagingRequest, CategoryViewModel, CategoryCreateRequest, CategoryUpdateRequest>, BaseService<Category, GetCategoryPagingRequest, CategoryViewModel, CategoryCreateRequest, CategoryUpdateRequest>>();
            //services.AddTransient<IBaseService<Payment, GetPaymentPagingRequest, PaymentViewModel, PaymentCreateRequest, PaymentUpdateRequest>, BaseService<Payment, GetPaymentPagingRequest, PaymentViewModel, PaymentCreateRequest, PaymentUpdateRequest>>();

            #endregion
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Common
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Standard
            #endregion

            #region For implement base service


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IUserPermissionRepository, UserPermissionRepository>();
            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();


            services.AddTransient<IBaseRepository<Cart>, BaseRepository<Cart>>();
            services.AddTransient<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddTransient<IBaseRepository<CategoryProduct>, BaseRepository<CategoryProduct>>();
            services.AddTransient<IBaseRepository<Coupon>, BaseRepository<Coupon>>();
            services.AddTransient<IBaseRepository<Customer>, BaseRepository<Customer>>();
            services.AddTransient<IBaseRepository<Detail>, BaseRepository<Detail>>();
            services.AddTransient<IBaseRepository<Notification>, BaseRepository<Notification>>();
            services.AddTransient<IBaseRepository<OrderCoupon>, BaseRepository<OrderCoupon>>();
            services.AddTransient<IBaseRepository<OrderPayment>, BaseRepository<OrderPayment>>();
            services.AddTransient<IBaseRepository<OrderProduct>, BaseRepository<OrderProduct>>();
            services.AddTransient<IBaseRepository<Order>, BaseRepository<Order>>();
            services.AddTransient<IBaseRepository<OrderStatus>, BaseRepository<OrderStatus>>();
            services.AddTransient<IBaseRepository<Payment>, BaseRepository<Payment>>();
            services.AddTransient<IBaseRepository<ProductDetail>, BaseRepository<ProductDetail>>();
            services.AddTransient<IBaseRepository<ProductImage>, BaseRepository<ProductImage>>();
            services.AddTransient<IBaseRepository<ProductPrice>, BaseRepository<ProductPrice>>();
            services.AddTransient<IBaseRepository<Product>, BaseRepository<Product>>();
            services.AddTransient<IBaseRepository<Shipper>, BaseRepository<Shipper>>();
            services.AddTransient<IBaseRepository<Supplier>, BaseRepository<Supplier>>();

            #endregion
        }

        public static void AddMappingProfile(this IServiceCollection services)
        {
            var profiles = new MapperConfiguration(
                _ =>
                {
                    _.AddProfile(new FilterMappingProfile());
                    _.AddProfile(new AuthenticationMappingProfile());
                }
            );

            services.AddSingleton(profiles.CreateMapper());
        }

        public static void ConfigCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }

        public static void ConfigSwagger(this IServiceCollection services, IWebHostEnvironment env)
        {
            var environmentOfSystem = env.IsDevelopment() ? "Development" : "Production";
            var apiVersionDescriptionProvider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                services.AddSwaggerDocument(document =>
                {
                    document.Title = "Store API";
                    document.Description = $"{environmentOfSystem} | Build at {DateTime.Now.ToLocalTime().ToString("HH:mm dd/MM/yyyy")}";
                    document.Version = "6.0";

                    document.DocumentName = description.GroupName;
                    document.PostProcess = _ => _.Info.Version = description.GroupName;
                    document.ApiGroupNames = new[] { description.GroupName };

                    document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Type into the textbox: Bearer {your JWT token}."
                    });

                    document.OperationProcessors.Add(
                        new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                    document.AllowReferencesWithProperties = true;
                });
        }

        public static void ConfigJwt(this IServiceCollection services, string key, string issuer, string audience)
        {
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtconfig =>
                {
                    jwtconfig.SaveToken = true;
                    jwtconfig.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = issuer,
                        ValidAudience = string.IsNullOrEmpty(audience) ? issuer : audience,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
                        ClockSkew = System.TimeSpan.Zero,
                    };
                });
        }
    }
}
