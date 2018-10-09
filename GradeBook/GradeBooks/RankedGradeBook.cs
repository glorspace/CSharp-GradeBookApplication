﻿using System;
using System.Collections.Generic;
using System.Linq;
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
			    throw new InvalidOperationException("Ranked grading requires at least 5 students.");
		    }

		    var numberInGrade = Students.Count / 5;
		    var gradesInOrder = Students.OrderByDescending(student => student.AverageGrade)
										.Select(student => student.AverageGrade)
										.ToList();

		    if (averageGrade.CompareTo(gradesInOrder[numberInGrade]) > 0)
			    return 'A';
		    if (averageGrade.CompareTo(gradesInOrder[numberInGrade * 2]) > 0)
			    return 'B';
		    if (averageGrade.CompareTo(gradesInOrder[numberInGrade * 3]) > 0)
			    return 'C';
		    if (averageGrade.CompareTo(gradesInOrder[numberInGrade * 4]) > 0)
			    return 'D';
			return 'F';
	    }
	}
}