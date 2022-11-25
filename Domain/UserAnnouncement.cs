using DbTestHW.DataAccess.Dto;

namespace DbTestHW.Domain;

internal class UserAnnouncement
{
    public int AnnouncementId { get; set; }
    public Announcement? Announcement { get; set; }

    public int UserId { get; set; }

    public User? User { get; set; }
}