using Hospital.BusinessLogical;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hospital.WinForms
{
    public partial class Form1 : Form
    {
        private Logic _logic;
        private Doctor _currentDoctor;
        private bool _isEditMode = false;

        public Form1()
        {
            InitializeComponent();
            _logic = new Logic();
            InitializeSpecializations();
            RefreshDataGridView();
            dataGridViewDoctors.Visible = false;
        }

        /// <summary>
        /// Инициализация выпающего списка специализаций доступными значениями
        /// </summary>
        private void InitializeSpecializations()
        {
            comboBoxSpecialization.Items.Clear();
            comboBoxSpecialization.Items.AddRange(new string[] {
                "Кардиолог",
                "Стоматолог",
                "Терапевт",
                "Хирург",
                "Невролог",
                "Педиатр",
                "Офтальмолог",
                "Дерматолог"
            });
            comboBoxSpecialization.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Обновление таблицы врачей актуальными данными из бизнес-логики
        /// </summary>
        private void RefreshDataGridView()
        {
            dataGridViewDoctors.Rows.Clear();
            var doctors = _logic.GetDoctors();

            foreach (var doctor in doctors)
            {
                dataGridViewDoctors.Rows.Add(
                    doctor.Id,
                    doctor.FullName,
                    doctor.Specialization,
                    doctor.Experience,
                    doctor.Phone,
                    doctor.Office
                );
            }
        }

        /// <summary>
        /// Очистка всех полей ввода и сброс режима редактирования
        /// </summary>
        private void ClearInputFields()
        {
            textBoxFullName.Clear();
            comboBoxSpecialization.SelectedIndex = -1;
            textBoxExperience.Clear();
            textBoxPhone.Clear();
            textBoxOffice.Clear();
            _isEditMode = false;
            _currentDoctor = null;
        }

        /// <summary>
        /// Получение данных врача из полей ввода формы
        /// </summary>
        /// <returns>Объект Doctor с данными из формы</returns>
        private Doctor GetDoctorFromInput()
        {
            return new Doctor
            {
                Id = _currentDoctor?.Id ?? 0,
                FullName = textBoxFullName.Text.Trim(),
                Specialization = comboBoxSpecialization.SelectedItem?.ToString() ?? "",
                Experience = int.TryParse(textBoxExperience.Text, out int exp) ? exp : 0,
                Phone = textBoxPhone.Text.Trim(),
                Office = int.TryParse(textBoxOffice.Text, out int office) ? office : 0
            };
        }

        /// <summary>
        /// Проверка корректности введённых данных в поля формы
        /// </summary>
        /// <returns>
        /// true, если все поля заполнены корректно
        /// false, если есть ошибки валидации
        /// </returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxFullName.Text))
            {
                MessageBox.Show("Введите ФИО врача", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFullName.Focus();
                return false;
            }

            if (comboBoxSpecialization.SelectedItem == null)
            {
                MessageBox.Show("Выберите специализацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSpecialization.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxExperience.Text) || !int.TryParse(textBoxExperience.Text, out int exp) || exp < 0)
            {
                MessageBox.Show("Введите корректный стаж (число лет)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxExperience.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Введите телефон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxOffice.Text) || !int.TryParse(textBoxOffice.Text, out int office) || office <= 0)
            {
                MessageBox.Show("Введите корректный номер кабинета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxOffice.Focus();
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var doctor = GetDoctorFromInput();
            _logic.CreateDoctor(doctor);
            RefreshDataGridView();
            ClearInputFields();
            MessageBox.Show("Врач успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!_isEditMode || _currentDoctor == null)
            {
                MessageBox.Show("Выберите врача для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            var updatedDoctor = GetDoctorFromInput();
            updatedDoctor.Id = _currentDoctor.Id;

            if (_logic.UpdateDoctor(updatedDoctor))
            {
                RefreshDataGridView();
                ClearInputFields();
                MessageBox.Show("Данные врача успешно обновлены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentDoctor == null)
            {
                MessageBox.Show("Выберите врача для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить врача {_currentDoctor.FullName}?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (_logic.DeleteDoctor(_currentDoctor.Id))
                {
                    RefreshDataGridView();
                    ClearInputFields();
                    MessageBox.Show("Врач успешно удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении врача", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnToggleTable_Click(object sender, EventArgs e)
        {
            if (dataGridViewDoctors.Visible)
            {
                dataGridViewDoctors.Visible = false;
                btnToggleTable.Text = "Показать таблицу";
            }
            else
            {
                dataGridViewDoctors.Visible = true;
                btnToggleTable.Text = "Скрыть таблицу";
            }
        }


        private void dataGridViewDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridViewDoctors.Rows[e.RowIndex];

            _currentDoctor = new Doctor
            {
                Id = Convert.ToInt32(row.Cells["ColumnID"].Value),
                FullName = row.Cells["ColumnFullName"].Value.ToString(),
                Specialization = row.Cells["ColumnSpecialization"].Value.ToString(),
                Experience = Convert.ToInt32(row.Cells["ColumnExperience"].Value),
                Phone = row.Cells["ColumnPhone"].Value.ToString(),
                Office = Convert.ToInt32(row.Cells["ColumnOffice"].Value)
            };

            textBoxFullName.Text = _currentDoctor.FullName;
            comboBoxSpecialization.SelectedItem = _currentDoctor.Specialization;
            textBoxExperience.Text = _currentDoctor.Experience.ToString();
            textBoxPhone.Text = _currentDoctor.Phone;
            textBoxOffice.Text = _currentDoctor.Office.ToString();

            _isEditMode = true;
        }


        private void btnGroupBySpecialization_Click(object sender, EventArgs e)
        {
            var groupedDoctors = _logic.GroupDoctorsBySpecialization();

            if (groupedDoctors.Count == 0)
            {
                MessageBox.Show("Список врачей пуст", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = "Группировка врачей по специализации:\n\n";
            foreach (var group in groupedDoctors)
            {
                message += $"{group.Key} ({group.Value.Count} врачей):\n";
                foreach (var doctor in group.Value)
                {
                    message += $"  - {doctor.FullName} (стаж: {doctor.Experience} лет)\n";
                }
                message += "\n";
            }

            MessageBox.Show(message, "Группировка по специализации", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnFindExperienced_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxMinExperience.Text, out int minExp) || minExp < 0)
            {
                MessageBox.Show("Введите корректный минимальный стаж", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var experiencedDoctors = _logic.GetDoctorsWithExperience(minExp);

            if (experiencedDoctors.Count == 0)
            {
                MessageBox.Show($"Врачи со стажем от {minExp} лет не найдены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = $"Врачи со стажем от {minExp} лет:\n\n";
            foreach (var doctor in experiencedDoctors)
            {
                message += $"{doctor.FullName} - {doctor.Specialization} (стаж: {doctor.Experience} лет, каб. {doctor.Office})\n";
            }

            MessageBox.Show(message, "Опытные врачи", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}