using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaCases
{
    class CoronaCounties
    {
        public CoronaCounties(DateTime date, string county, string state, int fips, int cases, int deaths)
        {
            this.Date = date;
            this.County = county;
            this.State = state;
            this.Fips = fips;
            this.Cases = cases;
            this.Deaths = deaths;
        }
        public DateTime Date { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public int Fips { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
    }
}
