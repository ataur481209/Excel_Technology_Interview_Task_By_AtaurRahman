using DatabaseModels.Models;
using DatabaseModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace PatientInformationPortal_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<Patient> patientRepo;
        private readonly IGenericRepo<NCD_Details> nCD_DetailsRepo;
        private readonly IGenericRepo<Allergies_Details> allergies_DetailsRepo;
        public PatientController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            patientRepo = unitOfWork.GetRepo<Patient>();
            nCD_DetailsRepo = unitOfWork.GetRepo<NCD_Details>();
            allergies_DetailsRepo = unitOfWork.GetRepo<Allergies_Details>();
        }

        [HttpGet("GetAllPatientData")]
        public async Task<IActionResult> GetAllPatientData()
        {
            try
            {
                var data = await patientRepo.GetAllData();
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //for ncd name and allergy name get attemt

        //public async Task<IActionResult> GetAllPatientData()
        //{
        //    try
        //    {
        //        var data = await patientRepo.GetAllData()
        //            .Include(p => p.Disease)
        //            .Include(p => p.NCD_Details)
        //            .Include(p => p.Allergies_Details)
        //            .ToListAsync();

        //        return Ok(data);
        //    }
        //    catch (Exception)
        //    {
        //        // Handle exception appropriately
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        

        [HttpGet("GetPatientData/{id}")]
        public async Task<IActionResult> GetPatientData(int id)
        {
            try
            {
                var data = await patientRepo.GetDataById(x => x.PatientId == id);
                if(data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("InsertPatientData")]
        public async Task<IActionResult> InsertPatientData(PatientInputModel data)
        {
            //insert into tblPatient
            Patient patient = new Patient
            {
                PatientName = data.PatientName,
                Epilepsy = data.Epilepsy,
                DiseaseId = data.DiseaseId
            };

            await patientRepo.InsertData(patient);
            await unitOfWork.CompleteAsync();

            //insert into tblNCD_Details
            foreach(int ncdId in data.NCD_Ids)
            {
                NCD_Details ncd_details = new NCD_Details
                {
                    NCD_Id = ncdId,
                    PatientId = patient.PatientId
                };
                await nCD_DetailsRepo.InsertData(ncd_details);
                await unitOfWork.CompleteAsync();
            }

            //insert into tblAllergy_Details
            foreach(int allergyId in data.Allergy_Ids)
            {
                Allergies_Details allergies_Details = new Allergies_Details
                {
                    AllergyId = allergyId,
                    PatientId = patient.PatientId
                };
                await allergies_DetailsRepo.InsertData(allergies_Details);
                await unitOfWork.CompleteAsync();
            }

            return Ok();
        }

        [HttpPut("UpdatePatientData")]
        public async Task<IActionResult> UpdatePatientData(PatientInputModel data)
        {
            // update tblPatient

            Patient patient = new Patient
            {
                PatientId = data.PatientId,
                PatientName = data.PatientName,
                DiseaseId = data.DiseaseId,
                Epilepsy = data.Epilepsy
            };
            await patientRepo.UpdateData(patient);
            await unitOfWork.CompleteAsync();

            // find out existing data and delete them.

            var existing_NCD_Details = await nCD_DetailsRepo.GetAllDataById(x=>x.PatientId == data.PatientId);

            var existing_Allergies_Details = await allergies_DetailsRepo.GetAllDataById(x => x.PatientId == data.PatientId);

            await nCD_DetailsRepo.DeleteData(existing_NCD_Details);
            await allergies_DetailsRepo.DeleteData(existing_Allergies_Details);

            await unitOfWork.CompleteAsync();

            // update tblNCD_Details

            foreach (int ncdId in data.NCD_Ids)
            {
                NCD_Details ncd_details = new NCD_Details
                {
                    NCD_Id = ncdId,
                    PatientId = data.PatientId
                };
                await nCD_DetailsRepo.InsertData(ncd_details);
                await unitOfWork.CompleteAsync();
            }

            // update tblAllergies_Details

            foreach (int allergyId in data.Allergy_Ids)
            {
                Allergies_Details allergies_Details = new Allergies_Details
                {
                    AllergyId = allergyId,
                    PatientId = data.PatientId
                };
                await allergies_DetailsRepo.InsertData(allergies_Details);
                await unitOfWork.CompleteAsync();
            }

            return Ok();
        }

        [HttpDelete("DeletePatientData/{patientId}")]
        public async Task<IActionResult> DeletePatientData(int patientId)
        {
            var dataToDelete = await patientRepo.GetDataById(x => x.PatientId == patientId);

            if(dataToDelete != null)
            {
                await patientRepo.DeleteData(dataToDelete);
                await unitOfWork.CompleteAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
