using Core.UnitOfWorks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IReadOnlyList<FoodEntity>> Get()
        {
            return await _unitOfWork.Foods.GetAllAsync();

        }

    }
}
