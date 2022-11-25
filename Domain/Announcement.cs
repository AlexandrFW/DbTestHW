namespace DbTestHW.Domain;

public class Announcement
{
    public int AnnouncementId { get; set; }

    public int UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; } 

    public bool IsPayed { get; set; } = false;

    public bool IsVip { get; set; } = false;

    public DateTime Created { get; set; }
}