using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Syntax.Application.Interfaces.Services;

public interface IImageUploadService
{
    public Task<ImageUploadResult> UploadPhotoAsync(IFormFile file);

    public Task<DeletionResult> DeletePhotoAsync(string publicId);
}