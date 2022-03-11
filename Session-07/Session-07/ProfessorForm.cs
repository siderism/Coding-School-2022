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
    public partial class ProfessorForm : Form
    {
        private const string PROFESSOR_FILE = "professors.json";
        private Professor _professor;

        public List<Professor> Professors { get; set; }

        public ProfessorForm()
        {
            InitializeComponent();
            Professors = new List<Professor>();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveProfessorsToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadProfessors();
            ShowList();
        }

        private void SaveProfessorsToJSON()
        {
            string json = new JavaScriptSerializer().Serialize(Professors);
            File.WriteAllText(PROFESSOR_FILE, json);
            MessageBox.Show("Data saved to file successfully");
        }

        private void LoadProfessors()
        {
            string data = File.ReadAllText(PROFESSOR_FILE);
            Professors = new JavaScriptSerializer().Deserialize<List<Professor>>(data);
            MessageBox.Show("Data loaded successfully");
        }

        private void newProfessorButton_Click(object sender, EventArgs e)
        {
            CreateProfessor();
            ShowList();
        }

        private void deleteProfessorButton_Click(object sender, EventArgs e)
        {
            DeleteStudent();
            ShowList();
        }

        private void updateProfessorButton_Click(object sender, EventArgs e)
        {
            UpdateProfessor();
            ShowList();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            SaveProfessorsToJSON();
            this.Close();
        }

        private void professorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (professorsListBox.SelectedIndex != -1)
            {
                _professor = Professors.ElementAt(Convert.ToInt32(professorsListBox.SelectedIndex));
                textEdit1.Text = _professor.Name;
                textEdit2.Text = _professor.Age.ToString();
                textEdit3.Text = _professor.Rank;
            }
        }

        private void CreateProfessor()
        {
            var professor = new Professor();
            try
            {
                professor.Name = textEdit1.EditValue.ToString();
                professor.Age = Convert.ToInt32(textEdit2.EditValue);
                professor.Rank = textEdit3.EditValue.ToString();
                _professor = professor;
                Professors.Add(_professor);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Create new Professor. Check the values and try again.", MessageBoxIcon.Warning.ToString());
            }
        }

        private void DeleteStudent()
        {
            Professors.Remove(_professor);
        }

        private void UpdateProfessor()
        {
            try
            {
                var professor = new Professor();
                professor.Name = textEdit1.EditValue.ToString();
                professor.Age = Convert.ToInt32(textEdit2.EditValue);
                professor.Rank = textEdit3.EditValue.ToString();
                _professor = professor;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Update Professor. Check the values and try again.", MessageBoxIcon.Warning.ToString());
            }
        }

        private void ShowList()
        {
            professorsListBox.Items.Clear();
            foreach (var professor in Professors)
            {
                if (professor != null)
                {
                    professorsListBox.Items.Add($"Name - Dr. {professor.Name}, Age - {professor.Age}, Rank - {professor.Rank}");
                }
            }
        }
    }
}
