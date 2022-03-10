using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_07
{
    public partial class StudentForm : Form
    {
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

        private void SaveStudentsToJSON()
        {
            
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {

        }
    }
}
