using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace testProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<string> dates = new List<string>();

            using (StreamReader reader = new StreamReader("acme_worksheet.csv")) 
            {
                string rowStr = reader.ReadLine();
                string[] rowArrayStr;
                bool firstDateInDatesList = true,
                     addDateForDatesList,
                     exitFromIteration;

                for (string lineStr = reader.ReadLine(); lineStr != null; lineStr = reader.ReadLine()) {
                    rowArrayStr = lineStr.Split(',');
                    addDateForDatesList = true;
                    exitFromIteration = false;

                    if (firstDateInDatesList) {
                        dates.Add(rowArrayStr[1]);
                        firstDateInDatesList = false;
                    }

                    for (int i = 0; i < dates.Count; i++)
                        if (dates[i] == rowArrayStr[1])
                            addDateForDatesList = false;

                    if(addDateForDatesList)
                        dates.Add(rowArrayStr[1]);

                    for (int i = 0; i < employees.Count; i++)
                        if(employees[i].Name == rowArrayStr[0]) {
                            employees[i].AddNewCoupleToDict(rowArrayStr[1], rowArrayStr[2]);
                            exitFromIteration = true;
                            break;
                        }

                    if(!exitFromIteration)
                        employees.Add(new Employee(rowArrayStr[0], rowArrayStr[1], rowArrayStr[2]));
                }
            }

            employees.Sort();

            using (StreamWriter writer = new StreamWriter("output.csv"))
            {
                writer.Write("Name/Date");
                for (int i = 0; i < dates.Count; i++)
                    writer.Write("," + GetDateString(dates[i]));
                writer.WriteLine();

                for (int i = 0; i < employees.Count; i++) {
                    writer.Write(employees[i].Name);
                    writer.Write(employees[i].GetHourString(dates) + "\n");
                }
            }
        }

        static string GetDateString(string dateStr)
        {
            string[] dateArrayStr = dateStr.Split();
            string answer = $"{dateArrayStr[2]}-";

            switch (dateArrayStr[0]) {
                case "Jan": answer += "01"; break;
                case "Feb": answer += "02"; break;
                case "Mar": answer += "03"; break;
                case "Apr": answer += "04"; break;
                case "May": answer += "05"; break;
                case "Jun": answer += "06"; break;
                case "Jul": answer += "07"; break;
                case "Aug": answer += "08"; break;
                case "Sep": answer += "09"; break;
                case "Oct": answer += "10"; break;
                case "Nov": answer += "11"; break;
                case "Dec": answer += "12"; break;
                default: break;
            }

            answer += $"-{dateArrayStr[1]}";

            return answer;
        }
    }
}
