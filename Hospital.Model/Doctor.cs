using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class Doctor
    {
        public int Id {  get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public string Phone {  get; set; }
        public int Office { get; set; }
    }
}
