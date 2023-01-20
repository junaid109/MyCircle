using CloudinaryDotNet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MyCircle.API.Contracts;
using MyCircle.API.DTOs;
using MyCircle.API.Entities;
using MyCircle.API.Options;

namespace MyCircle.API.Services
{
	public class PhotoService : IPhotoService
	{
		// configure cloudinary 
		// create a new photo object
		// upload the photo to cloudinary
		// save the photo to the database
		// return the photo

		private Cloudinary _cloudinary;

		PhotoService(IOptions<CloudinarySettings> config)
		{
			
			// configure cloudinary
			// create a new account
			// create a new cloudinary object
			var account = new Account(
				 config.Value.CloudName,
				 config.Value.ApiKey,
				 config.Value.ApiSecret
			 );

			_cloudinary = new Cloudinary(account);
			
		}

		public async Task<Photo> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto)
		{

			// add photo to cloudinary
			var uploadResult = await _cloudinary.UploadAsync((CloudinaryDotNet.Actions.RawUploadParams)photoForCreationDto.File);
			return new Photo
			{

			};
		}

		public Task<bool> DeletePhoto(int userId, int id)
		{
			throw new NotImplementedException();
		}

		public Task<Photo> GetMainPhotoForUser(int userId)
		{
			throw new NotImplementedException();
		}

		public Task<Photo> GetPhoto(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Photo> SetMainPhoto(int userId, int id)
		{
			throw new NotImplementedException();
		}
	}
}
