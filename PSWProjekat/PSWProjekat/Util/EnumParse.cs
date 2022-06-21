using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models.Enums;

namespace PSWProjekat.Util
{
    public class EnumParse
    {
        public static Gender genderString(string gender)
        {
            if (gender == "0")
            {
                return Gender.Male;
            }

            else
            {
                return Gender.Female;
            }
        }

        public static GradeEnum gradeInt(int grade)
        {
            {
                if (grade == 1 )
                {
                    return GradeEnum.one;
                }

                else if(grade == 2)
                {
                    return GradeEnum.two;
                }
                else if (grade == 3)
                {
                    return GradeEnum.three;
                }
                else if (grade == 4)
                {
                    return GradeEnum.four;
                }
                else
                {
                    return GradeEnum.five;
                }
            }
        }
    }
}
