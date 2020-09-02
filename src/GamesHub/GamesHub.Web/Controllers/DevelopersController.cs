namespace GamesHub.Web.Controllers
{
    using AutoMapper;
    using GamesHub.Business.Contracts.Services;
    using GamesHub.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/developers")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        private readonly IMapper _mapper;

        public DevelopersController(IDeveloperService developerService, IMapper mapper)
        {
            _developerService = developerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<DeveloperModel>> GetAll()
        {
            var developers = await _developerService.GetAll();
            var developersModel = _mapper.Map<List<DeveloperModel>>(developers);
            return developersModel;
        }
    }
}
