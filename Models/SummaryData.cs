namespace DischargeSummaryDemo1.Models
{
    public class SummaryData
    {
        public int PatientNumber { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public string Diagnosis { get; set; }
        public string HistoryOfIllness { get; set; }
        public string ClinicalExamination { get; set; }
        public string PastMedicalHistory { get; set; }
        public string AdviceOnDischarge { get; set; }

        public override string ToString()
        {
            return $"[Patient Number: {PatientNumber}, " +
                   $"Admission: {DateOfAdmission:d}, Discharge: {DateOfDischarge:d}, " +
                   $"Diagnosis: {Diagnosis}, History of Illness: {HistoryOfIllness}, Clinical Examination: {ClinicalExamination}" +
                   $"Past Medical History: {PastMedicalHistory},Advice On Discharge: {AdviceOnDischarge}]";
        }
    }
}
