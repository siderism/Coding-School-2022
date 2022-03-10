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
        public StudentForm()
        {
            InitializeComponent();
            
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
        }

        private void SaveStudentsToJSON()
        {
            var student = new Student()
            {
                Name = textEdit1.EditValue.ToString(),
                Age = Convert.ToInt32(textEdit2.EditValue),
                RegistrationNumber = Convert.ToInt32(textEdit3.EditValue),
            };
            string json = new JavaScriptSerializer().Serialize(student);
            File.WriteAllText(STUDENT_FILE, json);
        }

        private void LoadStudents()
        {
            string data = File.ReadAllText(STUDENT_FILE);
            Student student = new JavaScriptSerializer().Deserialize<Student>(data);  
        }
    }
}
