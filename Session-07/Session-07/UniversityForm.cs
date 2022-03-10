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
    public partial class UniversityForm : Form
    {
        public UniversityForm()
        {
            InitializeComponent();
        }

        private void UniversityForm_Load(object sender, EventArgs e)
        {
            
        }

        private void studentButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var studentForm = new StudentForm();
            studentForm.ShowDialog();
        }

        private void professorButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var professorForm = new ProfessorForm();
            professorForm.ShowDialog();
        }

        private void courseButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var courseForm = new CourseForm();
            courseForm.ShowDialog();
        }

        private void gradeButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var gradeForm = new GradeForm();
            gradeForm.ShowDialog();
        }

        private void scheduleButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var scheduleForm = new ScheduleForm();
            scheduleForm.ShowDialog();
        }
    }
}
