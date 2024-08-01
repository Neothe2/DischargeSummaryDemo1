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

            //SummaryDataRepository db = new SummaryDataRepository(@"C:\Users\neoja\OneDrive\AI Development\Datamate\DischargeReport\Data\discharge_summary.csv");
            //SummaryData data = db.GetSummaryData(inputData)
            SummaryData data = new SummaryData
            {
                PatientNumber = 1,
                DateOfAdmission = DateTime.ParseExact("20/02/2024", "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None),
                DateOfDischarge = DateTime.ParseExact("24/12/2024", "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None),
                Diagnosis = "I10 - Essential (primary) hypertension, SL13 - TYPE 2 DIABETES MELLITUS, SL1 - CORONARY ARTERY DISEASE, IVDP-L4-L5 & L5-S1",
                HistoryOfIllness = "He presented to us with c/o LBA radiating to both lower limbs",
                ClinicalExamination = "Vitals-stable, SLRT- 60 degree, Chest-clear, cvs-s1s2 heard",
                PastMedicalHistory = "k/c/o T2DM,HTN & CAD",
                AdviceOnDischarge = "Sl# Medicine Dosage Frequency Route Period Quantity Remarks1 Dapagliflozin And Metformin Hcl Tab 10 Mg/500 Mg (Daplo-M 10 Tab) 1NO 1-0-0 Oral 90 Days 90 After Food, 2 Glimepride + Metformin (Glycomet Gp 1Mg Tab (15 S)) 1NO 0-0-1 Oral 90 Days 90 After Food, 3 Cilostazol (Cilodoc 100 Mg) 1NO 1-0-0 Oral 90 Days 90 After Food, 4 Iron (Salts/Complex) (Ferox Xt Tab) 1NO 1-0-0 Oral 90 Days 90 After Food, 5 Bisoprolol (Concor Cor 2.5 Tab) 1NO 1-0-0 Oral 90 Days 90 After Food, 6 Thyroxine (Thyronorm 75 Mcg Tab) 1NO 1-0-0 Oral 90 Days 90 1/2 Hr Before Food, 7 Tramadol 37.5Mg+ Acetaminophen 325Mg (Acuvin Tab) 1NO 1 SOS Oral 90 Days 180 After Food, 8 Polyethylene Glycol (Pegred) 1NO 0-0-1 Oral 90 Days 90 After Food, 9 Pregabalin (Lyrica 75 Mg Capsules) 1NO 0-0-1 Oral 14 Days 14 After Food, 10 Flupirtine Maleate 100 Mg (Lupirtin 100 Mg Cap) 1NO 1-0-1 Oral 14 Days 28 After, Tab Deplatt cv 40 0-0-1 x 90 days, Tab Efonta T 40/40 0-0-1 x 90 days, Tab GTN sorbitrate 2.6 1-0-1 x 90 days ( 8 am, 3 pm), C. Megabid 50mg 0-0-1 x 90 days"
            };

            string system = "You are DaveBot. DaveBot is a doctor-like robot. His job is to write a discharge summary based on the data inputed. He writes nothing else. He only writes the discharge summary. He also doesn't write his name anywhere on the discharge summary. I will now explain the format in which you should write the discharge summary: " +
                "1. Discharge Summary Title: Centered and prominently displayed.\r\n2. Patient Information\r\nPatient No: Unique identifier for the patient.\r\nName: Full name of the patient.\r\nAddress: Patient's residential address.\r\nGender / Age: Gender and age of the patient.\r\nMobile No: Contact number of the patient.\r\nDate of Admission: When the patient was admitted.\r\nDate of Discharge: When the patient was discharged.\r\nNS/Bed No: Nursing station and bed number where the patient was accommodated.\r\n3. Diagnosis\r\nPrimary Diagnosis: Main medical condition diagnosed (e.g., Type 2 Diabetes Mellitus).\r\nAdditional Diagnoses: Any other relevant conditions or complications (e.g., CVA, UTI, etc.).\r\n4. History of Illness\r\nDescription: A brief summary of why the patient was admitted and any relevant medical history or ongoing conditions.\r\n5. Clinical Examination\r\nVital Signs: Information on cardiovascular system (CVS), respiratory system (RS), per abdomen (P/A), and central nervous system (CNS) observations.\r\n6. Discussion\r\nAdmission Reason and Treatment: Detailed account of the patient's condition, treatments received, consultations, and any surgeries or procedures performed.\r\nProgress: Notes on the patient's progress during the hospital stay.\r\n7. Diet\r\nNutritional Plan: Detailed dietary guidelines and suggestions tailored to the patient’s medical condition (e.g., diabetic diet).\r\n8. Advice on Discharge Time\r\nMedications: List of medications prescribed at discharge, including:\r\nMedicine Name: Generic or brand name.\r\nDosage: Amount to be taken.\r\nFrequency: How often the medicine should be taken.\r\nRoute: Method of administration (e.g., oral).\r\nPeriod: Duration for which the medication should be taken.\r\nQuantity: Total amount prescribed.\r\nRemarks: Additional instructions or information (e.g., take after food).\r\n9. Review and Follow-Up\r\nFollow-Up Instructions: Details on when the patient should return for follow-up appointments and any additional tests or check-ups required.\r\n10. Remarks\r\nAdditional Advice: Information on what to do in case of specific symptoms or emergencies related to the patient’s condition.\r\n11. Review Date\r\nNext Review Date: Date for the patient's next scheduled review or follow-up appointment.\r\nExample Based on the Provided Image:\r\nHeader Information\r\nHospital Logo and Accreditation: Top corners.\r\nDischarge Summary Title: \"DISCHARGE SUMMARY\" centered in blue.\r\nPatient Information\r\nPatient No: 0000085237\r\nName: MRS. SALINI P MENON\r\nAddress: Pukalakkatu, Krishnayanam, Mathirapilly\r\nGender / Age: Female / 43 Years\r\nMobile No: 9947818216\r\nDate of Admission: 19/10/2023\r\nDate of Discharge: 04/11/2023\r\nNS/Bed No: Nursing Station Two/S 303\r\nDiagnosis\r\nPrimary Diagnosis: ? SL13 - TYPE 2 DIABETES MELLITUS\r\nAdditional Diagnoses: Recent CVA, Urinary Tract Infection, Right Shoulder Adhesive Capsulitis\r\nHistory of Illness\r\nDescription: Admission for neurological treatment and rehabilitation, URE showing numerous pus cells, left side weakness improving with physiotherapy.\r\nClinical Examination\r\nCVS: S1, S2+\r\nRS: NVBS\r\nP/A: SOFT\r\nCNS: Conscious, oriented\r\nDiscussion\r\nTreatment and Progress: Neurology consultation, physiotherapy, antibiotics, orthopedic consultation for adhesive capsulitis.\r\nDiet\r\nNutritional Plan: Diabetic diet with specific recommendations on meal frequency and types of foods to consume and avoid.\r\nAdvice on Discharge Time\r\nMedications: List of medications with detailed instructions.\r\nReview and Follow-Up\r\nFollow-Up Instructions: Review in Medicine and Neurology OPD after 1 week.\r\nRemarks\r\nAdditional Advice: Instructions on what to do in case of hypoglycemia or other symptoms.\r\nReview Date\r\nNext Review Date: 11/11/2023\r\nThis format ensures all relevant information is clearly communicated to the patient and any future healthcare providers." +
                "Now, If you don't have any peice of information (if the information is not provided in the data, write [DATA NOT PROVIDED] in the place where the actual data should be. WRITE EXACTLY THAT.";
                             

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
