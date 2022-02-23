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
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeveloperController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<DeveloperDto> Get()
        {
            var Developers = _unitOfWork.Developers.GetAll();

            var DtoDevelopers = _mapper.Map<IEnumerable<DeveloperDto>>(Developers);

            return DtoDevelopers;
        }

        [HttpGet("{id}")]
        public DeveloperDto Get(int id)
        {
            var Developer = _unitOfWork.Developers.GetById(id);
            var DeveloperDto = _mapper.Map<DeveloperDto>(Developer);
            return DeveloperDto;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DeveloperCreateUpdateDto developer)
        {
            var DeveloperObj = _mapper.Map<Developer>(developer);
            _unitOfWork.Developers.Add(DeveloperObj);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DeveloperCreateUpdateDto developer)
        {
            var DeveloperObj = _unitOfWork.Developers.GetById(id);
            
            _mapper.Map<DeveloperCreateUpdateDto, Developer>(developer, DeveloperObj);

            _unitOfWork.Developers.Update(DeveloperObj);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Developer = _unitOfWork.Developers.GetById(id);
            _unitOfWork.Developers.Remove(Developer);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
