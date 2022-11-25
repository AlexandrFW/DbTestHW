using System.ComponentModel.DataAnnotations;

namespace DbTestHW.DataAccess.Dto;

internal class UserAnnouncementDto
{
    [Key]
    public int AnnouncementId { get; set; }

    public AnnouncementDto? Announcement { get; set; }

    [Key]
    public int UserId { get; set; }

    public UserDto? User { get; set; }
}