using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Dtos
{
    public class CustomerUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
    }
}