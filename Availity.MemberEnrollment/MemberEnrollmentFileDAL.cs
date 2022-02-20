using System;
using System.IO;
using System.Collections.Generic;

namespace Availity.MemberEnrollment
{
    public class MemberEnrollmentFileDAL : IMemberEnrollmentDAL
    {
        private List<EnrollmentRecord> _enrollmentRecords; 
        private string _sourceFilePath;
        private string _destinationDirectory;
        public MemberEnrollmentFileDAL(string sourceFilePath, string destinationDirectory)
        {
            _sourceFilePath = sourceFilePath;
            _destinationDirectory = destinationDirectory;
            _enrollmentRecords = new List<EnrollmentRecord>();

        }


        public List<EnrollmentRecord> GetByInsuranceCompanyName(string insuranceCompanyName)
        {
            return _enrollmentRecords.FindAll(x => x.InsuranceCompany.Equals(insuranceCompanyName));
        }

        public List<EnrollmentRecord> GetAll()
        {
            return _enrollmentRecords;
        }

        public void Open()
        {
            using (StreamReader reader = new StreamReader(_sourceFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    EnrollmentRecord record = new();
                    string[] elements = line.Split(',');                    
                    record.UserID = elements[0];
                    record.FirstName = elements[1];
                    record.LastName = elements[2];
                    int version;
                    version = int.TryParse(elements[3], out version) ? version : default(int);
                    record.Version = version;
                    record.InsuranceCompany = elements[4];
                    _enrollmentRecords.Add(record);

                }
            }
            
        }
        public void Save(List<EnrollmentRecord> records)
        {
            string insuranceCompany = string.Empty;
            try
            {
                insuranceCompany = records[0].InsuranceCompany;
                string fileName = $"{insuranceCompany}_EnrollmentFile_{DateTime.Now:s}.csv".Replace(":","");

                using StreamWriter w = new(_destinationDirectory + fileName);
                foreach (EnrollmentRecord er in records)
                {
                    string line = $"{er.UserID},{er.FirstName},{er.LastName},{er.Version},{er.InsuranceCompany}";
                    w.WriteLine(line);
                    w.Flush();
                }

            }
            catch (Exception ex)
            {
                string message = string.Format("An error occurred while writing file for payer: {0}", insuranceCompany);
                throw new Exception(message, ex);

            }
        }
    }
}
