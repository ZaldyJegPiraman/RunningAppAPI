using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Channels;

namespace RunningApp.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }

        public int Weight { get; set; } // KG
        public int Height { get; set; } // CM

        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        public double BMI { get
            { 
               return (Weight / Math.Pow(Height, 2)) * 10000 ; 
            }
        }


        public ICollection<RunningActivity> RunningActivities { get; set; }
    }
}
