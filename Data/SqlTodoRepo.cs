using System;
using System.Collections.Generic;
using System.Linq;
using todoonboard_api.data;
using todoonboard_api.models;

namespace todoonboard_api.Data{
    public class SqlTodoRepo : ITodoRepo
    {
        private readonly TodoOnBoardContext _context;

        public SqlTodoRepo(TodoOnBoardContext context)
        {
            _context = context;
        }


        public bool complete()
        {
            throw new System.NotImplementedException();
        }

        public void CreateTodo(Todo t)
        {
            if(t == null){
                throw new ArgumentNullException(nameof(t));
            }
            _context.Todos.Add(t);
        }

        public void DeleteTodo(Todo t)
        {
             if(t == null){
                throw new ArgumentNullException(nameof(t));
            }
            _context.Todos.Remove(t);
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return _context.Todos.ToList();
        }

        public IEnumerable<Todo> GetTodosByBoardId(int boardId)
        {
            return _context.Todos.Where(todo => todo.Board.Id == boardId).ToList();
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault(p => p.Id == id);
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >=0);
        }

        public void UpdateTodo(Todo t)
        {
             
        }
    }
}