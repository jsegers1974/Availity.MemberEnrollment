using Microsoft.VisualStudio.TestTools.UnitTesting;
using Availity.MemberEnrollment;
using System.Collections.Generic;
using System.Linq;

namespace Availity.MemberEnrollment_Tests
{
    [TestClass]
    public class MemberEnrollmentBL_Test
    {
        IMemberEnrollmentDAL _dataAccessLayer;
        MemberEnrollmentBL _bizLayer;
        List<EnrollmentRecord> _mockEnrollmentRecords;
        const string SOURCE_FILE_NAME = @"C:\EnrollmentFiles";
        const string OUTPUT_DIR = @"C:\EnrollmentFiles\Output";

        [TestInitialize]
        public void TestInitialize()
        {
            _dataAccessLayer = new MemberEnrollmentFileDAL_Mock();
            _bizLayer = new MemberEnrollmentBL(_dataAccessLayer);
            //SetupMockData();
        }

        [TestMethod]
        public void MemberEnrollmentBL_GetDistinctInsuranceCompanyList_Test()
        {
            
            List<EnrollmentRecord> lst = _bizLayer.GetDistinctInsuranceCompanyList();

            var query = lst.GroupBy(x => x.InsuranceCompany)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            Assert.IsTrue(query.Count == 0);
        }

        [TestMethod]
        public void MemberEnrollmentBL_GetByInsuranceCompanyName_Test()
        {
            List<EnrollmentRecord> lst = _bizLayer.GetByInsuranceCompanyName("AETNA");
            bool result = lst.Any(x => x.InsuranceCompany.Equals("AETNA"));
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void MemberEnrollmentBL_GetLatestVersionByInsuranceCompanyName()
        {
            /*
             * We should see this record come back in the test and no other record with userID = "jas38"
             *  r.InsuranceCompany = "CTMEDICAID";
                r.UserID = "jas38";
                r.FirstName = "Jason";
                r.LastName = "Smith";
                r.Version = 2;
             */
            List<EnrollmentRecord> lst = _bizLayer.GetLatestVersionByInsuranceCompanyName("CTMEDICAID");
            var query = lst.Where(y => y.UserID.Equals("jas38")).ToList();
            Assert.IsTrue(query.Count == 1);           
        }


        private void SetupMockData()
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
    }
}
