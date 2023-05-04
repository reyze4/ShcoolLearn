using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShcoolLearn.Components.Model
{
    public partial class ClientService
    {
        public string TimeConsole
        {
            get
            {
                var time = StartTime - DateTime.Now;
                return $"Начало в {StartTime.ToString("F")}. осталось: {time.ToString(@"hh\:mm")}";
            }
        }

        public string ColorTime
        {
            get
            {
                if (StartTime - DateTime.Now < TimeSpan.FromHours(1))
                {
                    return "red";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
