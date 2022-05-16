using System.Collections.Generic;
using todoonboard_api.models;

namespace todoonboard_api.Data{
    public interface ITodoRepo{

        IEnumerable<Todo> GetTodosByBoardId(int boardId);
        
        Todo GetTodoById(int id);

        void CreateTodo(Todo t);

        bool saveChanges();

        bool complete(); //have to use to list all uncompleted todos

        void UpdateTodo(Todo t);

        void DeleteTodo(Todo t);
    }
}