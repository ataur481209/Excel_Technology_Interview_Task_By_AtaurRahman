using DatabaseModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace PatientInformationPortal_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<NCD> repo;
        public NCDController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repo = this.unitOfWork.GetRepo<NCD>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNCDs()
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
