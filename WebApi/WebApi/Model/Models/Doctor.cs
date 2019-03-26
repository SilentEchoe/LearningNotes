using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string DoctorName { get; set; }

        public string Sex { get; set; }

        public string HospitalName { get; set; }

        public string DepartmentName { get; set; }
        public string Money { get; set; }

        public string Remark { get; set; }
    }
}
