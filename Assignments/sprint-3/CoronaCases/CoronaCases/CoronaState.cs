using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaCases
{
    class CoronaState
    {
        public CoronaState(DateTime date, string state, int fips, int cases, int deaths)
        {
            this.Date = date;
            this.State = state;
            this.Fips = fips;
            this.Cases = cases;
            this.Deaths = deaths;
        }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public int Fips { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
    }
}
