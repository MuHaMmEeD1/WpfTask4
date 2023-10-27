using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class MyMesseg
    {
        public string messeg { get; set; }
        public DateTime time { get; set; }

        public override string ToString()
        {
            return $"{time.ToShortTimeString()}          {messeg}"; 
        }

    }
}
