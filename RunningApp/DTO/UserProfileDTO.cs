namespace RunningApp.DTO
{
    public class UserProfileDTO
    {
        public int UserId { get; set; }
        public string? Name { get; set; }

        public int Weight { get; set; } // KG
        public int Height { get; set; } // CM

        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        public double BMI
        {
            get
            {
                return (Weight / Math.Pow(Height, 2)) * 10000;
            }
        }
    }
}
