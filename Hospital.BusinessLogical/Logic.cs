using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.DataAccessLayer;
using Hospital.DataAccessLayer.Dapper;

namespace Hospital.BusinessLogical
{
    public class Logic
    {
        private readonly IRepository<Doctor> repository;

        public Logic()
        {
            repository = new DapperRepository<Doctor>();
        }

        public Logic(IRepository<Doctor> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Добавление нового врача в систему
        /// </summary>
        /// <param name="doctor">Врач, которого нужно добавить</param>
        public void CreateDoctor(Doctor doctor)
        {
            repository.Add(doctor);
        }

        public void CreateDoctor(
            string fullName,
            string specialization,
            int experience,
            string phone,
            int office)
        {
            var doctor = new Doctor
            {
                FullName = fullName,
                Specialization = specialization,
                Experience = experience,
                Phone = phone,
                Office = office
            };

            repository.Add(doctor);
        }
        /// <summary>
        /// Возвращает список всех врачей, которые есть в системе
        /// </summary>
        /// <returns>Список врачей</returns>
        public List<Doctor> GetDoctors()
        {
            return repository.ReadAll();
        }

        /// <summary>
        /// Удаление врача из системы по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор врача, которого нужно удалить</param>
        /// <returns>
        /// true, если врач найден и удалён
        /// false, если врач не найден
        /// </returns>
        public bool DeleteDoctor(int id)
        {
            return repository.Delete(id);
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
            return repository.Update(updatedDoctor);
        }

        /// <summary>
        /// Группировка врачей по их специализации
        /// </summary>
        /// <returns>
        /// Словарь, где ключ - название специализации,
        /// а значение - список врачей с этой специализацией
        /// </returns>
        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return repository
                .ReadAll()
                .GroupBy(x => x.Specialization)
                .ToDictionary(x => x.Key, x => x.ToList());
        }

        /// <summary>
        /// Возвращает врачей, стаж которых не меньше
        /// определенного количества лет
        /// </summary>
        /// <param name="minExperience">Минимальный стаж (годы)</param>
        /// <returns>Список врачей, соответствующих заданному стажу</returns>
        public List<Doctor> GetDoctorsWithExperience(int minExperience)
        {
            return repository
                .ReadAll()
                .Where(x => x.Experience >= minExperience)
                .ToList();
        }
    }
}