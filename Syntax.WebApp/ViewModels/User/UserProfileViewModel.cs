using Syntax.Domain.Models.Posts;

namespace Syntax.WebApp.ViewModels.User;

public class UserProfileViewModel
{
    public string UserName { get; set; } = string.Empty;

    public string? ProfileImageUrl { get; set; }

    public string? Bio { get; set; }

    public int SnippetsCount { get; set; } = 0;

    public int FollowersCount { get; set; } = 0;

    public int SubscriptionsCount { get; set; } = 0;

    public ICollection<Snippet> Snippets { get; set; } = [];
}