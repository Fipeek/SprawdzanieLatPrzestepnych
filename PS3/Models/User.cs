using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS3.Models
{
    public class User
    {   
        public int id { get; set; }
        [Required]
        [Range(1899,2022,ErrorMessage = "Zakres lat 1899-2022")]
        [Column(TypeName= "varchar(100)")]
            public int? year { get; set; }

        [Required]
        [StringLength(maximumLength:100, ErrorMessage = "Imie może mieć maksymalnie 100 znaków")]
        [Column(TypeName = "varchar(100)")]
        public string? firstName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? lastName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public DateTime? date { get; set; } 
        public string checkYear()
        {
            if (this.year == null)
            {
                return "";
            }
            if (this.year % 100 != 0 && this.year % 4 == 0 || this.year%400==0)
            {
                return "przestępny";
            }
            return "nieprzestępny";
        }
    }
}
