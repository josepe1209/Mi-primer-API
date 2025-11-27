using AutoMapper;
using Mi_primer_API.DAL.Models;
using Mi_primer_API.DAL.Models.Dto;

namespace Mi_primer_API.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();

            //Aqui va el mapper de la proxima entidad movie
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap();
        }
    }
}
