using MyCircle.API.DTOs;
using MyCircle.API.Entities;

namespace MyCircle.API.Contracts
{
	public interface IPhotoService
	{
		Task<Photo> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto);
		Task<Photo> GetPhoto(int id);
		Task<Photo> GetMainPhotoForUser(int userId);
		Task<Photo> SetMainPhoto(int userId, int id);
		Task<bool> DeletePhoto(int userId, int id);
		
	}
}
