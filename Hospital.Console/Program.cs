using Hospital.BusinessLogical;
using Hospital.Model;

namespace Hospital.Console
{
    internal class Program
    {
        /// <summary>
        /// Экземпляр бизнес-логики для работы с врачами
        /// </summary>
        static Logic _logic = new Logic();

        /// <summary>
        /// Точка входа в консольное приложение
        /// Запускает главное меню и обрабатывает выбор пользователя
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("=== УЧЁТ ВРАЧЕЙ ===");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Показать всех врачей");
                System.Console.WriteLine("2. Добавить врача");
                System.Console.WriteLine("3. Изменить данные врача");
                System.Console.WriteLine("4. Удалить врача");
                System.Console.WriteLine("5. Группировать по специализации");
                System.Console.WriteLine("6. Найти врачей по стажу");
                System.Console.WriteLine("0. Выход");
                System.Console.WriteLine();
                System.Console.Write("Выберите действие: ");

                string? choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllDoctors();
                        break;
                    case "2":
                        AddDoctor();
                        break;
                    case "3":
                        UpdateDoctor();
                        break;
                    case "4":
                        DeleteDoctor();
                        break;
                    case "5":
                        GroupBySpecialization();
                        break;
                    case "6":
                        FindByExperience();
                        break;
                    case "0":
                        return;
                    default:
                        System.Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                        System.Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Отображает список всех врачей, зарегистрированных в системе,
        /// в виде отформатированной таблицы
        /// </summary>
        static void ShowAllDoctors()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== СПИСОК ВРАЧЕЙ ===");
            System.Console.WriteLine();

            var doctors = _logic.GetDoctors();

            if (doctors.Count == 0)
            {
                System.Console.WriteLine("Список врачей пуст.");
            }
            else
            {
                System.Console.WriteLine($"{"ID",-5} {"ФИО",-25} {"Специализация",-15} {"Стаж",-6} {"Телефон",-15} {"Кабинет"}");
                System.Console.WriteLine(new string('-', 90));

                foreach (var doctor in doctors)
                {
                    System.Console.WriteLine($"{doctor.Id,-5} {doctor.FullName,-25} {doctor.Specialization,-15} {doctor.Experience,-6} {doctor.Phone,-15} {doctor.Office}");
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Добавляет нового врача в систему
        /// Запрашивает у пользователя все необходимые данные и проверяет корректность специализации
        /// </summary>
        static void AddDoctor()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== ДОБАВЛЕНИЕ ВРАЧА ===");
            System.Console.WriteLine();

            System.Console.Write("ФИО: ");
            string? fullName = System.Console.ReadLine();

            string[] validSpecializations = new string[] {
                "Кардиолог",
                "Стоматолог",
                "Терапевт",
                "Хирург",
                "Невролог",
                "Педиатр",
                "Офтальмолог",
                "Дерматолог"
            };

            string? specialization;
            while (true)
            {
                System.Console.Write("Специализация (Кардиолог/Стоматолог/Терапевт/Хирург/Невролог/Педиатр/Офтальмолог/Дерматолог): ");
                specialization = System.Console.ReadLine();

                if (validSpecializations.Contains(specialization, StringComparer.OrdinalIgnoreCase))
                {
                    specialization = validSpecializations.First(s =>
                        s.Equals(specialization, StringComparison.OrdinalIgnoreCase));
                    break;
                }
                else
                {
                    System.Console.WriteLine("Ошибка: неверная специализация!");
                    System.Console.WriteLine("Доступные специализации:");
                    foreach (var spec in validSpecializations)
                    {
                        System.Console.WriteLine($"  - {spec}");
                    }
                    System.Console.WriteLine("Попробуйте снова.");
                    System.Console.WriteLine();
                }
            }

            int experience = ReadInt("Стаж (лет): ");

            System.Console.Write("Телефон: ");
            string? phone = System.Console.ReadLine();

            int office = ReadInt("Номер кабинета: ");

            var doctor = new Doctor
            {
                Id = _logic.GetDoctors().Count > 0 ? _logic.GetDoctors().Max(d => d.Id) + 1 : 1,
                FullName = fullName ?? "",
                Specialization = specialization ?? "",
                Experience = experience,
                Phone = phone ?? "",
                Office = office
            };

            _logic.CreateDoctor(doctor);

            System.Console.WriteLine();
            System.Console.WriteLine("Врач успешно добавлен!");
            System.Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Изменяет данные существующего врача
        /// Позволяет пользователю выборочно обновить поля, оставив пустые значения без изменений
        /// </summary>
        static void UpdateDoctor()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== ИЗМЕНЕНИЕ ДАННЫХ ВРАЧА ===");
            System.Console.WriteLine();

            ShowAllDoctors();

            if (_logic.GetDoctors().Count == 0)
                return;

            int id = ReadInt("Введите ID врача для изменения: ");

            var doctors = _logic.GetDoctors();
            var doctor = doctors.FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                System.Console.WriteLine("Врач с таким ID не найден!");
                System.Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
                System.Console.ReadKey();
                return;
            }

            System.Console.WriteLine();
            System.Console.WriteLine($"Текущие данные: {doctor.FullName}");
            System.Console.WriteLine();

            System.Console.Write("Новое ФИО (оставьте пустым, чтобы не менять): ");
            string? fullName = System.Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fullName))
                doctor.FullName = fullName;

            System.Console.Write("Новая специализация (оставьте пустым, чтобы не менять): ");
            string? specialization = System.Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(specialization))
                doctor.Specialization = specialization;

            System.Console.Write("Новый стаж (0 - не менять): ");
            int experience = ReadInt("");
            if (experience > 0)
                doctor.Experience = experience;

            System.Console.Write("Новый телефон (оставьте пустым, чтобы не менять): ");
            string? phone = System.Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone))
                doctor.Phone = phone;

            System.Console.Write("Новый номер кабинета (0 - не менять): ");
            int office = ReadInt("");
            if (office > 0)
                doctor.Office = office;

            if (_logic.UpdateDoctor(doctor))
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Данные врача успешно обновлены!");
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Ошибка при обновлении данных.");
            }

            System.Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Удаляет врача из системы по его идентификатору
        /// </summary>
        static void DeleteDoctor()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== УДАЛЕНИЕ ВРАЧА ===");
            System.Console.WriteLine();

            ShowAllDoctors();

            if (_logic.GetDoctors().Count == 0)
                return;

            int id = ReadInt("Введите ID врача для удаления: ");

            if (_logic.DeleteDoctor(id))
            {
                System.Console.WriteLine("Врач успешно удален!");
            }
            else
            {
                System.Console.WriteLine("Врач с таким ID не найден!");
            }

            System.Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Группирует всех врачей по их специализации и выводит результат
        /// </summary>
        static void GroupBySpecialization()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== ГРУППИРОВКА ПО СПЕЦИАЛИЗАЦИИ ===");
            System.Console.WriteLine();

            var groupedDoctors = _logic.GroupDoctorsBySpecialization();

            if (groupedDoctors.Count == 0)
            {
                System.Console.WriteLine("Список врачей пуст.");
            }
            else
            {
                foreach (var group in groupedDoctors)
                {
                    System.Console.WriteLine($"\n{group.Key} ({group.Value.Count} врачей):");
                    System.Console.WriteLine(new string('-', 50));
                    foreach (var doctor in group.Value)
                    {
                        System.Console.WriteLine($"  {doctor.FullName} - стаж {doctor.Experience} лет, каб. {doctor.Office}");
                    }
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Находит и выводит врачей, чей стаж не меньше заданного пользователем значения
        /// </summary>
        static void FindByExperience()
        {
            System.Console.Clear();
            System.Console.WriteLine("=== ПОИСК ВРАЧЕЙ ПО СТАЖУ ===");
            System.Console.WriteLine();

            int minExperience = ReadInt("Минимальный стаж (лет): ");

            var experiencedDoctors = _logic.GetDoctorsWithExperience(minExperience);

            if (experiencedDoctors.Count == 0)
            {
                System.Console.WriteLine($"\nВрачи со стажем от {minExperience} лет не найдены.");
            }
            else
            {
                System.Console.WriteLine($"\nВрачи со стажем от {minExperience} лет:");
                System.Console.WriteLine(new string('-', 80));
                foreach (var doctor in experiencedDoctors)
                {
                    System.Console.WriteLine($"{doctor.FullName} - {doctor.Specialization} (стаж: {doctor.Experience} лет, каб. {doctor.Office})");
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            System.Console.ReadKey();
        }

        /// <summary>
        /// Считывает целое число из консоли с проверкой корректности ввода
        /// Повторяет запрос до тех пор, пока пользователь не введёт валидное число
        /// </summary>
        /// <param name="prompt">Текст приглашения к вводу</param>
        /// <returns>Введённое пользователем целое число</returns>
        static int ReadInt(string prompt)
        {
            while (true)
            {
                System.Console.Write(prompt);
                string? input = System.Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    System.Console.WriteLine("Ошибка! Введите корректное число.");
                }
            }
        }
    }
}