using System.ComponentModel.DataAnnotations;

namespace todoonboard_api.Dtos{
    public class BoardCreateDto{
        
        [Required]
        public string name {get; set;}

    }
}