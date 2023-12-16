using System;
using System.Windows.Forms;
using System.Xml.Linq;
using ClassLibraryFacultatives;
using NetLab_6._1;
using WindowsFormsControlLibraryFacultatives;

namespace NetLab_6
{
    public partial class FormMain : Form
    {
        private readonly Facultatives _facultatives = Facultatives.Instance;
        readonly FormSubject _formSubject = new FormSubject();
        readonly FormStudent _formStudent = new FormStudent();
        readonly FormStudyPlan _formStudyPlan = new FormStudyPlan();

        public FormMain()
        {
            InitializeComponent();
            _facultatives.StudentAdded += _facultatives_StudentAdded;
            _facultatives.SubjectAdded += _facultatives_SubjectAdded;
            _facultatives.StudyPlanAdded += _facultatives_StudyPlanAdded;
            _facultatives.StudentRemoved += _facultatives_StudentRemoved;
            _facultatives.SubjectRemoved += _facultatives_SubjectRemoved;
            _facultatives.StudyPlanRemoved += _facultatives_StudyPlanRemoved;
        }
        private void _facultatives_StudyPlanRemoved(object sender, EventArgs e)
        {
            var studyPlan = sender as StudyPlan;

            for (int i = 0; i < tabPageSettlements.Controls.Count; i++)
            {
                if ((tabPageSettlements.Controls[i] as UserControlStudyPlan)?.StudyPlan == studyPlan)
                {
                    tabPageSettlements.Controls.RemoveAt(i);
                    break;
                }
            }
        }
        private void _facultatives_SubjectRemoved(object sender, EventArgs e)
        {
            var subjectNumber = (int)sender;
            for (int i = 0; i < listViewSubjects.Items.Count; i++)
            {
                if (((Subject)listViewSubjects.Items[i].Tag).SubjectId == subjectNumber)
                {
                    listViewSubjects.Items.RemoveAt(i);
                    break;
                }
            }
        }
        private void _facultatives_StudentRemoved(object sender, EventArgs e)
        {
            var studentId = (int)sender;
            for (int i = 0; i < listViewStudents.Items.Count; i++)
            {
                if (((Student)listViewStudents.Items[i].Tag).StudentId == studentId)
                {
                    listViewStudents.Items.RemoveAt(i);
                    break;
                }
            }
        }
        private void _facultatives_StudyPlanAdded(object sender, EventArgs e)
        {
            var studyPlan = sender as StudyPlan;
            if (studyPlan != null)
            {
                UserControlStudyPlan userControl = new UserControlStudyPlan(studyPlan)
                {
                    Dock = DockStyle.Top
                }; tabPageSettlements.Controls.Add(userControl);
            }
        }
        private void _facultatives_SubjectAdded(object sender, EventArgs e)
        {
            var subject = sender as Subject;
            if (subject != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = subject,
                    Text = subject.ToString()
                };
                listViewSubjects.Items.Add(listViewItem);
            }
        }
        private void _facultatives_StudentAdded(object sender, EventArgs e)
        {
            var student = sender as Student;
            if (student != null)
            {
                var listViewItem = new ListViewItem
                {
                    Tag = student,
                    Text = student.ToString()
                };
                listViewStudents.Items.Add(listViewItem);
            }
        }
        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var student = new Student();
            _formStudent.Student = student;
            if (_formStudent.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _facultatives.AddStudent(student);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        private void editStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var student = listViewStudents.SelectedItems[0].Tag as Student;
                _formStudent.Student = student;
                if (_formStudent.ShowDialog() == DialogResult.OK)
                {
                    listViewStudents.SelectedItems[0].Text = _formStudent.Student.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка со студентом");
            }
        }
        private void addSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subject = new Subject();
            _formSubject.Subject = subject;
            if (_formSubject.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _facultatives.AddSubject(subject);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        private void editSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var subject = listViewSubjects.SelectedItems[0].Tag as Subject;
                _formSubject.Subject = subject;
                if (_formSubject.ShowDialog() == DialogResult.OK)
                {
                    listViewSubjects.SelectedItems[0].Text = _formSubject.Subject.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана строка с предметом");
            }
        }
        private void addStudyPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var studyPlan = new StudyPlan();
            _formStudyPlan.StudyPlan = studyPlan;
            if (_formStudyPlan.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _facultatives.AddStudyPlan(studyPlan);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        private void editStudyPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tabPageSettlements.Controls.Count; i++)
                {
                    var userControl = tabPageSettlements.Controls[i] as UserControlStudyPlan;
                    if (userControl != null)
                    {
                        if (userControl.Selected)
                        {
                            var studyPlan = userControl.StudyPlan;
                            _formStudyPlan.StudyPlan = studyPlan;
                            if (_formStudyPlan.ShowDialog() == DialogResult.OK)
                            {
                                userControl.Refresh();
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана запись об учебном плане");
            }

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void listViewStudents_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var student = listViewStudents.SelectedItems[0].Tag as Student;
                    if (student != null)
                    {
                        _facultatives.RemoveStudent(student.StudentId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка со студентом");
                }
            }
        }
        private void listViewSubjects_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var subject = listViewSubjects.SelectedItems[0].Tag as Subject;
                    if (subject != null)
                    {
                        _facultatives.RemoveSubject(subject.SubjectId);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с предметом");
                }
            }
        }
        private void listViewStudyPlan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    var studyPlan = listViewStudyPlans.SelectedItems[0].Tag as StudyPlan;
                    if (studyPlan != null)
                    {
                        _facultatives.RemoveStudyPlan(studyPlan);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбрана строка с учебным планом");
                }
            }
        }
    }
}