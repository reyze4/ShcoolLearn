using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShcoolLearn.Components.Model
{
    public partial class Client
    {
        public string FName
        {
            get
            {
                return $"{LastName} {FirstName} {Patronymic}";
            }
        }
    }
}


