using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApi.Data.Interfaces;
using TestApi.Dto;
using TestApi.Entities;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        /// <comment>
        /// Commentor: Md Amanul Haque
        /// Apply the following for all controllers
        /// 
        /// 1. change the rest methods to use async
        /// Example: public async Task<ProjectDto> Get(int id)
        /// 2. Use try-Catch block in the rest methods
        /// Example: 
        /// [HttpGet]
        /// public async Task<IEnumerable<ProjectDto>> Get()
        /// {
        ///    try
        ///    {
        ///     var Projects = _unitOfWork.Projects.GetAll();

        ///     var DtoProjects = _mapper.Map<IEnumerable<ProjectDto>>(Projects);

        ///     return Ok(DtoProjects);
        ///    }
        ///    catch (Exception ex)
        ///    {
        ///       // Log the exception
        ///       return BadRequeest("Error on fetching project data");
        ///    }
        ///  }
        /// </comment>

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProjectDto> Get()
        {
            var Projects = _unitOfWork.Projects.GetAll();

            var DtoProjects = _mapper.Map<IEnumerable<ProjectDto>>(Projects);

            return DtoProjects;
            
        }

        [HttpGet("{id}")]
        public ProjectDto Get(int id)
        {
            var Project = _unitOfWork.Projects.GetById(id);
            var ProjectDto = _mapper.Map<ProjectDto>(Project);
            return ProjectDto;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProjectCreateUpdateDto Project)
        {
            // 
            var ProjectObj = _mapper.Map<Project>(Project);
            _unitOfWork.Projects.Add(ProjectObj);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectCreateUpdateDto Project)
        {
            var ProjectObj = _unitOfWork.Projects.GetById(id);
            
            _mapper.Map<ProjectCreateUpdateDto, Project>(Project, ProjectObj);

            _unitOfWork.Projects.Update(ProjectObj);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Project = _unitOfWork.Projects.GetById(id);
            _unitOfWork.Projects.Remove(Project);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
