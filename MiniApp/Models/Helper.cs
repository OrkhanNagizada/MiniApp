using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.Models
{
    public static class Helper
    {
        public static bool IsValidName(string name)
        {
            return name.Length >= 3 && name.Split(' ').Length == 1 && char.IsUpper(name[0]);
        }

        public static bool IsValidSurname(string surname)
        {
            return IsValidName(surname);
        }

        public static bool IsValidClassName(string className)
        {
            return className.Length == 5 && char.IsUpper(className[0]) && char.IsUpper(className[1]) && char.IsDigit(className[2]) && char.IsDigit(className[3]) && char.IsDigit(className[4]);
        }
    }

}
