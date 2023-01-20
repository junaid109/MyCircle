using MyCircle.API.Contracts;
using MyCircle.API.Data.Repository;
using MyCircle.API.Options;
using MyCircle.API.Profiles;
using MyCircle.API.Services;

namespace MyCircle.API.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IPhotoService, PhotoService>();
			services.AddScoped<LogUserActivity>();
			services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
			services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
			return services;
		}
	}
}
