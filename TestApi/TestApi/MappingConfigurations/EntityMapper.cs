using AutoMapper;
using TestApi.Dto;
using TestApi.Entities;

namespace TestApi.MappingConfigurations
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<Developer, DeveloperDto>();
            CreateMap<DeveloperCreateUpdateDto, Developer>();
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectCreateUpdateDto, Project>();
        }
    }
}
