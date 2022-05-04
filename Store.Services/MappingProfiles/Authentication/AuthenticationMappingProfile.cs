using AutoMapper;
using Store.Data.Entities;
using Store.ViewModels.Authentication;

namespace Store.Services.MappingProfiles
{
	public class AuthenticationMappingProfile: Profile
	{
		public AuthenticationMappingProfile()
		{
            CreateMap<PermissionAddModel, Permission>();
            CreateMap<PermissionUpdateModel, Permission>();
            CreateMap<Permission, PermissionModel>();

            CreateMap<RoleAddModel, Role>();
            CreateMap<RoleUpdateModel, Role>();
            CreateMap<Role, RoleModel>();
            CreateMap<Role, RoleDetailModel>();

            CreateMap<UserAddModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<User, UserInfoModel>();
        }
	}
}

