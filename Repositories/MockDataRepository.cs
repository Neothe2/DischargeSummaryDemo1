using DischargeSummaryDemo1.Models;

namespace DischargeSummaryDemo1.Repositories
{
    public class MockDataRepository
    {
        private readonly string _csvFilePath;
        public MockDataRepository(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public SummaryData GetSummaryData(SummaryInputData input)
        {
            //Create list of hardcoded summary data objects

            //loop list of summary data
            //if (input.admitdate == data.admitdate && input.dischargedate == data.dischargedate && input.patientId == data.patientId)
            //parse dischargeDate and AdmitDate
            return new SummaryData
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
        }
    }
}
