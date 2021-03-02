using System.ComponentModel.DataAnnotations;

namespace BelleChao.Data.DTOs
{
    public class AvatarToUpdateDTO
    {
        [Required(ErrorMessage = "Photo Url is required")]
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage = "Photo Public Id is required")]
        public string  PhotoPublicId { get; set; }

    }
}
