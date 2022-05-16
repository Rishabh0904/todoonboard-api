using System.Collections.Generic;
using todoonboard_api.models;

namespace todoonboard_api.Data{
    public interface IBoardRepo{
        IEnumerable<Board> GetAllBoards();

        IEnumerable<Todo> GetBoardById(int id);

        IEnumerable<Todo> GetUncompletedTodos(int id);

        Board GetBoard(int id);

        void CreateBoard(Board b);

        void UpdateBoard(Board b);

         void DeleteBoard(Board b);

        bool saveChanges();


    }
}