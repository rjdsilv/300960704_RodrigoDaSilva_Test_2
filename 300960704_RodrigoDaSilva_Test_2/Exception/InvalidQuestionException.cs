using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300960704_RodrigoDaSilva_Test_2.Exception
{
    class InvalidQuestionException : System.Exception
    {
        public InvalidQuestionException(string message) : base(message)
        {
        }
    }
}
