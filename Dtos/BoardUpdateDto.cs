using System.ComponentModel.DataAnnotations;

namespace todoonboard_api.Dtos{
    public class BoardUpdateDto{
        
        [Required]
        public string name {get; set;}

    }
}