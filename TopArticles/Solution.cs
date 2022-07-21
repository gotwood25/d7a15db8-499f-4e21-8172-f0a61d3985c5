namespace TopArticles
{
    using System.Collections.Generic;
    using System;
    using RestSharp;
    using System.Net;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq;

    class Solution
    {
        /*
         * Complete the 'topArticles' function below.
         *
         * The function is expected to return a STRING_ARRAY.
         * The function accepts INTEGER limit as parameter.
         * base url for copy/paste:
         * https://jsonmock.hackerrank.com/api/articles?page=<pageNumber>
         */

        public static List<string> TopArticles(int limit)
        {

            IList<Article> articles = new List<Article>();
            List<string> Titles = new List<string>();

            var totalPages = GetTotalPages();

            for (int i = 1; i <= totalPages; i++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonmock.hackerrank.com/api/articles?page=" + i);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        string titles = streamReader.ReadToEnd();

                        var result = JObject.Parse(titles);
                        var data = result["data"];

                        foreach (var item in data)
                        {
                            var article = new Article();

                            article.author = item["author"].ToString();
                            if (item["title"].ToString() == null || item["title"].ToString() == "")
                            {   article.Title = "Title"; }
                            else {  article.Title = item["title"].ToString();   }

                            if (item["num_comments"].ToString() == "")
                            { article.num_comments = 0; }
                            else { article.num_comments = (int)item["num_comments"]; }

                            article.parent_id = item["parent_id"].ToString();
                            article.story_id = item["story_id"].ToString();
                            article.story_title = item["story_title"].ToString();
                            article.story_url = item["story_url"].ToString();
                            article.url = item["url"].ToString();

                            articles.Add(article);
                        }
                    }
                }
            }

            List<Article> SortedArticles = articles.OrderByDescending(t => t.num_comments).ThenBy(c => c.Title).Take(limit).ToList();

            for (int j = 0; j < limit; j++)
            {
                Titles.Add(SortedArticles[j].Title);
            }

            return Titles;
        }

        private static int GetTotalPages()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonmock.hackerrank.com/api/articles?page=1");
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string titles = streamReader.ReadToEnd();

                var result = JObject.Parse(titles);
                var data = result["total"];

                return (int)data;
            }
        }
    }
}