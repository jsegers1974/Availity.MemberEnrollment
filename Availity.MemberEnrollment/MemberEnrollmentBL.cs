using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Availity.MemberEnrollment
{
    public class MemberEnrollmentBL
    {
        private IMemberEnrollmentDAL _memberEnrollmentDAL;
        public MemberEnrollmentBL(IMemberEnrollmentDAL memberEnrollmentDAL)
        {
            _memberEnrollmentDAL = memberEnrollmentDAL;
        } 
        public List<EnrollmentRecord> GetDistinctInsuranceCompanyList()
        {
            List<EnrollmentRecord> records = _memberEnrollmentDAL.GetAll();
            return records.GroupBy(x => x.InsuranceCompany).Select(y => y.First()).ToList();
        }

        public List<EnrollmentRecord> GetByInsuranceCompanyName(string insuranceCompanyName)
        {
            return _memberEnrollmentDAL.GetByInsuranceCompanyName(insuranceCompanyName);
        }

        public List<EnrollmentRecord> GetLatestVersionByInsuranceCompanyName(string insuranceCompanyName)
        {
            var results = _memberEnrollmentDAL.GetByInsuranceCompanyName(insuranceCompanyName);

            return results.GroupBy(x => new { x.InsuranceCompany, x.UserID })
                .Select(g => g.OrderByDescending(y => y.Version).First()).ToList();
        }

        public List<EnrollmentRecord> GetSortedResultsToSave(string insuranceCompanyName)
        {
            var results = GetLatestVersionByInsuranceCompanyName(insuranceCompanyName);
            return results.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }
        public void Save(List<EnrollmentRecord> enrollmentRecords)
        {
            _memberEnrollmentDAL.Save(enrollmentRecords);
        }
        
    }
}
