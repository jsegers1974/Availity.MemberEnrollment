using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Availity.MemberEnrollment;

namespace Availity.MemberEnrollment_Tests
{
    public class MemberEnrollmentFileDAL_Mock : IMemberEnrollmentDAL
    {
        List<EnrollmentRecord> _mockEnrollmentRecords;
        public MemberEnrollmentFileDAL_Mock()
        {
            _mockEnrollmentRecords = new List<EnrollmentRecord>();
            EnrollmentRecord r = new();
            r.InsuranceCompany = "AETNA";
            r.UserID = "jake123";
            r.FirstName = "Jake";
            r.LastName = "Segers";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "AETNA";
            r.UserID = "erica52";
            r.FirstName = "Erica";
            r.LastName = "Segers";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "BCBSLA";
            r.UserID = "john56";
            r.FirstName = "John";
            r.LastName = "Hadley";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "BCBSLA";
            r.UserID = "linda23";
            r.FirstName = "Linda";
            r.LastName = "Simpson";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "CTMEDICAID";
            r.UserID = "mike67";
            r.FirstName = "Mike";
            r.LastName = "Johnson";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "CTMEDICAID";
            r.UserID = "cindy21";
            r.FirstName = "Cindy";
            r.LastName = "Hanson";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "CTMEDICAID";
            r.UserID = "cindy21";
            r.FirstName = "Cindy";
            r.LastName = "Hanson";
            r.Version = 2;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "AETNA";
            r.UserID = "cindy21";
            r.FirstName = "Cindy";
            r.LastName = "Hanson";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "CTMEDICAID";
            r.UserID = "jas38";
            r.FirstName = "Jason";
            r.LastName = "Smith";
            r.Version = 1;
            _mockEnrollmentRecords.Add(r);

            r = new();
            r.InsuranceCompany = "CTMEDICAID";
            r.UserID = "jas38";
            r.FirstName = "Jason";
            r.LastName = "Smith";
            r.Version = 2;
            _mockEnrollmentRecords.Add(r);

        }
        public List<EnrollmentRecord> GetAll()
        {
            return _mockEnrollmentRecords;
        }

        public List<EnrollmentRecord> GetByInsuranceCompanyName(string insuranceCompanyName)
        {
            return _mockEnrollmentRecords.FindAll(x => x.InsuranceCompany.Equals(insuranceCompanyName));
        }

        public void Save(List<EnrollmentRecord> records)
        {
            throw new NotImplementedException();
        }
    }
}
