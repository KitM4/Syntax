using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Syntax.Application.Utils.Cloudinary;
using Syntax.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Syntax.Application.Services;

public class ImageUploadService(IOptions<CloudinarySettings> options) : IImageUploadService
{
    private readonly Cloudinary _cloudinary = new(new Account(options.Value.CloudName, options.Value.ApiKey, options.Value.ApiSecret));

    public async Task<ImageUploadResult> UploadPhotoAsync(IFormFile file)
    {
        ImageUploadResult result = new();

        if (file.Length > 0)
        {
            using Stream stream = file.OpenReadStream();
            ImageUploadParams uploadParams = new()
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
            };
         
            result = await _cloudinary.UploadAsync(uploadParams);
        }

        return result;
    }

    public async Task<DeletionResult> DeletePhotoAsync(string publicId) =>
        await _cloudinary.DestroyAsync(new(publicId));
}