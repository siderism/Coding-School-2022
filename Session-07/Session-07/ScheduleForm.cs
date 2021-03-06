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
        private Schedule _schedule;
        public List<Schedule> Schedules { get; set; }
        public ScheduleForm()
        {
            InitializeComponent();
            Schedules = new List<Schedule>();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSchedulesToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadSchedules();
            ShowList();
        }

        private void SaveSchedulesToJSON()
        {
            string json = new JavaScriptSerializer().Serialize(Schedules);
            File.WriteAllText(SCHEDULE_FILE, json);
            MessageBox.Show("Data saved to file successfully");
        }

        private void LoadSchedules()
        {
            string data = File.ReadAllText(SCHEDULE_FILE);
            Schedules = new JavaScriptSerializer().Deserialize<List<Schedule>>(data);
            MessageBox.Show("Data loaded successfully");
        }

        private void newScheduleButton_Click(object sender, EventArgs e)
        {
            CreateSchedule();
            ShowList();
        }

        private void deleteScheduleButton_Click(object sender, EventArgs e)
        {
            DeleteSchedule();
            ShowList();
        }

        private void updateScheduleButton_Click(object sender, EventArgs e)
        {
            UpdateSchedule();
            ShowList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            SaveSchedulesToJSON();
            this.Close();
        }

        private void scheduleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scheduleListBox.SelectedIndex != -1)
            {
                _schedule = Schedules.ElementAt(Convert.ToInt32(scheduleListBox.SelectedIndex));
                textEdit1.Text = _schedule.CourseID.ToString();
                textEdit2.Text = _schedule.ProfessorID.ToString();
                dateEdit1.DateTime = DateTime.Parse(_schedule.Callendar.ToString());
            }
        }

        private void CreateSchedule()
        {
            try
            {
                var schedule = new Schedule()
                {
                    CourseID = Guid.Parse(textEdit1.EditValue.ToString()),
                    ProfessorID = Guid.Parse(textEdit2.EditValue.ToString()),
                    Callendar = DateTime.Parse(dateEdit1.EditValue.ToString())
                };
                _schedule = schedule;
                Schedules.Add(_schedule);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Create new Schedule. Check the values and try again.", MessageBoxIcon.Warning.ToString());
            }            
        }

        private void DeleteSchedule()
        {
            Schedules.Remove(_schedule);
        }

        private void UpdateSchedule()
        {
            try
            {
                Schedule schedule = new Schedule()
                {
                    CourseID = Guid.Parse(textEdit1.EditValue.ToString()),
                    ProfessorID = Guid.Parse(textEdit2.EditValue.ToString()),
                    Callendar = DateTime.Parse(dateEdit1.EditValue.ToString())
                };
                _schedule = schedule;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Update Schedule. Check the values and try again.", MessageBoxIcon.Warning.ToString());
            }
            
        }

        private void ShowList()
        {
            scheduleListBox.Items.Clear();
            foreach (var schedule in Schedules)
            {
                if (schedule != null)
                {
                    scheduleListBox.Items.Add($"Callendar - {schedule.Callendar}");
                }
            }
        }
    }
}
