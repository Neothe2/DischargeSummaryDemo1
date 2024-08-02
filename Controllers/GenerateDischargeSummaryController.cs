using DischargeSummaryDemo1.Models;
using DischargeSummaryDemo1.Repositories;
using DischargeSummaryDemo1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DischargeSummaryDemo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateDischargeSummaryController : ControllerBase
    {
        [HttpPost("generateDischargeSummary")]
        public async Task<IActionResult> GenerateDischargeSummary([FromBody] SummaryInputData inputData)
        {
            if (inputData == null)
            {
                return BadRequest("Invalid input data");
            }

            // Print the input data for demonstration purposes
            Console.WriteLine($"Patient ID: {inputData.PatientID}");
            Console.WriteLine($"Admission Date: {inputData.AdmissionDate}");
            Console.WriteLine($"Discharge Date: {inputData.DischargeDate}");

            // You would typically call a service or logic to generate the summary here
            // ...

            MockDataRepository db = new MockDataRepository(@"C:\Users\neoja\OneDrive\AI Development\Datamate\DischargeReport\Data\discharge_summary.csv");
            SummaryData data = db.GetSummaryData(inputData);
            //SummaryData data = new SummaryData
            //{
            //    PatientNumber = 1,
            //    DateOfAdmission = DateTime.ParseExact("20/02/2024", "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None),
            //    DateOfDischarge = DateTime.ParseExact("24/12/2024", "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None),
            //    Diagnosis = "I10 - Essential (primary) hypertension, SL13 - TYPE 2 DIABETES MELLITUS, SL1 - CORONARY ARTERY DISEASE, IVDP-L4-L5 & L5-S1",
            //    HistoryOfIllness = "He presented to us with c/o LBA radiating to both lower limbs",
            //    ClinicalExamination = "Vitals-stable, SLRT- 60 degree, Chest-clear, cvs-s1s2 heard",
            //    PastMedicalHistory = "k/c/o T2DM,HTN & CAD",
            //    AdviceOnDischarge = "Sl# Medicine Dosage Frequency Route Period Quantity Remarks1 Dapagliflozin And Metformin Hcl Tab 10 Mg/500 Mg (Daplo-M 10 Tab) 1NO 1-0-0 Oral 90 Days 90 After Food, 2 Glimepride + Metformin (Glycomet Gp 1Mg Tab (15 S)) 1NO 0-0-1 Oral 90 Days 90 After Food, 3 Cilostazol (Cilodoc 100 Mg) 1NO 1-0-0 Oral 90 Days 90 After Food, 4 Iron (Salts/Complex) (Ferox Xt Tab) 1NO 1-0-0 Oral 90 Days 90 After Food, 5 Bisoprolol (Concor Cor 2.5 Tab) 1NO 1-0-0 Oral 90 Days 90 After Food, 6 Thyroxine (Thyronorm 75 Mcg Tab) 1NO 1-0-0 Oral 90 Days 90 1/2 Hr Before Food, 7 Tramadol 37.5Mg+ Acetaminophen 325Mg (Acuvin Tab) 1NO 1 SOS Oral 90 Days 180 After Food, 8 Polyethylene Glycol (Pegred) 1NO 0-0-1 Oral 90 Days 90 After Food, 9 Pregabalin (Lyrica 75 Mg Capsules) 1NO 0-0-1 Oral 14 Days 14 After Food, 10 Flupirtine Maleate 100 Mg (Lupirtin 100 Mg Cap) 1NO 1-0-1 Oral 14 Days 28 After, Tab Deplatt cv 40 0-0-1 x 90 days, Tab Efonta T 40/40 0-0-1 x 90 days, Tab GTN sorbitrate 2.6 1-0-1 x 90 days ( 8 am, 3 pm), C. Megabid 50mg 0-0-1 x 90 days"
            //};


            string system = "You are a medical professional tasked with creating detailed discharge summaries. Your role is to compile and organize patient information into a comprehensive and structured discharge summary document. Use the provided data to populate the summary, adhering strictly to the following format: Begin with a header section containing the hospital logo (if available), patient details (patient number, name, address, gender, age, mobile number, admission date, discharge date, and bed number), and the relevant department. Next, present the diagnosis, including the primary condition and any secondary diagnoses or complications. Follow this with a concise history of illness section. Then, provide a clinical examination section with relevant findings. Include a detailed discussion section elaborating on the patient's condition, treatments administered, and progress during the hospital stay. Add a diet section with nutritional recommendations and guidelines. Finally, create an 'Advice on Discharge' section listing all prescribed medications in a tabular format, including details such as dosage, frequency, route, duration, and any special instructions. If any required information is not provided in the input data, insert '[NO DATA GIVEN]' in the appropriate field or section. Ensure all available information is accurately represented and organized according to this structure. Maintain a professional tone throughout the document and use medical terminology where appropriate. Your goal is to produce a clear, comprehensive, and well-structured discharge summary that provides all necessary information for the patient's continued care.";
                             

            string prompt = data.ToString();
            

            AIService ai = new AIService();
            var response = await ai.Prompt(prompt, system);

            // Create an instance of ApiResponse with the response
            var apiResponse = new ApiResponse
            {
                Response = response
            };

            // Return the ApiResponse object as a JSON result
            return Ok(apiResponse);
        }
    }

    public class ApiResponse
    {
        public string Response { get; set; }
    }
}
