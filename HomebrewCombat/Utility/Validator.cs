

using System.Xml;
using System.Net;
using System.Text;
using System;

namespace HomebrewCombat
{
    /// <summary>
    /// This class is used to validate user-input
    /// </summary>
    public class Validator
    {


        /// <summary>
        /// Checks if an item has been selected in a listbox
        /// </summary>
        /// <param name="listIndex"></param>
        public static void CheckIfListItemNotSelected(int listIndex)
        {
            if (listIndex == -1)
            {
                throw new ApplicationException("You need to select an item from the list.");
            }

        }

        public static void CheckSoStringIsNumber(string number)
        {
            try
            {
                int test = Int32.Parse(number);
            }
            catch
            {
                throw new ApplicationException("Only integers in the fields made for numbers, please.");
            }
        }

        /// <summary>
        /// Checks if a feed already exists
        /// </summary>
        ///// <param name="feedName"></param>
        //public static void CheckIfExistingFeed(string feedName)
        //{
        //    var categoryList = FileHandler.GetCategoryListFromFile();


        //    foreach (var category in categoryList)
        //    {
        //        foreach (var feed in category.feedList)
        //        {
        //            if (feed.name.Equals(feedName))
        //            {
        //                throw new ApplicationException("That feed name already exists.");
        //            }
        //        }
        //    }



        //}

        /// <summary>
        /// Checks if the URL returns data that actually can be converted to xml 
        /// </summary>
        /// <param name="url"></param>
        public static void CheckIfInvalidURL(string url)
        {
            try
            {
                var xml = "";
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    xml = client.DownloadString(url);

                }

                var dom = new XmlDocument();
                dom.LoadXml(xml);

            }
            catch
            {
                throw new ApplicationException("The provided URL is invalid.");
            }
        }
        /// <summary>
        /// Checks if a category already exists
        /// </summary>
        /// <param name="categoryName"></param>
        //public static void CheckIfExistingCategory(string categoryName)
        //{
        //    var categoryList = FileHandler.GetCategoryListFromFile();


        //    foreach (var category in categoryList)
        //    {

        //        if (category.name.Equals(categoryName))
        //        {
        //            throw new ApplicationException("That category name already exists.");
        //        }

        //    }

        //}
        /// <summary>
        /// Checks if a string contains forbidden words. 
        /// (In our case: The name 'All' is used to show *every* category, and a new category with this name will cause problems.)
        /// </summary>
        /// <param name="stringToCheck"></param>
        public static void CheckIfInvalidString(string stringToCheck)
        {


            if (stringToCheck.Equals("All"))
            {
                throw new ApplicationException("A textbox contains an invalid value. For example: The name 'All' is forbidden.");

            }




        }
        /// <summary>
        /// Checks if a string is blank/null
        /// </summary>
        /// <param name="stringToCheck"></param>
        public static void CheckIfEmptyString(string stringToCheck)
        {
            if (string.IsNullOrWhiteSpace(stringToCheck))
            {
                throw new ApplicationException("A required textbox is empty.");

            }

        }
        /// <summary>
        /// Checks if a decimal (used for our update interval) is at least 1 (minutes)
        /// </summary>
        /// <param name="decimalToCheck"></param>
        public static void CheckIfZeroInterval(decimal decimalToCheck)
        {



            if (decimalToCheck <= 0)
            {
                throw new ApplicationException("The interval must be at least 1 minute.");
            }

        }

    }
}
