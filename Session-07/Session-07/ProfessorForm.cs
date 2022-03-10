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

        public ProfessorForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveProfessorsToJSON();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadProfessors();
        }

        private void SaveProfessorsToJSON()
        {
            var professor = new Professor()
            {
                Name = textEdit1.EditValue.ToString(),
                Age = Convert.ToInt32(textEdit2.EditValue),
                Rank = textEdit3.EditValue.ToString(),
            };
            string json = new JavaScriptSerializer().Serialize(professor);
            File.WriteAllText(PROFESSOR_FILE, json);
        }

        private void LoadProfessors()
        {
            string data = File.ReadAllText(PROFESSOR_FILE);
            Professor professor = new JavaScriptSerializer().Deserialize<Professor>(data);
        }
    }
}
