using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject
{
    class Employee : IComparable<Employee>
    {
        private string name;
        private Dictionary<string, string> dateAndTime = new Dictionary<string, string>();

        public Employee(string _name, string _date, string _hour)
        {
            name = _name.Trim();
            dateAndTime.Add(_date.Trim(), _hour.Trim());
        }

        public string Name { get { return name; } }

        public void AddNewCoupleToDict(string _date, string _hour)
        {
            dateAndTime.Add(_date.Trim(), _hour.Trim());
        }

        public string GetHourString(List<string> dates)
        {
            StringBuilder hoursRowStr = new StringBuilder();

            for (int i = 0; i < dates.Count; i++)
            {
                hoursRowStr.Append(",");
                hoursRowStr.Append(dateAndTime.ContainsKey(dates[i]) ? Convert.ToString(dateAndTime[dates[i]]) : "0");
            }

            return Convert.ToString(hoursRowStr);
        }

        public int CompareTo(Employee obj)
        {
            return name.CompareTo(obj.Name);
        }
    }
}
