using System;
using System.Windows.Forms;
using ClassLibraryFacultatives;

namespace NetLab_6
{
    public partial class FormStudent : Form
    {
        private Student _student;

        public Student Student
        {
            get 
            { 
                return _student; 
            }
            set
            {
                _student = value;
                textBoxFirstName.Text = Student.FirstName;
                textBoxMiddleName.Text = Student.MiddleName;
                textBoxLastName.Text = Student.LastName;

                textBoxStreet.Text = Student.Adress.Street;
                textBoxHouse.Text = Student.Adress.House;
                textBoxFlat.Text = Student.Adress.Flat;
            }
        }

        public FormStudent()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _student.FirstName = textBoxFirstName.Text;
            _student.MiddleName = textBoxMiddleName.Text;
            _student.LastName = textBoxLastName.Text;

            _student.Adress.Street = textBoxStreet.Text;
            _student.Adress.House = textBoxHouse.Text;
            _student.Adress.Flat = textBoxFlat.Text;
        }
    }
}
