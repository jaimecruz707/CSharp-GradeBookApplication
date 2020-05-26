using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook( string name ) : base( name )
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade( double averageGrade )
        {
            if ( Students.Count < 5 )
            {
                throw new InvalidOperationException();
            }

            var allAverageGrade = new List<double>();

            Students.ForEach( n => allAverageGrade.Add( n.AverageGrade ) );

            allAverageGrade.Sort();
            allAverageGrade.Reverse();
            var sizes = new List<double>()
            {
                allAverageGrade.Count * 0.2,
                (allAverageGrade.Count * 0.4),
                allAverageGrade.Count * 0.6,
                allAverageGrade.Count * 0.8
            };

            for ( int i = 0, position = 0; i < allAverageGrade.Count; i++, position++ )
            {
                if( allAverageGrade[i] < averageGrade )
                {
                    position = i;
                    if ( position >= sizes[0] )
                        return 'A';
                    else if ( sizes[0] > position && position > sizes[1] )
                        return 'B';
                    else if ( sizes[1] > position && position > sizes[2] )
                        return 'C';
                    else if ( sizes[2] > position && position > sizes[3] )
                        return 'D';
                    break;
                }
            }

            return 'F';
        }


    }
}
