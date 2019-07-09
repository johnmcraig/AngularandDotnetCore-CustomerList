using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Dtos
{
    public class CustomerUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
    }
}