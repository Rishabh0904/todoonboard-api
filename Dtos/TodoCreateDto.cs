using System;
using System.ComponentModel.DataAnnotations;
using todoonboard_api.models;

namespace todoonboard_api.Dtos{

    public class TodoCreateDto{
        
        public string Title{get; set;}

        public bool done{get; set;}

        public DateTime createdAt{get; set;}

        public DateTime updatedAt{get; set;}
 
    
        public Board Board{get; set;}
    }
    

}