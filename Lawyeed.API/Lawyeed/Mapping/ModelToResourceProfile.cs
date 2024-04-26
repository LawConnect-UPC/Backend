using AutoMapper;
using Lawyeed.API.Lawyeed.Domain.Models;
using Lawyeed.API.Lawyeed.Resources;


namespace PersonalWorld.API.Personal.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Person, PersonResource>();

    }
}