using System;
using Availity.MemberEnrollment;

namespace Availity.MemberEnrollment.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"C:\EnrollmentFiles\Input\SampleEnrollmentFile.csv";
            string destinationDir = @"C:\EnrollmentFiles\Output\";
            Console.WriteLine($"Reading file from {sourceFilePath}");
            MemberEnrollment.MemberEnrollmentFileDAL fileDAL = new(sourceFilePath, destinationDir);
            fileDAL.Open();

            EnrollmentFileHandler fh = new EnrollmentFileHandler(fileDAL);
            fh.ProcessEnrollmentFile();
            Console.WriteLine($"Payer files written successfully to {destinationDir}");
            Console.ReadLine();
        }
       
    }
}
