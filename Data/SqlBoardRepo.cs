using System;
using System.Collections.Generic;
using System.Linq;
using todoonboard_api.data;
using todoonboard_api.models;

namespace todoonboard_api.Data{
    public class SqlBoardRepo : IBoardRepo {
        private readonly TodoOnBoardContext _context;

        public SqlBoardRepo(TodoOnBoardContext context)
        {
            _context = context;
        }

        public void CreateBoard(Board b)
        {
            if(b == null){
                throw new ArgumentNullException(nameof(b));

            }
            _context.Boards.Add(b);
        }

        public void DeleteBoard(Board b)
        {
           
            if(b == null){
                throw new ArgumentNullException(nameof(b));
            }
            _context.Boards.Remove(b);
        }

        public IEnumerable<Board> GetAllBoards()
        {
            return _context.Boards.ToList();
        }

        public Board GetBoard(int id)
        {
            return _context.Boards.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Todo> GetBoardById(int boardId)
        {
            return _context.Todos.Where(todo => todo.Board.Id == boardId).ToList();
        }

        public IEnumerable<Todo> GetUncompletedTodos(int boardId)
        {
            return _context.Todos.Where(todo => todo.Board.Id == boardId && todo.Done == false).ToList();
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >=0);
        }

        public void UpdateBoard(Board b)
        {
            //nothing    
        }
    }
}