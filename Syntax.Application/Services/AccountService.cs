using CloudinaryDotNet.Actions;
using Syntax.Domain.Models;
using Syntax.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Syntax.Application.Services;

public class AccountService(SignInManager<User> signInManager, UserManager<User> userManager, IImageUploadService imageUpload) : IAccountService
{
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IImageUploadService _imageUpload = imageUpload;

    public async Task<bool> LoginAsync(string userName, string password, bool rememberMe) =>
        (await _signInManager.PasswordSignInAsync(userName, password, rememberMe, false)).Succeeded;

    public async Task RegisterAsync(string userName, string email, string password)
    {
        User user = new()
        {
            UserName = userName,
            Email = email,
            ProfileImageUrl = string.Empty,
            Bio = string.Empty,
            Snippets = [],
            Reposts = [],
            Comments = [],
            Likes = [],
            Views = [],
            Followers = [],
            Subscriptions = [],
        };

        IdentityResult result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            string errorMessage = string.Empty;
            foreach (IdentityError error in result.Errors)
                errorMessage += string.Join(", ", error.Description);

            throw new(errorMessage);
        }

        await _signInManager.SignInAsync(user, false);
    }

    public async Task EditAsync(User user, string userName, IFormFile? profileImage, string? bio)
    {
        if (user == null) throw new("User is null");

        if (profileImage != null)
        {
            ImageUploadResult result = await _imageUpload.UploadPhotoAsync(profileImage);
            user.ProfileImageUrl = result.Url.ToString();
        }

        user.UserName = userName;
        user.Bio = bio;

        await _userManager.UpdateAsync(user);
    }

    public async Task LogoutAsync() =>
        await _signInManager.SignOutAsync();
}