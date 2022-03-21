using System.ComponentModel.DataAnnotations;



namespace PS3.Models
{
    public class UserDataHolder
    {   
        [Required]
        [Range(1899,2022,ErrorMessage = "Zakres lat 1899-2022")]
            public int? year { get; set; }

        [Required]
        [StringLength(maximumLength:100, ErrorMessage = "Imie może mieć maksymalnie 100 znaków")]
        public string? name { get; set; }  
    }
}
