using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PatientPortal_Client.Helpers;
using PatientPortal_Client.ViewModels;
using PatientPortal_Client.Models;

namespace PatientPortal_Client.Controllers
{
    public class PatientController : Controller
    {
        
        WebApi api = new WebApi();

        //public async Task<IActionResult> AllPatientsData()
        //{
        //    List<Patient> patientList = new List<Patient>();
        //    HttpClient client = api.Initial();
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:5031/api/Patient/GetAllPatientData");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        patientList = JsonConvert.DeserializeObject<List<Patient>>(result);
        //    }
        //    return View(patientList);

        //}

        // ... (existing code)

        public async Task<IActionResult> AllPatientsData()
        {
            List<PatientDetailsViewModel> patientDetailsList = new List<PatientDetailsViewModel>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5031/api/Patient/GetAllPatientData");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var patients = JsonConvert.DeserializeObject<List<Patient>>(result);

                foreach (var patient in patients)
                {
                    var patientDetails = new PatientDetailsViewModel
                    {
                        PatientId = patient.PatientId,
                        PatientName = patient.PatientName,
                        Epilepsy = patient.Epilepsy,
                        DiseaseId = patient.DiseaseId,
                        DiseaseName = patient.DiseaseName,
                        NCD_Ids = patient.NCD_Ids,
                        Allergy_Ids = patient.Allergy_Ids,
                        NCD_Names = await GetNCDNames(patient.NCD_Ids),
                        Allergy_Names = await GetAllergyNames(patient.Allergy_Ids)
                    };

                    patientDetailsList.Add(patientDetails);
                }
            }

            return View(patientDetailsList);
        }

        private async Task<List<string>> GetNCDNames(List<int>? ncdIds)
        {
            if (ncdIds == null || !ncdIds.Any())
            {
                return new List<string>();
            }

            var ncdList = await GetAllNCDs();

            return ncdList.Where(ncd => ncdIds.Contains(ncd.NCD_Id)).Select(ncd => ncd.NCD_Name).ToList();
        }

        private async Task<List<string>> GetAllergyNames(List<int>? allergyIds)
        {
            if (allergyIds == null || !allergyIds.Any())
            {
                return new List<string>();
            }

            var allergyList = await GetAllAllergies();

            return allergyList.Where(allergy => allergyIds.Contains(allergy.AllergyId)).Select(allergy => allergy.AllergyName).ToList();
        }





        public async Task<IEnumerable<Disease>> GetAllDisease()
        {
            List<Disease> diseaselist = new List<Disease>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5031/api/Disease");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                diseaselist = JsonConvert.DeserializeObject<List<Disease>>(result);
            }
            return diseaselist;
        }

        public async Task<IEnumerable<NCD>> GetAllNCDs()
        {
            List<NCD> ncdList = new List<NCD>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5031/api/NCD");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                ncdList = JsonConvert.DeserializeObject<List<NCD>>(result);
            }
            return ncdList;
        }

        public async Task<IEnumerable<Allergy>> GetAllAllergies()
        {
            List<Allergy> allergyList = new List<Allergy>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5031/api/Allergies");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                allergyList = JsonConvert.DeserializeObject<List<Allergy>>(result);
            }
            return allergyList;
        }

        public async Task<IActionResult> InsertPatientData()
        {
            var diseaseList = await GetAllDisease();
            ViewBag.diseases = new SelectList(diseaseList, "DiseaseId", "DiseaseName");

            var epilepsy = Enum.GetValues(typeof(Epilepsy)).Cast<Epilepsy>();
            ViewBag.epilepsy = new SelectList(epilepsy);

            var ncdList = await GetAllNCDs();
            ViewBag.ncds = ncdList;

            var allergyList = await GetAllAllergies();
            ViewBag.allergies = allergyList;    

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertPatientData(PatientInputModel modelData, [FromForm] List<int> NCD_Ids) 
        {
            HttpClient client = api.Initial();

            var postData = client.PostAsJsonAsync<PatientInputModel>("http://localhost:5031/api/Patient/InsertPatientData", modelData);

            postData.Wait();

            var result = postData.Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("AllPatientsData");
            }

            return View();
        }

        public async Task<IActionResult> EditPatientData(int id)
        {
            // Fetch patient data by id
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5031/api/Patient/GetPatientData/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var patient = JsonConvert.DeserializeObject<PatientInputModel>(result);

                // Fetch additional data needed for dropdowns, similar to InsertPatientData action

                return View(patient);
            }

            return RedirectToAction("AllPatientsData");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPatientData(PatientInputModel modelData, [FromForm] List<int> NCD_Ids)
        {
            // Update patient data
            HttpClient client = api.Initial();
            var putData = client.PutAsJsonAsync<PatientInputModel>("http://localhost:5031/api/Patient/UpdatePatientData", modelData);

            putData.Wait();

            var result = putData.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("AllPatientsData");
            }

            // Handle errors if needed
            return View(modelData);
        }

        public async Task<IActionResult> DeletePatientData(int id)
        {
            var patient = new Patient();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"http://localhost:5031/api/Patient/DeletePatientData/{id}");

            return RedirectToAction("AllPatientsData");
        }
    }
}
