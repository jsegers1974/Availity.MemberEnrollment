using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Availity.MemberEnrollment
{
    public class EnrollmentFileHandler
    {
        private IMemberEnrollmentDAL _memberEnrollmentDAL;
        
        public EnrollmentFileHandler(IMemberEnrollmentDAL memberEnrollmentDAL)
        {
            _memberEnrollmentDAL = memberEnrollmentDAL; 
        }

        public void ProcessEnrollmentFile()
        {
            MemberEnrollmentBL bl = new MemberEnrollmentBL(_memberEnrollmentDAL);
            List<EnrollmentRecord> distinctInsCoList = bl.GetDistinctInsuranceCompanyList();

            foreach(var item in distinctInsCoList)
            {
                List<EnrollmentRecord> recordsToSave = bl.GetSortedResultsToSave(item.InsuranceCompany);
                bl.Save(recordsToSave);

            }

        }
    }
}
