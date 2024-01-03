using System;
using System.Windows.Forms;
using ClassLibraryFacultatives;

namespace NetLab_7
{
    public partial class FormStudyPlan : Form
    {
        private StudyPlan _studyPlan;
        public StudyPlan StudyPlan
        {
            get { return _studyPlan; }
            set
            {
                _studyPlan = value;
                comboBoxStudent.SelectedItem = _studyPlan.Student;
                comboBoxSubject.SelectedItem = _studyPlan.Subject;
            }
        }
        private readonly Facultatives _facultatives = Facultatives.Instance;
        public FormStudyPlan()
        {
            InitializeComponent();
            _facultatives.StudentAdded += _facultatives_StudentAdded;
            _facultatives.StudentRemoved += _facultatives_StudentRemoved;
            _facultatives.SubjectAdded += _facultatives_SubjectAdded;
            _facultatives.SubjectRemoved += _facultatives_SubjectRemoved;
            foreach (var student in _facultatives.Students)
            {
                comboBoxStudent.Items.Add(student);
            }
            foreach (var subject in _facultatives.Subjects)
            {
                comboBoxSubject.Items.Add(subject);
            }
        }

        private void _facultatives_SubjectRemoved(object sender, EventArgs e)
        {
            int key = (int)sender;
            for (int i = 0; i < comboBoxSubject.Items.Count; i++)
            {
                var subject = comboBoxSubject.Items[i] as Subject;
                if (subject?.SubjectId == key)
                {
                    comboBoxSubject.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _facultatives_SubjectAdded(object sender, EventArgs e)
        {
            comboBoxSubject.Items.Add(sender);
        }

        private void _facultatives_StudentRemoved(object sender, EventArgs e)
        {
            int key = (int)sender;
            for (int i = 0; i < comboBoxStudent.Items.Count; i++)
            {
                var student = comboBoxStudent.Items[i] as Student;
                if (student?.StudentId == key)
                {
                    comboBoxStudent.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void _facultatives_StudentAdded(object sender, EventArgs e)
        {
            comboBoxStudent.Items.Add(sender);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StudyPlan.Student = comboBoxStudent.SelectedItem as Student;
            StudyPlan.Subject = comboBoxSubject.SelectedItem as Subject;
        }
    }
}
