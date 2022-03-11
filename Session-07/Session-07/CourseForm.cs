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
    public partial class CourseForm : Form
    {
        private const string COURSE_FILE = "courses.json";
        private Course _course;

        public List<Course> Courses { get; set; }

        public CourseForm()
        {
            InitializeComponent();
            Courses = new List<Course>();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveCoursesToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadCourses();
            ShowList();
        }

        private void SaveCoursesToJSON()
        {
            string json = new JavaScriptSerializer().Serialize(Courses);
            File.WriteAllText(COURSE_FILE, json);
        }

        private void LoadCourses()
        {
            string data = File.ReadAllText(COURSE_FILE);
            Courses = new JavaScriptSerializer().Deserialize<List<Course>>(data);
        }

        private void coursesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coursesListBox.SelectedIndex != -1)
            {
                _course = Courses.ElementAt(Convert.ToInt32(coursesListBox.SelectedIndex));
                textEdit1.Text = _course.Code;
                textEdit2.Text = _course.Subject;
            }
        }

        private void newCourseButton_Click(object sender, EventArgs e)
        {
            CreateCourse();
            ShowList();
        }

        private void deleteCourseButton_Click(object sender, EventArgs e)
        {
            DeleteCourse();
            ShowList();
        }

        private void updateCourseButton_Click(object sender, EventArgs e)
        {
            UpdateCourse();
            ShowList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            SaveCoursesToJSON();
            this.Close();
        }

        private void CreateCourse()
        {
            _course = new Course()
            {
                Code = textEdit1.EditValue.ToString(),
                Subject = textEdit2.EditValue.ToString(),
            };
            Courses.Add(_course);
        }

        private void DeleteCourse()
        {
            Courses.Remove(_course);
        }

        private void UpdateCourse()
        {
            _course.Code = textEdit1.EditValue.ToString();
            _course.Subject = textEdit2.EditValue.ToString();  
        }

        private void ShowList()
        {
            coursesListBox.Items.Clear();
            foreach (var course in Courses)
            {
                if (course != null)
                {
                    coursesListBox.Items.Add($"Code - {course.Code}, Subject - {course.Subject}");
                }
            }
        }
    }
}
