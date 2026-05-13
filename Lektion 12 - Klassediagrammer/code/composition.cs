namespace School
{
    class School
    {
        private string _name = "";
        private Course[] _courses = new Course[10];

        public School(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public string[] GetCourses()
        {
            string[] courseNames = new string[10];
            for (int i = 0; i < _courses.Length; i++)
            {
                if (_courses[i] == null)
                {
                    courseNames[i] = "";
                }
                else
                {
                    courseNames[i] = _courses[i].GetName();
                }
            }
            return courseNames;
        }

        public string NewCourse(string courseName)
        {
            for (int i = 0; i < _courses.Length; i++)
            {
                if (_courses[i] == null)
                {
                    _courses[i] = new Course("Course " + courseName);
                    return _courses[i].GetName();
                }
            }
            return "No new course can be added"; // No more courses can be added
        }
    }

    class Course
    {
        private string _name = "";

        public  Course(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}