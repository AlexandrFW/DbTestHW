using DbTestHW.Domain;

namespace DbTestHW.DataAccess.Dto;

internal class AnnouncementDto
{
    public int UserId { get; set; }

    public UserDto? User { get; set; }

    public int CategoryId { get; set; }

    public CategoryDto? Category { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool IsPayed { get; set; } = false;

    public bool IsVip { get; set; } = false;

    public DateTime Created { get; set; } = DateTime.Now;
}