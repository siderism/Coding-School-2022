using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityLibrary;
using System.Web.Script.Serialization;
using System.IO;

namespace Session_07
{
    public partial class StudentForm : Form
    {

        private const string STUDENT_FILE = "student.json";
        private Student _student;
        public List<Student> Students { get; set; }
        public StudentForm()
        {
            InitializeComponent();
            Students = new List<Student>();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveStudentsToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadStudents();
            ShowList();
        }

        private void SaveStudentsToJSON()
        {
            string json = new JavaScriptSerializer().Serialize(Students);
            File.WriteAllText(STUDENT_FILE, json);
            MessageBox.Show("Data saved to file successfully");
        }

        private void LoadStudents()
        {
            string data = File.ReadAllText(STUDENT_FILE);
            Students = new JavaScriptSerializer().Deserialize<List<Student>>(data);
            MessageBox.Show("Data loaded successfully");
        }

        private void studentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentListBox.SelectedIndex != -1)
            {
                _student = Students.ElementAt(Convert.ToInt32(studentListBox.SelectedIndex));
                textEdit1.Text = _student.Name;
                textEdit2.Text = _student.Age.ToString();
                textEdit3.Text = _student.RegistrationNumber.ToString();
            }
        }

        private void newStudentButton_Click(object sender, EventArgs e)
        {
            CreateStudent();
            ShowList();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            DeleteStudent();
            ShowList();
        }

        private void updateStudentButton_Click(object sender, EventArgs e)
        {
            UpdateStudent();
            ShowList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            SaveStudentsToJSON();
            this.Close();
        }

        private void CreateStudent()
        {
            try
            {
                var student = new Student() { 
                    Name = textEdit1.EditValue.ToString(), 
                    Age = Convert.ToInt32(textEdit2.EditValue), 
                    RegistrationNumber = Convert.ToInt32(textEdit3.EditValue) 
                };
                _student = student;
                Students.Add(_student);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Create new Student. Check the values and try again.", MessageBoxIcon.Warning.ToString());
            }
        }

        private void DeleteStudent()
        {
            Students.Remove(_student);
        }

        private void UpdateStudent()
        {
            try
            {
                var student = new Student
                {
                    Name = textEdit1.EditValue.ToString(),
                    Age = Convert.ToInt32(textEdit2.EditValue),
                    RegistrationNumber = Convert.ToInt32(textEdit3.EditValue)
                };
                _student = student;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Update Student. Check the values and try again.", MessageBoxIcon.Warning.ToString());
            }
        }

        private void ShowList()
        {
            studentListBox.Items.Clear();
            foreach (var student in Students)
            {
                if (student != null)
                {
                    studentListBox.Items.Add($"Name - {student.Name}, Age - {student.Age}, Registration Number - {student.RegistrationNumber}");
                }
            }
        }
    }
}
