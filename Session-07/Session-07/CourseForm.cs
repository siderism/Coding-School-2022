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

        public CourseForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveCoursesToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void SaveCoursesToJSON()
        {
            var course = new Course()
            {
                Code = textEdit1.EditValue.ToString(),
                Subject = textEdit2.EditValue.ToString(),
            };
            string json = new JavaScriptSerializer().Serialize(course);
            File.WriteAllText(COURSE_FILE, json);
        }

        private void LoadCourses()
        {
            string data = File.ReadAllText(COURSE_FILE);
            Course course = new JavaScriptSerializer().Deserialize<Course>(data);
        }
    }
}
