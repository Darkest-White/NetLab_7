using System;
using ClassLibraryFacultatives;
using System.Windows.Forms;

namespace NetLab_7
{
    public partial class FormSubject : Form
    {
        private Subject _subject;
        public Subject Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
                textBoxTitle.Text = _subject.Title;
                numericUpDownLectures.Value = _subject.Lectures;
                numericUpDownPractices.Value = _subject.Practices;
                numericUpDownLaboratorys.Value = _subject.LaboratoryWorks;
            }
        }

        public FormSubject()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Subject.Title = textBoxTitle.Text;
            Subject.Lectures = (int)numericUpDownLectures.Value;
            Subject.Practices = (int)numericUpDownPractices.Value;
            Subject.LaboratoryWorks = (int)numericUpDownLaboratorys.Value;
        }
    }
}