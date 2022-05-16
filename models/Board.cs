using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace todoonboard_api.models{
    public class Board{

        [Key]
        public int Id{get; set;}

        [Required]
        public string Name {get; set;}

        public virtual ICollection<Todo> Todos {get; set;}

        
    }
}