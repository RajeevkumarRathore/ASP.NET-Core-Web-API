using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Net;
using System.Web;

namespace Common.Helper
{
    public static class CommonHelper
    {
        public static byte[] ConvertHtmlToPdfByteArray(string html)
        {
            StringReader sr = new(html.ToString());
            iTextSharp.text.Document pdfDoc = new(PageSize.A3, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new(pdfDoc);
            using MemoryStream memoryStream = new();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            var attachment = memoryStream.ToArray();
            memoryStream.Close();
            return attachment;
        }
        /// <summary>
        /// Set session values
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetValuesInSession(HttpContext httpContext, string key, object value, string secret)
        {
            httpContext.Session.SetObjectAsJson(key, value, secret);
        }

        /// <summary>
        /// Get values from session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValuesFromSession<T>(HttpContext httpContext, string key, string secret)
        {
            return httpContext.Session.GetObjectFromJson<T>(key, secret);
        }
        /// <summary>
        /// Remove key from session if present.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="key"></param>
        public static void RemoveKeyFromSession(HttpContext httpContext, string key)
        {
            httpContext.Session.Remove(key);
        }

        /// <summary>
        /// Remove all entries from the current session, if any.
        /// The session cookie is not removed.
        /// </summary>
        /// <param name="httpContext"></param>
        public static void ClearSession(HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }

        /// <summary>
        /// Get boolean value from object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool GetBooleanValue(object value)
        {
            bool output = false;
            try
            {
                output = Convert.ToBoolean(value);
            }
            catch (System.Exception)
            {
            }
            return output;
        }

        /// <summary>
        /// Get integer value from object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetIntegerValue(object value)
        {
            int output = 0;
            try
            {
                output = Convert.ToInt32(value);
            }
            catch (System.Exception)
            {
            }
            return output;
        }

        /// <summary>
        /// Get string value from object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(object value)
        {
            string output = string.Empty;
            try
            {
                output = Convert.ToString(value);
            }
            catch (System.Exception)
            {
            }
            return output;
        }

        public static string GenerateRandomPassword()
        {
            string[] randomChars = new[] {
                                            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                                            "abcdefghijkmnopqrstuvwxyz",    // lowercase
                                            "0123456789",                   // digits
                                            "!@$?_-"                        // non-alphanumeric
                                         };
            Random rand = new(Environment.TickCount);
            List<char> chars = new();

            chars.Insert(rand.Next(0, chars.Count),
                randomChars[0][rand.Next(0, randomChars[0].Length)]);

            chars.Insert(rand.Next(0, chars.Count),
                randomChars[1][rand.Next(0, randomChars[1].Length)]);

            chars.Insert(rand.Next(0, chars.Count),
                randomChars[2][rand.Next(0, randomChars[2].Length)]);

            chars.Insert(rand.Next(0, chars.Count),
                randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < 8
                || !chars.Distinct().Any(); i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
        public static string RandomNumbers(int Length)
        {
            Random Rand = new Random();
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < Length; i++)
                SB.Append(Rand.Next(0, 9));

            return SB.ToString();
        }
        //public static byte[] CreatePdfUsingSelectHtmlToPdf(string html)
        //{
        //    var htmlToPdf = new SelectPdf.HtmlToPdf();
        //    var pdfDoc = htmlToPdf.ConvertHtmlString(html);
        //    var pdf = pdfDoc.Save();
        //    pdfDoc.Close();
        //    return pdf;
        //}

        public static String TranslateLanguages(string word, string fromLanguage, string toLanguage)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
        public static string GetFormattedDateTime(DateTime statDate, DateTime endDate)
        {
            string formattedDateTime = string.Empty;
            TimeSpan span = endDate.Subtract(statDate);

            if (span.Days > 365)
            {
                int years = Convert.ToInt32(span.Days / 365);
                if (years == 1)
                {
                    formattedDateTime = "1 year ago";
                }
                else
                {
                    formattedDateTime = $"{years} years ago";
                }
            }
            else if (span.Days > 30 && span.Days <= 365)
            {
                int months = Convert.ToInt32(span.Days / 31);
                if (months == 1)
                {
                    formattedDateTime = "1 month ago";
                }
                else
                {
                    formattedDateTime = $"{months} months ago";
                }
            }
            else if (span.Days > 0 && span.Days <= 30)
            {
                if (span.Days <= 1)
                {
                    formattedDateTime = $"{span.Days} day ago";
                }
                else
                {
                    formattedDateTime = $"{span.Days} days ago";
                }
            }
            else if (span.Hours > 0 && span.Hours <= 24)
            {
                if (span.Hours <= 1)
                {
                    formattedDateTime = $"{span.Hours} hour ago";
                }
                else
                {
                    formattedDateTime = $"{span.Hours} hours ago";
                }
            }
            else if (span.Minutes > 0 && span.Minutes <= 59)
            {
                if (span.Minutes <= 1)
                {
                    formattedDateTime = $"{span.Minutes} minute ago";
                }
                else
                {
                    formattedDateTime = $"{span.Minutes} minutes ago";
                }
            }
            else if (span.Minutes <= 0)
            {
                formattedDateTime = "Just Now";
            }
            return formattedDateTime;
        }

    }

}
