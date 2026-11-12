using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var students = new List<Student>
{
    new("John", 92),
    new("Emma", 88),
    new("Michael", 74),
    new("Sophia", 95),
    new("Daniel", 81),
    new("Olivia", 67),
    new("James", 79),
    new("Ava", 73),
    new("William", 85),
    new("Isabella", 91),
    new("Benjamin", 76),
    new("Mia", 69)
};

var topStudents = students
    .Where(student => student.Score >= 75)
    .OrderByDescending(student => student.Score)
    .Take(3)
    .Select(student => $"{student.Name} — {student.Score}")
    .ToList();

const string reportPath = "report.txt";

File.WriteAllLines(reportPath, topStudents);

Console.WriteLine($"Report written to: {Path.GetFullPath(reportPath)}");
Console.WriteLine();
Console.WriteLine("Report contents:");

foreach (var line in File.ReadAllLines(reportPath))
{
    Console.WriteLine(line);
}

public record Student(string Name, int Score);