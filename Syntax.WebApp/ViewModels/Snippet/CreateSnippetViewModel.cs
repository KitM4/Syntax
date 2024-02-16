using Syntax.Domain.Enums;

namespace Syntax.WebApp.ViewModels.Snippet;

public class CreateSnippetViewModel
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;

    public ProgrammingLanguage Language { get; set; } = ProgrammingLanguage.Other;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}