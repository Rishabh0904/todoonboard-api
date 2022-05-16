using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using todoonboard_api.Data;
using todoonboard_api.Dtos;
using todoonboard_api.models;

namespace todoonboard_api.Controllers{

    [Route("board/{boardId}/todo")]
    public class TodoController : ControllerBase{
        private readonly ITodoRepo _repo;
        private readonly IBoardRepo _boardRepo;
        private readonly IMapper _mapper;

        public TodoController(ITodoRepo repo, IBoardRepo boardRepo, IMapper mapper)
        {
            _repo = repo;
            _boardRepo = boardRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoReadDto>> GetTodosByBoardId(int boardId){
            var todoItems = _repo.GetTodosByBoardId(boardId);
            return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(todoItems));
        }

        [HttpGet("{id}")]
        public ActionResult <TodoReadDto> GetTodoById(int id){
            var todoItem = _repo.GetTodoById(id);
            if(todoItem != null){
                return Ok(_mapper.Map<TodoReadDto>(todoItem));
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<TodoReadDto> CreateTodo(string boardId, [FromBody] TodoCreateDto t){
            t.Board = _boardRepo.GetBoard(int.Parse(boardId));
            t.createdAt = DateTime.Now;
            t.updatedAt = DateTime.Now;
            var todoModel = _mapper.Map<Todo>(t);
            _repo.CreateTodo(todoModel);
            _repo.saveChanges();
            var todoReadDto = _mapper.Map<TodoReadDto>(todoModel);
            return Ok(todoReadDto);
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateTodo(int id, [FromBody] TodoUpdateDto todoUpdateDto){
            var todofromrepo = _repo.GetTodoById(id);
            if(todofromrepo == null){
                return NotFound();
            }

            _mapper.Map(todoUpdateDto, todofromrepo);
            _repo.UpdateTodo(todofromrepo);
            _repo.saveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id){
            var boardModelFromRepo = _repo.GetTodoById(id);
            if(boardModelFromRepo == null){
                return NotFound();
            }
            _repo.DeleteTodo(boardModelFromRepo);
            _repo.saveChanges();
            return NoContent();
        }

        //shifting todo from one board to another
        [HttpPut("{todoId}/{secondBoardId}")]
        public ActionResult shiftTodo(int boardId, int todoId, int secondBoardId){

            var todoItem = _repo.GetTodoById(todoId);
            if(todoItem == null){
                return NotFound("Todo does not exist");
            }
            todoItem.Board = _boardRepo.GetBoard(secondBoardId);
            if(todoItem.Board == null){
                return NotFound("First create the second board");
            }
            
            var readdto = new TodoReadDto();
            readdto.Board = todoItem.Board;
            readdto.done = todoItem.Done;
            readdto.Title = todoItem.Title;
            readdto.createdAt = todoItem.CreatedAt;
            readdto.updatedAt = DateTime.Now;

            var todoModel = _mapper.Map<Todo>(readdto);
            _repo.UpdateTodo(todoModel);
            _repo.saveChanges();
            var todoReadDto = _mapper.Map<TodoReadDto>(todoModel);
            return Ok();

        }



        // [HttpPatch("{id}")]
        // public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TodoUpdateDto> patchDoc){
        //     var TodoModelFromRepo = _repo.GetTodoById(id);
        //     if(TodoModelFromRepo == null){
        //         return NotFound();
        //     }
        //     var todoToPatch = _mapper.Map<TodoUpdateDto>(TodoModelFromRepo);
        //     patchDoc.ApplyTo(todoToPatch, ModelState);
        //     if(!TryValidateModel(todoToPatch)){
        //         return ValidationProblem(ModelState);
        //     }
        //     _mapper.Map(todoToPatch, TodoModelFromRepo);
        //     _repo.UpdateTodo(TodoModelFromRepo);
        //     _repo.saveChanges();
        //     return NoContent();

        // }



        

        
    }
}