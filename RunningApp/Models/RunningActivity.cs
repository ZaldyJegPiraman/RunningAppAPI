using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApp.Models
{
    public class RunningActivity
    {
        [Key]
        public int RunningActivityId { get; set; }
        public string? Location { get; set; }
        public DateTime DateTimeStarted { get; set; }
        public DateTime DateTimeEnded { get; set; }
        public int Distance { get; set; } // KM
        public TimeSpan Duration { get
            {
                return  DateTimeEnded.Subtract(DateTimeStarted); 
            }
        } 

        public double AveragePace { get {
                return Duration.TotalSeconds / Distance; 
            }
        }


        [ForeignKey("UserProfile")]
        public int? UserId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
