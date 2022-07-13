using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCrudApplicaition.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        [Required]
        public string ActivityType { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
