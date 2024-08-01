using DischargeSummaryDemo1.Models;

namespace DischargeSummaryDemo1.Repositories
{
    public class SummaryDataRepository
    {
        private readonly string _csvFilePath;

        public SummaryDataRepository(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public SummaryData GetSummaryData(SummaryInputData input)
        {
            using (var reader = new StreamReader(_csvFilePath))
            {
                // Assuming CSV header is present
                var header = reader.ReadLine().Split(',');

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length != header.Length)
                    {
                        // Handle invalid data
                        continue;
                    }

                    int patientId;
                    DateTime admissionDate, dischargeDate;

                    // Validate and parse patientId
                    if (!int.TryParse(values[0], out patientId))
                    {
                        // Handle invalid patientId
                        continue;
                    }

                    // Validate and parse admissionDate
                    if (!DateTime.TryParseExact(values[1], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out admissionDate))
                    {
                        // Handle invalid admissionDate
                        continue;
                    }

                    // Validate and parse dischargeDate
                    if (!DateTime.TryParseExact(values[2], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dischargeDate))
                    {
                        // Handle invalid dischargeDate
                        continue;
                    }

                    if (patientId == input.PatientID &&
                        admissionDate == DateTime.ParseExact(input.AdmissionDate, "dd/MM/yyyy", null) &&
                        dischargeDate == DateTime.ParseExact(input.DischargeDate, "dd/MM/yyyy", null))
                    {
                        return new SummaryData
                        {
                            PatientNumber = patientId,
                            DateOfAdmission = admissionDate,
                            DateOfDischarge = dischargeDate,
                            Diagnosis = values.Length > 3 ? values[3] : string.Empty,
                            HistoryOfIllness = values.Length > 4 ? values[4] : string.Empty,
                            ClinicalExamination = values.Length > 5 ? values[5] : string.Empty,
                            PastMedicalHistory = values.Length > 6 ? values[6] : string.Empty,
                            AdviceOnDischarge = values.Length > 7 ? values[7] : string.Empty
                        };
                    }
                }
            }

            // Handle case where no matching record found
            return null;
        }

    }
}
