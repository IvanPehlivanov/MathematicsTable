using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicsTable
{
    class Calculations
    {
        /// <summary>
        /// calculate correct table values
        /// </summary>
        /// <param name="op">math function</param>
        /// <returns>list with correct values</returns>
        internal List<string[]> CalculateTable(string op)
        {
            List<string[]> correctValuesList = new List<string[]>();

            for (int i = 0; i < 10; i++)
            {
                string[] correctValues = new string[10];

                for (int j = 0; j < 10; j++)
                {
                    if (op == "-")
                    {
                        double result = (i + 1.0) - (j + 1.0);
                        correctValues[j] = result.ToString();
                    }
                    else if (op == "+")
                    {
                        double result = (i + 1.0) + (j + 1.0);
                        correctValues[j] = result.ToString();
                    }
                    else if (op == "*")
                    {
                        double result = (i + 1.0) * (j + 1.0);
                        correctValues[j] = result.ToString();
                    }
                    else if (op == "/")
                    {
                        double result = (i + 1.0) / (j + 1.0);
                        result = Math.Round(result, 2);
                        correctValues[j] = result.ToString();
                    }
                }
                correctValuesList.Add(correctValues);
            }

            return correctValuesList;
        }

        /// <summary>
        /// compares two array lists
        /// </summary>
        /// <param name="correctValuesList">first list</param>
        /// <param name="userInputList">second list</param>
        /// <returns>list of wrong line numbers</returns>
        internal List<int> CompareLists(List<string[]> correctValuesList, List<string[]> userInputList)
        {
            bool isOk = false;
            List<int> wrongLineNumber = new List<int>();

            for (int i = 0; i < correctValuesList.Count; i++)
            {
                isOk = correctValuesList[i].SequenceEqual(userInputList[i]);
                if (!isOk)
                {
                    wrongLineNumber.Add(i);
                }
            }

            return (wrongLineNumber);
        }
    }
}
