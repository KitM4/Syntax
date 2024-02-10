namespace Syntax.Domain.Models.Interfaces;

public interface IPost
{
    public Guid Id { get; set; }

    public string Content { get; set; }
}