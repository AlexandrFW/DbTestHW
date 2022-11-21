using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbTestHW.DataAccess.Dto;

internal class CategoryDto
{
    [Key]
    [Column("CategoryId")]
    public Guid CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = string.Empty;

    public ICollection<AnnouncementDto>? Announcements { get; set; }
}