﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryFacultatives;

namespace WindowsFormsControlLibraryFacultatives
{
    public partial class UserControlStudyPlan: UserControl
    {
        public UserControlStudyPlan()
        {
            InitializeComponent();
        }

    private readonly Facultatives _facultatives = Facultatives.Instance;
        public StudyPlan StudyPlan { get; }
        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (value)
                {
                    var controls = Parent?.Controls;
                    if (controls != null)
                    {
                        foreach (var control in controls)
                        {
                            if (!(control is UserControlStudyPlan)) continue;
                            var UserControlStudyPlan = control as UserControlStudyPlan;
                            if (UserControlStudyPlan != this)
                            {
                                UserControlStudyPlan.Selected = false;
                            }
                        }
                    }
                }
                _selected = value;
                Refresh();
            }
        }
        public UserControlStudyPlan(StudyPlan studyPlan)
        {
            InitializeComponent();
            StudyPlan = studyPlan;
        }
        private void UserControlStudyPlan_Paint(object sender, PaintEventArgs e)
        {
            textBoxStudent.Text = $@"{StudyPlan.Student.LastName} {StudyPlan.Student.FirstName[0]}.{StudyPlan.Student.MiddleName[0]}.";
            textBoxSubject.Text = StudyPlan.Subject.SubjectId.ToString("0");
            //textBoxPeriod.Text = $@"С {StudyPlan.StartDate:dd MMMM yyyy} по {StudyPlan.EndDate:dd MMMM yyyy}";
            //if (StudyPlan.EndDate < DateTime.Today)
            //{
            //    textBoxPeriod.BackColor = Color.Green;
            //}
            //else
            //{
            //    textBoxPeriod.BackColor = Settlement.StartDate < DateTime.Today ? Color.Yellow : Color.Red;
            //}
            //BackColor = _selected ? Color.CornflowerBlue : DefaultBackColor
        }
        private void UserControlStudyPlan_Click(object sender, EventArgs e)
        {
            Selected = true;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _facultatives.RemoveStudyPlan(StudyPlan);
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбрана запись об учебном плане");
            }
        }
    }
}