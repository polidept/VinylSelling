using System.ComponentModel.DataAnnotations;

namespace VinylSeliing.DTO.Users
{
    public record LoginDTO(
        [Required] string Email,
        [Required] string Password);


}

