namespace TopArticles
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;

    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        public static List<string> Titles = new List<string>()
    {
        "UK votes to leave EU",
        "F.C.C. Repeals Net Neutrality Rules",
        "EU approves internet copyright law, including ‘link tax’ and ‘upload filter’",
        "Switch from Chrome to Firefox",
        "W3C abandons consensus, standardizes DRM, EFF resigns",
        "Tim Cook Speaks Up",
        "A Message to Our Customers",
        "Don't Fly During Ramadan",
        "SpaceX’s Falcon Heavy successfully launches",
        "macOS High Sierra: Anyone can login as “root” with empty password",
        "Chrome 69 will keep Google Cookies when you tell it to delete all cookies",
        "Paradise Papers: Dear Tim Cook",
        "Pardon Snowden",
        "How Uber Used Secret “Greyball” Tool to Deceive Authorities Worldwide",
        "Why I Quit Google to Work for Myself",
        "Silicon Valley Women, in Cultural Shift, Frankly Describe Sexual Harassment",
        "No Thank You, Mr. Pecker",
        "Obama Commutes Bulk of Chelsea Manning’s Sentence"
    };

        public static object[][] Inputs = new[] { 2, 1, 3, 4, 5, 6, 7, 9, 8, 10, 11, 18 }
              .Select(n => new object[] { n, Titles.Take(n).ToList() })
              .ToArray();

        [TestCaseSource(nameof(Inputs))]
        public void TopArticles(int limit, List<string> result)
        {
            var topArticles = Solution.TopArticles(limit);
            topArticles.Should().Equal(result);
        }
    }
}
