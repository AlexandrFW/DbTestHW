using DbTestHW.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DbTestHW.DataAccess.Dto;

internal class AnnouncementDto
{
    [Key]
    [Column("AnnouncementId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AnnouncementId { get; set; }

    public int CategoryId { get; set; }
    
    public CategoryDto? Category { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool IsPayed { get; set; } = false;

    public bool IsVip { get; set; } = false;

    public DateTime Created { get; set; } = DateTime.Now;

    public ICollection<UserAnnouncementDto>? UsersAnnouncements { get; set; }
}