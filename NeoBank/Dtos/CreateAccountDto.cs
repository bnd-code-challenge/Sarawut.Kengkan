using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace NeoBank.Dtos
{
    public class CreateAccountDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
