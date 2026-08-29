using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YesDhobi.Api.Models
{
    [Table("working_days")]
    public class WorkingDay
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [Column("day_name")]
        public string DayName { get; set; }

        [Required]
        [StringLength(3)]
        [Column("day_code")]
        public string DayCode { get; set; }
    }
}
