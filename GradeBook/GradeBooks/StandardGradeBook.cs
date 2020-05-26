using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook( string name ) : base( name )
        {
            Type = GradeBookType.Standard; // initializes the the type of GradeBook to be a standard Type

        }
    }
}
