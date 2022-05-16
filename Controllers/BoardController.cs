using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using todoonboard_api.Data;
using todoonboard_api.Dtos;
using todoonboard_api.models;

namespace todoonboard_api.Controllers
{

    [Route("/board")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepo _repo;
        private readonly IMapper _mapper;

        public BoardController(IBoardRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }   

        [HttpGet]
        public ActionResult<IEnumerable<BoardReadDto>> GetAllBoards(){
            var boardItems = _repo.GetAllBoards();
            return Ok(_mapper.Map<IEnumerable<BoardReadDto>>(boardItems));
        }

        [HttpGet("{id}")]
        public ActionResult <TodoReadDto> GetBoardById(int id){
            var todoItems = _repo.GetBoardById(id);
            if(todoItems != null){
                return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(todoItems));
            }
            return NotFound();
        }

        [HttpGet("{id}/incomplete")]
        public ActionResult <TodoReadDto> GetUncompletedTodos(int id){
            var todoItems = _repo.GetUncompletedTodos(id);
            if(todoItems != null){
                return Ok(_mapper.Map<IEnumerable<TodoReadDto>>(todoItems));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<BoardReadDto> CreateBoard([FromBody] Board b){
            var boardModel = _mapper.Map<Board>(b);
            _repo.CreateBoard(boardModel);
            _repo.saveChanges();
            return Ok(boardModel);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBoard(int id){
            var boardModelFromRepo = _repo.GetBoard(id);
            
            if(boardModelFromRepo == null){
                return NotFound();
            }

            var bId = boardModelFromRepo.Id;

            // get the todos of that paticular board
            var todofrombId = _repo.GetBoardById(bId);
            // Console.WriteLine(todofrombId.GetEnumerator().Current + "shskkfsh");
            // IEnumerable<Todo> em = todofrombId.GetEnumerator();
            // var list = todofrombId.Cast<>().ToList();

            // if(todofrombId.ToString().Length == 62){
            //     return NotFound("First Delete All todos that are created in board.");
            // }
            _repo.DeleteBoard(boardModelFromRepo);
            _repo.saveChanges();
            return NoContent();
        }


        // [HttpPatch("{id}")]
        // public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<BoardUpdateDto> patchDoc){
        //     var boardModelFromRepo = _repo.GetBoard(id);
        //     if(boardModelFromRepo == null){
        //         return NotFound();
        //     }
        //     var boardToPatch = _mapper.Map<BoardUpdateDto>(boardModelFromRepo);
        //     patchDoc.ApplyTo(boardToPatch, ModelState);
        //     if(!TryValidateModel(boardToPatch)){
        //         return ValidationProblem(ModelState);
        //     }
        //     _mapper.Map(boardToPatch, boardModelFromRepo);
        //     _repo.UpdateBoard(boardModelFromRepo);
        //     _repo.saveChanges();
        //     return NoContent();

        // }

        [HttpPatch("{id}")]
        public ActionResult UpdateTodo(int id, [FromBody] BoardUpdateDto boardUpdateDto){
            var boardfromrepo = _repo.GetBoard(id);
            if(boardfromrepo == null){
                return NotFound();
            }

            _mapper.Map(boardUpdateDto, boardfromrepo);
            _repo.UpdateBoard(boardfromrepo);
            _repo.saveChanges();
            return NoContent();
        }

        

    }
}