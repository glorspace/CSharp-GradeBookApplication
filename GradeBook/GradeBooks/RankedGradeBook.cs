using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
	    public RankedGradeBook(string name) : base(name)
	    {
		    Type = GradeBookType.Ranked;
	    }

	    public override char GetLetterGrade(double averageGrade)
	    {
		    if (Students.Count < 5)
		    {
			    throw new InvalidOperationException();
		    }

		    var numberInGrade = Students.Count / 5;
		    var studentsInOrder = new List<Student>();
			Students.ForEach(student => studentsInOrder.Add(student));
		    studentsInOrder.Sort((left, right) => right.AverageGrade.CompareTo(left.AverageGrade));

		    if (averageGrade.CompareTo(studentsInOrder[numberInGrade].AverageGrade) > 0)
			    return 'A';
		    if (averageGrade.CompareTo(studentsInOrder[numberInGrade * 2].AverageGrade) > 0)
			    return 'B';
		    if (averageGrade.CompareTo(studentsInOrder[numberInGrade * 3].AverageGrade) > 0)
			    return 'C';
			return 'F';
	    }
	}
}
