using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamesHub.Business.Contracts.Services;
using GamesHub.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesHub.Web.Controllers
{
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
