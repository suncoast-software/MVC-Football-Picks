using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Data.SqlClient;
using MVC_Football_Picks.Models;

namespace MVC_Football_Picks.Helpers
{
    public class HttpDataHelper
    {
        /// <summary>
        /// load selected week matchups
        /// </summary>
        /// <param name="week"></param>
        /// <returns>List</returns>
        #region LOAD MATCHUPS
        public static List<Matchup> Load_Matchups(string week)
        {
            string url = "https://www.footballdb.com/scores/index.html?lg=NFL&yr=2019&type=reg&wk=" + week;

            List<Matchup> matchups = new List<Matchup>();
            HtmlWeb page = new HtmlWeb();
            HtmlDocument doc = page.Load(url);

            HtmlNodeCollection gameNodes = doc.DocumentNode.SelectNodes("//table//tbody//tr");

            for (int i = 0; i < gameNodes.Count - 1; i+= 2)
            {
                //AwayTeam
                string[] awayDetails = gameNodes[i].ChildNodes[1].InnerText.Split('(');
                string awayRecord = awayDetails[1].Replace(")", "");
                string awayTeamName = awayDetails[0];
               // string awayFinalScore = gameNodes[i].ChildNodes[7].InnerText;

                //HomeTeam
                string[] homeDetails = gameNodes[i + 1].ChildNodes[1].InnerText.Split('(');
                string homeRecord = homeDetails[1].Replace(")", "");
                string homeTeamName = homeDetails[0];
                //string homeFinalScore = gameNodes[i + 1].ChildNodes[7].InnerText;

                Matchup matchup = new Matchup(awayTeamName, awayRecord, "", homeTeamName, homeRecord, "", "2019", week);
                matchups.Add(matchup);
            }

            return matchups;
        }
        #endregion

        /// <summary>
        /// Get the current week 
        /// </summary>
        /// <returns>string</returns>
        #region GET CURRENT WEEK
        public static string Get_Current_Week()
        {
            string pageUrl = "https://www.footballdb.com/scores/index.html";

            HtmlWeb page = new HtmlWeb();
            HtmlDocument doc = page.Load(pageUrl);

            string[] weekDetails = doc.DocumentNode.SelectSingleNode("//div[@id='leftcol']//h1").InnerText.Split('-');
            string week = weekDetails[1].Replace("Week", "").Trim();

            return week;
        }
        #endregion

        /// <summary>
        /// Get the selected week scores
        /// </summary>
        /// <param name="week"></param>
        /// <returns>List</returns>
        #region GET THE CURRRENT WEEK SCORES
        public static List<Matchup> Get_Week_Scores(string week)
        {
            List<Matchup> scores = new List<Matchup>();
            string url = "https://www.footballdb.com/scores/index.html?lg=NFL&yr=2019&type=reg&wk=" + week;

            HtmlWeb page = new HtmlWeb();
            HtmlDocument doc = page.Load(url);

            HtmlNodeCollection gameNodes = doc.DocumentNode.SelectNodes("//table//tbody//tr");

            for (int i = 0; i < gameNodes.Count - 1; i += 2)
            {
                if (gameNodes[i].ChildNodes.Count > 4)
                {
                    string[] awayDetails = gameNodes[i].ChildNodes[1].InnerText.Split("(");
                    string awayName = awayDetails[0]; ;
                    string awayRecord = awayDetails[1].Replace(")", "");
                    string awayScore = gameNodes[i].ChildNodes[7].InnerText;
                    string[] homeDetails = gameNodes[i + 1].ChildNodes[1].InnerText.Split('(');
                    string homeName = homeDetails[0];
                    string homeRecord = homeDetails[1].Replace(")", "");
                    string homeScore = gameNodes[i + 1].ChildNodes[7].InnerText;

                    Matchup score = new Matchup(awayName, awayRecord, awayScore, homeName, homeRecord, homeScore, "2019", week);
                    scores.Add(score);
                    //Console.WriteLine("{0} : {1} at {2} : {3}", awayName, awayScore, homeName, homeScore);
                }
                else
                {
                    string[] awayDetails = gameNodes[i].ChildNodes[1].InnerText.Split("(");
                    string awayName = awayDetails[0]; ;
                    string awayRecord = awayDetails[1].Replace(")", "");
                    string awayScore = gameNodes[i].ChildNodes[3].InnerText;
                    string[] homeDetails = gameNodes[i + 1].ChildNodes[1].InnerText.Split('(');
                    string homeName = homeDetails[0];
                    string homeRecord = homeDetails[1].Replace(")", "");
                    string homeScore = gameNodes[i + 1].ChildNodes[3].InnerText;

                    Matchup score = new Matchup(awayName, awayRecord, awayScore, homeName, homeRecord, homeScore, "2019", week);
                    scores.Add(score);
                    //Console.WriteLine("{0} : {1} at {2} : {3}", awayName, awayScore, homeName, homeScore);
                }

            }
            return scores;
        }
        #endregion

        /// <summary>
        /// Get Current News
        /// </summary>
        /// <returns></returns>
        #region GET CURRENT NEWS 
        public static List<NewsItem> Get_Current_News()
        {
            List<NewsItem> news = new List<NewsItem>();
            string pageUrl = "footballdb.com/index.html";

            HtmlWeb page = new HtmlWeb();
            HtmlDocument doc = page.Load(pageUrl);

            HtmlNodeCollection newsNodes = doc.DocumentNode.SelectNodes("//div[@class='fb_component_content']//p");

            return news;
        }
        #endregion
    }
}
