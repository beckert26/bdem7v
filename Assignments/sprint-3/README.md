# CoronaCases #
## About ##
My project is a C# Console Application. It uses the corona virus data set from the New York Times. The goal of my program is to pull the csv files into a form that allows me to do Language Integrated Queries (LINQ) on the data set. My program gives the users 5 queries they can run on the data set.
<br>The program pulls the csv files from the web everytime it runs, so it continually will have up to date statistics as long as New York times updates their data set.
## Queries ##
<br>1.) **States with the most cases:** Gives a list of the states and their cases in order of most cases to least cases. <br> 
2.) **Top 100 Counties with the most cases:**  Gives a list of the top 100 counties and their cases in order of most cases to least cases. Since there was thousands of counties in the data set I thought it would be most helpful to see the top 100.<br> 
3.) **Total cases in the last 10 days:** Shows the total overall cases in the last 10 days data has been uploaded to the csv file. This query allows users to see how quickly cases are climbing recently. <br>
4.) **Total deaths in the last 10 days:** Shows the total overall deaths in the last 10 days data has been uploaded to the csv file. <br>
5.) **Death rate by state:** Orders the states from highest death rate to lowest deaths rate based on for how many total cases and deaths the state has. <br>

## How to Run ##
To run the program in this folder go to CoronaCases/CoronaCases/bin/Debug/ and download CoronaCases.exe.


