using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoonboard_api.models{

    public class Todo{
        [Key]
        public int Id {get; set;}

        [Required]
        public string Title{get; set;}

        [Required]
        public bool Done{get; set;}

        
        public DateTime CreatedAt{get; set;}

        
        public DateTime UpdatedAt{get; set;}

        // [ForeignKey("BoardId")]
        public Board Board {get; set;}
    }
    

}