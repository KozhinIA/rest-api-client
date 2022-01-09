using System.ComponentModel.DataAnnotations;

namespace RestApiClient.Models
{
    public enum Gender
    {
        [Display(Name = "Женский")]
        Female = 1,

        [Display(Name = "Мужской")]
        Male = 2,
    }
}