using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class Logic
    {
        public List<Doctor> doctors = new List<Doctor>();

        public void CreateDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public List<Doctor> GetDoctors() 
        { 
            return doctors; 
        }

        public bool DeleteDoctor(int id) 
        {
            Doctor doctor = doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null) {
                return false;
            }
            doctors.Remove(doctor);
            return true;
        }

        public bool UpdateDoctor(Doctor updatedDoctor)
        {
            Doctor doctor = doctors.FirstOrDefault(x => x.Id == updatedDoctor.Id);
            if (doctor == null)
            {
                return false;
            }
            doctor.FullName = updatedDoctor.FullName;
            doctor.Specialization = updatedDoctor.Specialization;
            doctor.Experience = updatedDoctor.Experience;
            doctor.Phone = updatedDoctor.Phone;
            doctor.Office = updatedDoctor.Office;
            return true;
        }

        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return doctors
                .GroupBy(x => x.Specialization)
                .ToDictionary(x => x.Key, x => x.ToList());
        }

        public List<Doctor> GetDoctorsWithExperience(int minExperience)
        {
            return doctors
                .Where(x =>  x.Experience >= minExperience)
                .ToList();
        }
    }
}
