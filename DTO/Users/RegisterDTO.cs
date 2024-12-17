using System.ComponentModel.DataAnnotations;

namespace VinylSeliing.DTO.Users
{
    public record RegisterDTO(
        [Required] string UserName,
        [Required] string Email,
        [Required] string Password);
}

