using System;
using System.Collections.Generic;
using System.Text;

namespace TopArticles
{
    public class Article
    {
        public string Title { get; set; }

        public string url { get; set; }

        public string author { get; set; }

        public int num_comments { get; set; }

        public string story_id { get; set; }

        public string story_title { get; set; }

        public string story_url { get; set; }

        public string parent_id { get; set; }

        public string create_at { get; set; }
    }

    public class Articles
    {
        public List<Article> articles { get; set; }
    }
}
