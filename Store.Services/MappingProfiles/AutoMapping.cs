using AutoMapper;
using Store.Data.Entities;
using Store.ViewModels.Catalog.Carts;
using Store.ViewModels.Catalog.Categories;
using Store.ViewModels.Catalog.CategoryProducts;
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

namespace Store.Services.MappingProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<Cart, CartCreateRequest>().ReverseMap();
            CreateMap<Cart, CartUpdateRequest>().ReverseMap();

            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category,CategoryCreateRequest>().ReverseMap();
            CreateMap<Category, CategoryUpdateRequest>().ReverseMap();

            CreateMap<CategoryProduct, CategoryProductViewModel>();

            CreateMap<Coupon, CouponViewModel>().ReverseMap();
            CreateMap<Coupon, CouponCreateRequest>().ReverseMap();
            CreateMap<Coupon, CouponUpdateRequest>().ReverseMap();

            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CustomerCreateRequest>().ReverseMap();
            CreateMap<Customer, CustomerUpdateRequest>().ReverseMap();

            CreateMap<Detail, DetailViewModel>().ReverseMap();
            CreateMap<Detail, DetailCreateRequest>().ReverseMap();
            CreateMap<Detail, DetailUpdateRequest>().ReverseMap();

            CreateMap<Notification, NotificationViewModel>().ReverseMap();
            CreateMap<Notification, NotificationCreateRequest>().ReverseMap();
            CreateMap<Notification, NotificationUpdateRequest>().ReverseMap();

            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Order, OrderCreateRequest>().ReverseMap();
            CreateMap<Order, OrderUpdateRequest>().ReverseMap();

            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Payment, PaymentCreateRequest>().ReverseMap();
            CreateMap<Payment, PaymentUpdateRequest>().ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductCreateRequest>().ReverseMap();
            CreateMap<Product, ProductUpdateRequest>().ReverseMap();

            CreateMap<Shipper, ShipperViewModel>().ReverseMap();
            CreateMap<Shipper, ShipperCreateRequest>().ReverseMap();
            CreateMap<Shipper, ShipperUpdateRequest>().ReverseMap();

            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Supplier, SupplierCreateRequest>().ReverseMap();
            CreateMap<Supplier, SupplierUpdateRequest>().ReverseMap();

        }

    }
}
