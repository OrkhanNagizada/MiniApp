using MiniApp.Helpers;
using MiniApp.Models;
using MiniApp;
using System;
using System.Collections.Generic;
using System.Linq;

public class Classroom
{
    private static int nextId = 1;

    public int Id { get; private set; }
    public string Name { get; private set; }
    public ClassType Type { get; private set; }
    public List<Student> Students { get; private set; }

    public Classroom(string name, ClassType type)
    {
        Id = nextId++;
        Name = name;
        Type = type;
        Students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (!IsFull() && Helper.IsValidName(student.Name) && Helper.IsValidSurname(student.Surname))
        {
            Students.Add(student);
        }
        else
        {
            throw new Exception("Student could not be added due to invalid name or surname, or class is full.");
        }
    }

    public Student FindStudentById(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            throw new StudentNotFoundException($"Student with ID {id} not found.");
        }
        return student;
    }

    public void DeleteStudentById(int id)
    {
        var student = FindStudentById(id);
        Students.Remove(student);
    }

    public void DisplayAllStudents()
    {
        Console.WriteLine($"Students in Classroom '{Name}':");
        foreach (var student in Students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
        }
    }

    public void DisplayStudentsByClassType()
    {
        Console.WriteLine($"Students in {Type} Classroom '{Name}':");
        foreach (var student in Students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
        }
    }

    private bool IsFull()
    {
        if (Type == ClassType.Backend && Students.Count >= 20)
        {
            return true;
        }
        else if (Type == ClassType.FrontEnd && Students.Count >= 15)
        {
            return true;
        }
        return false;
    }
}
