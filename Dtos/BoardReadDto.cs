using System.ComponentModel.DataAnnotations;

namespace todoonboard_api.Dtos{
    public class BoardReadDto{
        public int Id{get; set;}

        [Required]
        public string name {get; set;}

    }
}