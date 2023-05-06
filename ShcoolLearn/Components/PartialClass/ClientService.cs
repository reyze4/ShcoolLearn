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
                return $"Начало: {StartTime.ToString("F")}, осталось: {time.ToString(@"hh\:mm")}";
            }
        }

        public string ColorTimes
        {
            get
            {
                if (StartTime - DateTime.Now < TimeSpan.FromHours(1))
                {
                    return "#ff0000";
                }
                else
                {
                    return "#ffffff";
                }
            }
        }
    }
}
