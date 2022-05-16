using AutoMapper;
using todoonboard_api.Dtos;
using todoonboard_api.models;

namespace todoonboard_api.Profiles{
    public class TodosProfile : Profile{
        public TodosProfile()
        {
            //SOURCE -> TARGET
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();
            // CreateMap<TodoReadDto, TodoBoardIdUpdateDto>();
        }
    }
}