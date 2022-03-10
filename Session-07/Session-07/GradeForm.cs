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
        public GradeForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveGradesToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadGrades();
        }

        private void SaveGradesToJSON()
        {
            var grade = new Grade()
            {
                StudentID = Guid.Parse(textEdit1.EditValue.ToString()),
                CourseID = Guid.Parse(textEdit2.EditValue.ToString()),
                GradeValue = Convert.ToInt32(textEdit3.EditValue),
            };
            string json = new JavaScriptSerializer().Serialize(grade);
            File.WriteAllText(GRADE_FILE, json);
        }

        private void LoadGrades()
        {
            string data = File.ReadAllText(GRADE_FILE);
            Grade grade = new JavaScriptSerializer().Deserialize<Grade>(data);
        }
    }
}
