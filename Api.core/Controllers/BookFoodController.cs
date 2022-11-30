using Domain.Dto;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookFoodController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookFoodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IReadOnlyList<BookFoodDto>> GetBooksFood(string securityCode)
        {
            return await _unitOfWork.BookFoods.GetOrderFood(securityCode);

        }

    }
}
