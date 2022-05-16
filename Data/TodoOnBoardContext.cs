using Microsoft.EntityFrameworkCore;
using todoonboard_api.models;

namespace todoonboard_api.data{
    public class TodoOnBoardContext : DbContext{


        public TodoOnBoardContext()
{}
        public TodoOnBoardContext(DbContextOptions<TodoOnBoardContext> opt) : base(opt)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Board> Boards {get; set;}
        
        
    }
}