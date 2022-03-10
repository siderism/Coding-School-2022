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
    public partial class ScheduleForm : Form
    {
        private const string SCHEDULE_FILE = "schedules.json";
        public ScheduleForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSchedulesToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        private void SaveSchedulesToJSON()
        {
            var schedule = new Schedule()
            {
                CourseID = Guid.Parse(textEdit1.EditValue.ToString()),
                ProfessorID = Guid.Parse(textEdit2.EditValue.ToString()),
                Callendar = DateTime.Parse(dateEdit1.EditValue.ToString()),
            };
            string json = new JavaScriptSerializer().Serialize(schedule);
            File.WriteAllText(SCHEDULE_FILE, json);
        }

        private void LoadSchedules()
        {
            string data = File.ReadAllText(SCHEDULE_FILE);
            Schedule schedule= new JavaScriptSerializer().Deserialize<Schedule>(data);
        }
    }
}
