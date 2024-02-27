using DatabaseModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace PatientInformationPortal_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Disease> repo;

        public DiseaseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repo = this.unitOfWork.GetRepo<Disease>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiseases()
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
