using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoronaCases
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pull data from csv file
            string stateURL = "https://raw.githubusercontent.com/nytimes/covid-19-data/master/us-states.csv";
            string countyURL = "https://raw.githubusercontent.com/nytimes/covid-19-data/master/us-counties.csv";
            string stateData = GetCSV(stateURL);
            string countyData = GetCSV(countyURL);

            //split columns by ,
            string cstateData = stateData.Replace("\n", ",");
            string ccountyData = countyData.Replace("\n", ",");
            ccountyData = ccountyData.Replace(",,", ",0,");
            // Console.WriteLine(cstateData);

            //list variables to hold each data entry
            List<CoronaState> CoronaStateList = new List<CoronaState>();
            List<CoronaCounties> CoronaCountiesList = new List<CoronaCounties>();

            //add data to lists
            CoronaStateList = addStateData(cstateData);
            CoronaCountiesList = addCountyData(ccountyData);


            string response = "";
            do
            {
                Console.Write("---------------Menu---------------\n" +
                    "1.) States with the most cases\n" +
                    "2.) Top 100 Counties with the most cases\n" +
                    "3.) Total cases in the last 10 days\n" +
                    "4.) Total Deaths in the last 10 days\n" +
                    "5.) Death Rate By State\n"+
                    "6.) Exit\n"+
                    "Select an option: ");
                response = Console.ReadLine();
                Console.WriteLine("");
                if (response == "1")
                {
                    stateMostCases(CoronaStateList);
                }
                else if(response == "2")
                {
                    countyMostCases(CoronaCountiesList);
                }
                else if(response == "3")
                {
                    recentCases(CoronaStateList);
                }
                else if(response == "4")
                {
                    recentDeaths(CoronaStateList);
                }
                else if(response=="5")
                {
                    deathRate(CoronaStateList);
                }
                else if (response == "6")
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That is not an option try again!");
                }
                Console.WriteLine("");

            } while (response != "6");
            Console.WriteLine("States with the most cases:");
            

            Console.ReadLine();
        }
        static string GetCSV(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }
        static List<CoronaState> addStateData(string stateData)
        {
            List<CoronaState> CoronaStateList = new List<CoronaState>();
            List<string> splitted = new List<string>();

            string[] tmpStr;

            tmpStr = stateData.Split(',');
         
            int y = 0;
            foreach (string item in tmpStr)
            {
                if (!string.IsNullOrWhiteSpace(item) && y>=5)
                {
                    splitted.Add(item);
                }
                y++;
            }
            DateTime date=DateTime.Now;
            string state="";
            int fips=0;
            int cases=0;
            int deaths=0;

            int x = 0;
            foreach (string item in splitted)
            {
                if (x == 0) {
                    date = DateTime.ParseExact(item, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    x = 1;
                }
                else if (x == 1) {
                    state = item;
                    x = 2;
                }
                else if (x == 2)
                {
                    fips = ChangeToInt(item);
                    x = 3;
                }
                else if (x == 3)
                {
                    cases = ChangeToInt(item);
                    x = 4;
                }
                else
                {
                    deaths = ChangeToInt(item);
                    x = 0;
                    CoronaState coronastate = new CoronaState(date, state, fips, cases, deaths);
                    CoronaStateList.Add(coronastate);
                }
                    
            }
             return CoronaStateList;
        }

        static List<CoronaCounties> addCountyData(string stateData)
        {
            List<CoronaCounties> CoronaCountyList = new List<CoronaCounties>();
            List<string> splitted = new List<string>();

            string[] tmpStr;

            tmpStr = stateData.Split(',');
            int y = 0;
            foreach (string item in tmpStr)
            {
                if (!string.IsNullOrWhiteSpace(item) && y >= 6)
                {
                    splitted.Add(item);
                }
                y++;
            }
            DateTime date = DateTime.Now;
            string county="";
            string state = "";
            int fips = 0;
            int cases = 0;
            int deaths = 0;

            int x = 0;
            foreach (string item in splitted)
            {
                if (x == 0)
                {
                    date = DateTime.ParseExact(item, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    x = 1;
                }
                else if (x == 1)
                {
                    county = item;
                    x = 2;
                }
                else if (x == 2)
                {
                    state = item;
                    x = 3;
                }
                else if (x == 3)
                {
                    fips = ChangeToInt(item);
                    x = 4;
                }
                else if (x == 4)
                {
                    cases = ChangeToInt(item);
                    x = 5;
                }
                else
                {
                    deaths = ChangeToInt(item);
                    x = 0;
                    CoronaCounties coronacounties = new CoronaCounties(date, county, state, fips, cases, deaths);
                    CoronaCountyList.Add(coronacounties);
                }

            }
            return CoronaCountyList;
        }
        static int ChangeToInt(string s)
        {
            int i;
            i= Int32.Parse(s);
            return i;
        }

        static void stateMostCases(List<CoronaState> CoronaStateList)
        {
            int z = 1;
            foreach (var line in CoronaStateList.GroupBy(info => info.State).Select(group => new {
                State = group.Key,
                Cases = group.Select(info => info.Cases).Max()
            })
                .OrderByDescending(x => x.Cases))
            {
                Console.WriteLine("{0}.) {1} {2}", z, line.State, line.Cases);
                z++;
            }

        }

        static void countyMostCases(List<CoronaCounties> CoronaCountyList)
        {
            int z = 1;
            foreach (var line in CoronaCountyList.GroupBy(info => info.County).Select(group => new {
                County = group.Key,
                Cases = group.Select(info => info.Cases).Max()
            })
                .OrderByDescending(x => x.Cases).Take(100))
            {
                Console.WriteLine("{0}.) {1} {2}", z, line.County, line.Cases);
                z++;
            }
        }
        static void recentCases(List<CoronaState> CoronaStateList)
        {

            var days = (from CoronaState in
                                  (from c in CoronaStateList
                                   select new {c.Date})
                               group CoronaState by CoronaState.Date into g
                               orderby g.Key.Year descending, g.Key.Month descending, g.Key.Day descending
                               select new
                               {
                                   Date = g.First().Date,

                               }).Take(10);
            foreach(var item in days)
            {
                int sum = 0;
                foreach(
                    var cases in CoronaStateList.Where(x => x.Date == item.Date).GroupBy(info => info.State).Select(group => new
                    {
                        State = group.Key,
                        Cases = group.Select(info => info.Cases).Sum()
                    }))
                { 
                    sum+= cases.Cases;
                    
                 }
                Console.WriteLine("Date: {0} Cases: {1}", item.Date, sum);
            }
        }

        static void recentDeaths(List<CoronaState> CoronaStateList)
        {
            var days = (from CoronaState in
                                 (from c in CoronaStateList
                                  select new { c.Date })
                        group CoronaState by CoronaState.Date into g
                        orderby g.Key.Year descending, g.Key.Month descending, g.Key.Day descending
                        select new
                        {
                            Date = g.First().Date,

                        }).Take(10);
            foreach (var item in days)
            {
                int sum = 0;
                foreach (
                    var cases in CoronaStateList.Where(x => x.Date == item.Date).GroupBy(info => info.State).Select(group => new
                    {
                        State = group.Key,
                        Deaths = group.Select(info => info.Deaths).Sum()
                    }))
                {
                    sum += cases.Deaths;

                }
                Console.WriteLine("Date: {0} Cases: {1}", item.Date, sum);
            }
        }
        static void deathRate(List<CoronaState> CoronaStateList)
        {
            int z = 1;
            foreach (var line in CoronaStateList.GroupBy(info => info.State).Select(group => new
            {
                State = group.Key,
                DeathRate = group.Select(info => info.Deaths*1.0/info.Cases)
            })
                .OrderByDescending(x => x.DeathRate.Last()))
            {
                Console.WriteLine("{0}.) {1} {2}", z, line.State, Math.Round(line.DeathRate.Last(),5));
                z++;
            }
        }


    }
}
