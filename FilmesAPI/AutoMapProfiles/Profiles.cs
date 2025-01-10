using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Dtos;

namespace FilmesAPI.AutoMapProfiles;

public class Profiles:Profile
{
    public Profiles()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
    }
}
