using AutoMapper;
using todoonboard_api.Dtos;
using todoonboard_api.models;

namespace todoonboard_api.Profiles{
    public class BoardsProfile : Profile{
        public BoardsProfile(){
            CreateMap<Board, BoardReadDto>();
            CreateMap<BoardCreateDto, Board>();
            CreateMap<BoardUpdateDto, Board>();
            CreateMap<Board, BoardUpdateDto>();
        }
    }
}