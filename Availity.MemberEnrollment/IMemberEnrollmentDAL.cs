using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Availity.MemberEnrollment
{
    public interface IMemberEnrollmentDAL
    {
        public List<EnrollmentRecord> GetAll();
        public List<EnrollmentRecord> GetByInsuranceCompanyName(string insuranceCompanyName);
        public void Save(List<EnrollmentRecord> records);
    }
}
