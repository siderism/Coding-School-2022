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
        }

        private void LoadProfessors()
        {
            string data = File.ReadAllText(PROFESSOR_FILE);
            Professors = new JavaScriptSerializer().Deserialize<List<Professor>>(data);
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
            _professor = new Professor()
            {
                Name = textEdit1.EditValue.ToString(),
                Age = Convert.ToInt32(textEdit2.EditValue),
                Rank = textEdit3.EditValue.ToString(),
            };
            Professors.Add(_professor);
        }

        private void DeleteStudent()
        {
            Professors.Remove(_professor);
        }

        private void UpdateProfessor()
        {
            _professor.Name = textEdit1.EditValue.ToString();
            _professor.Age = Convert.ToInt32(textEdit2.EditValue);
            _professor.Rank = textEdit3.EditValue.ToString();
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
