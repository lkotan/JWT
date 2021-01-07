using AutoMapper;
using Jwt.Entities;
using Jwt.Models.Category;
using Jwt.Models.Product;
using Jwt.Models.Role;
using Jwt.Models.User;
using Jwt.Core.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.API.Installers.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Products
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<Product, ProductListModel>();
            CreateMap<ProductListModel, Product>();
            #endregion

            #region Categories
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();

            CreateMap<Category, CategoryListModel>();
            CreateMap<CategoryListModel, Category>();
            #endregion

            #region Users
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<User, UserListModel>();
            CreateMap<UserListModel, User>();
            #endregion

            #region Roles
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            CreateMap<Role, RoleListModel>();
            CreateMap<RoleListModel, Role>();
            #endregion

            #region UserRoles
            CreateMap<UserRole, UserRoleModel>();
            CreateMap<UserRoleModel, UserRole>();

            CreateMap<UserRole, UserRoleListModel>();
            CreateMap<UserRoleListModel, UserRole>();
            #endregion
        }
    }
}
