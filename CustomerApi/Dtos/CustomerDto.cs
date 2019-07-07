
using System;

namespace CustomerApi.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set;}
    }
}