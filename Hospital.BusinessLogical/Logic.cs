using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Model;

namespace Hospital.BusinessLogical
{
    public class Logic
    {
        public List<Doctor> doctors = new List<Doctor>();

        /// <summary>
        /// Добавление нового врача в систему
        /// </summary>
        /// <param name="doctor">Врач, которого нужно добавить</param>
        public void CreateDoctor(Doctor doctor)
        {
            if (doctors.Count > 0)
            {
                doctor.Id = doctors.Max(d => d.Id) + 1;
            }
            else
            {
                doctor.Id = 1;
            }

            doctors.Add(doctor);
        }

        /// <summary>
        /// Возвращает список всех врачей, которые есть в системе
        /// </summary>
        /// <returns>Список врачей</returns>
        public List<Doctor> GetDoctors() 
        { 
            return doctors; 
        }

        /// <summary>
        /// Удаление врача из системы по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор врача, которого нужно удалить</param>
        /// <returns>
        /// true, если врач найден и удален
        /// false, если врач не найден
        /// </returns>
        public bool DeleteDoctor(int id) 
        {
            Doctor doctor = doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null) {
                return false;
            }
            doctors.Remove(doctor);
            return true;
        }

        /// <summary>
        /// Изменение данных об определенном враче
        /// </summary>
        /// <param name="updatedDoctor">Врач с измененными данными</param>
        /// <returns>
        /// true, если врач найден и изменен
        /// false, если врач не найден
        /// </returns>
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

        /// <summary>
        /// Группировка врачей по их специализации
        /// </summary>
        /// <returns>Словарь, где ключ - название специализации, а значение - список врачей с этой специализацией</returns>
        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return doctors
                .GroupBy(x => x.Specialization)
                .ToDictionary(x => x.Key, x => x.ToList());
        }

        /// <summary>
        /// Возвращает врачей, стаж которых не меньше определенного количества лет
        /// </summary>
        /// <param name="minExperience">Минимальный стаж (годы)</param>
        /// <returns>Список врачей, соответствующих заданному стажу</returns>
        public List<Doctor> GetDoctorsWithExperience(int minExperience)
        {
            return doctors
                .Where(x =>  x.Experience >= minExperience)
                .ToList();
        }
    }
}
