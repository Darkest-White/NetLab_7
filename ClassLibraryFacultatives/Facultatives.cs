using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibraryFacultatives.Exception;

namespace ClassLibraryFacultatives
{
    /// <summary>
    /// Отель
    /// </summary>
    public class Facultatives
    {
        private static Facultatives _instance;
        /// <summary>
        /// Единственный экземпляр класса Facultatives
        /// </summary>
        public static Facultatives Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Facultatives();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Приватный конструктор
        /// </summary>
        private Facultatives()
        {

        }
        /// <summary>
        /// Словарь студентов
        /// </summary>
        private Dictionary<int, Student> _students = new Dictionary<int, Student>();
        /// <summary>
        /// Словарь предметов
        /// </summary>
        private Dictionary<int, Subject> _subjects = new Dictionary<int, Subject>();
        /// <summary>
        /// Спосок учебных планов
        /// </summary>
        private List<StudyPlan> _studyPlans = new List<StudyPlan>();

        /// <summary>
        /// Коллекция студентов
        /// </summary>
        public IEnumerable<Student> Students
        {
            get { return _students.Values.AsEnumerable(); }
        }
        /// <summary>
        /// Коллекция номеров
        /// </summary>
        public IEnumerable<Subject> Subjects
        {
            get
            {
                return _subjects.Values.AsEnumerable();
            }
        }
        /// <summary>
        /// Коллекция поселений
        /// </summary>
        public IEnumerable<StudyPlan> StudyPlans
        {
            get
            {
                return _studyPlans;
            }
        }

        public event EventHandler StudentAdded;
        public event EventHandler SubjectAdded;
        public event EventHandler StudyPlanAdded;
        public event EventHandler StudentRemoved;
        public event EventHandler SubjectRemoved;
        public event EventHandler StudyPlanRemoved;
        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="student">Информация о клиенте</param>
        public void AddStudent(Student student)
        {
            if (!student.IsValid)
            {
                throw new InvalidStudentException("Информация о студенте заполнена некорректно");
            }
            try
            {
                _students.Add(student.StudentId, student);
                //Герерируем событие о том, что клиент добавлен
                StudentAdded?.Invoke(student, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidStudentException("При добавлении студента произошла ошибка", exception);
            }
        }
        /// <summary>
        /// Добавление номера
        /// </summary>
        /// <param name="subject">Информация о номере</param>
        public void AddSubject(Subject subject)
        {
            if (!subject.IsValid)
            {
                throw new InvalidSubjectException("Информация о предмете заполнена некорректно");
            }
            try
            {
                _subjects.Add(subject.SubjectId, subject);
                //Герерируем событие о том, что номер добавлен
                SubjectAdded?.Invoke(subject, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidSubjectException("При добавлении предмета произошла ошибка", exception);
            }
        }
        /// <summary>
        /// Информация о поселении
        /// </summary>
        /// <param name="studyPlan"></param>
        public void AddStudyPlan(StudyPlan studyPlan)
        {
            if (!studyPlan.IsValid)
            {
                throw new InvalidStudyPlanException("Информация об учебном плане заполнена некорректно");
            }
            try
            {
                _studyPlans.Add(studyPlan);
                //Герерируем событие о том, что информация о поселении добавлена
                StudyPlanAdded?.Invoke(studyPlan, EventArgs.Empty);
            }
            catch (System.Exception exception)
            {
                throw new InvalidStudyPlanException("При установке учебного плана произошла ошибка", exception);
            }
        }
        /// <summary>
        /// Удалить студента по идентификатору
        /// </summary>
        /// <param name="studentKey">Идентификатор студента</param>
        public void RemoveStudent(int studentKey)
        {
            _students.Remove(studentKey);
            //Генерируем событие о том, что студент удалён
            StudentRemoved?.Invoke(studentKey, EventArgs.Empty);
            //Получаем список сведений о поселении клиента
            var studyPlansForStudent = StudyPlans.Where(s => s.Student.StudentId == studentKey).ToList();
            for (int i = 0; i < studyPlansForStudent.Count; i++)
            {
                //Удаляем сведения об учебном плане студента
                RemoveStudyPlan(studyPlansForStudent[i]);
            }
        }

        /// <summary>
        /// Удалить предмет по идентификатору
        /// </summary>
        /// <param name="subjectKey"></param>
        public void RemoveSubject(int subjectKey)
        {
            _subjects.Remove(subjectKey);
            //Генерируем событие о том, что номер удалён
            SubjectRemoved?.Invoke(subjectKey, EventArgs.Empty);
            //Получаем список сведений о поселении в номер
            var studyPlansForSubject = StudyPlans.Where(s => s.Subject.SubjectId == subjectKey).ToList();
            for (int i = 0; i < studyPlansForSubject.Count; i++)
            {
                //Удаляем сведения о поселении в номер
                RemoveStudyPlan(studyPlansForSubject[i]);
            }
        }
        /// <summary>
        /// Удалить информацию об учебном плане
        /// </summary>
        /// <param name="studyPlan">Информация о поселении</param>
        public void RemoveStudyPlan(StudyPlan studyPlan)
        {
            _studyPlans.Remove(studyPlan);
            //Генерируем событие о том, что информация о поселении удалена
            StudyPlanRemoved?.Invoke(studyPlan, EventArgs.Empty);
        }
    }
}