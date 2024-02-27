using DatabaseModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace PatientInformationPortal_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Allergy> repo;

        public AllergiesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repo = unitOfWork.GetRepo<Allergy>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAllergyData()
        {
            try
            {
                var data = await repo.GetAllData();
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
