using System.ComponentModel;

class Course
{
    Students[] students = new Students[25]; 

    public Course(Students[] students)
    {
        this.students = students;
    }

    public Course()
    {
    }

    public string[] GetStudents()
    {
        string[] studentNames = new string[25];
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i] != null)
            {
                studentNames[i] = students[i].GetName();
            }
        }
        return studentNames;
    }

    public void AddStudent(Students student)
    {
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i] == null)
            {
                students[i] = student;
                break;
            }
        }
    }
}

class Students
{
    private string _name = ""; 
    private byte _age = 0;

    public Students(string name, byte age)
    {
        _name = name;
        _age = age;
    }

    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public byte GetAge()
    {
        return _age;
    }
    public void SetAge(byte age)
    {
        _age = age;
    }
}