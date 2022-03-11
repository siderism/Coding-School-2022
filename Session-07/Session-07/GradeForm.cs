using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using UniversityLibrary;

namespace Session_07
{
    public partial class GradeForm : Form
    {
        private const string GRADE_FILE = "grades.json";
        private Grade _grade;

        public List<Grade> Grades { get; set; }
        public GradeForm()
        {
            InitializeComponent();
            Grades = new List<Grade>();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveGradesToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadGrades();
            ShowList();
        }

        private void SaveGradesToJSON()
        {
            string json = new JavaScriptSerializer().Serialize(Grades);
            File.WriteAllText(GRADE_FILE, json);
        }

        private void LoadGrades()
        {
            string data = File.ReadAllText(GRADE_FILE);
            Grades = new JavaScriptSerializer().Deserialize<List<Grade>>(data);
            ShowList();
        }

        private void gradesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gradesListBox.SelectedIndex != -1)
            {
                _grade = Grades.ElementAt(Convert.ToInt32(gradesListBox.SelectedIndex));
                textEdit1.Text = _grade.StudentID.ToString();
                textEdit2.Text = _grade.CourseID.ToString();
                textEdit3.Text = _grade.GradeValue.ToString();
            }
        }

        private void newGradeButton_Click(object sender, EventArgs e)
        {
            CreateGrade();
            ShowList();
        }

        private void deleteGradeButton_Click(object sender, EventArgs e)
        {
            DeleteGrade();
            ShowList();
        }

        private void updateGradeButton_Click(object sender, EventArgs e)
        {
            UpdateGrade();
            ShowList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            SaveGradesToJSON();
            this.Close();
        }

        private void CreateGrade()
        {
            _grade = new Grade()
            {
                StudentID = Guid.Parse(textEdit1.EditValue.ToString()),
                CourseID = Guid.Parse(textEdit2.EditValue.ToString()),
                GradeValue = Convert.ToInt32(textEdit3.EditValue.ToString()),
            };
            Grades.Add(_grade);
        }

        private void DeleteGrade()
        {
            Grades.Remove(_grade);
        }

        private void UpdateGrade()
        {
            _grade.StudentID = Guid.Parse(textEdit1.EditValue.ToString());
            _grade.CourseID = Guid.Parse(textEdit2.EditValue.ToString());
            _grade.GradeValue = Convert.ToInt32(textEdit3.EditValue.ToString());
        }

        private void ShowList()
        {
            gradesListBox.Items.Clear();
            foreach (var grade in Grades)
            {
                if (grade != null)
                {
                    gradesListBox.Items.Add($"Grade - {grade.GradeValue}");
                }
            }
        }
    }
}
