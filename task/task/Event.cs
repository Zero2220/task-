using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class Event
    {

        public Event() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Address { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }




    }
}
