using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ApplicationLog : IEntity
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string OccuredAtClass { get; set; }

        [MaxLength(100)]
        public string OccuredAtMethod { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }

        public ApplicationLog()
        {

        }

        public ApplicationLog(string occuredAtClass, string occureeAtMethod, string text)
        {
            this.OccuredAtClass = occuredAtClass;
            this.OccuredAtMethod = occureeAtMethod;
            this.Text = text;
            this.CreatedDate = DateTime.Now;
            this.Type = "Error log";
        }

        public ApplicationLog(string occuredAtClass, string occureeAtMethod, string text, string message)
        {
            this.OccuredAtClass = occuredAtClass;
            this.OccuredAtMethod = occureeAtMethod;
            this.Text = text;
            this.CreatedDate = DateTime.Now;
            this.Message = message;
            this.Type = "Error log";
        }

        public ApplicationLog(string occuredAtClass, string occureeAtMethod, string text, string message, string type)
        {
            this.OccuredAtClass = occuredAtClass;
            this.OccuredAtMethod = occureeAtMethod;
            this.Text = text;
            this.CreatedDate = DateTime.Now;
            this.Message = message;
            this.Type = type;
        }
    }
}
