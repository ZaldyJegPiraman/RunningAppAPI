using RunningApp.DTO;
using RunningApp.Models;

namespace RunningApp.Helpers
{
    public static class Extensions
    {
        public static UserProfileDTO ToUserProfileDTOModel(this UserProfile userProfile)
        {
            var userProfileDTO = new UserProfileDTO()
            {
                Age = userProfile.Age,
                BirthDate = userProfile.BirthDate,
                Height = userProfile.Height,
                Name = userProfile.Name,
                UserId = userProfile.UserId,
                Weight = userProfile.Weight
            };
            return userProfileDTO;
        }

        public static UserProfile ToUserProfileModel(this UserProfileDTO userProfileDTO)
        {
            var userProfile = new UserProfile()
            {
                Age = userProfileDTO.Age,
                BirthDate = userProfileDTO.BirthDate,
                Height = userProfileDTO.Height,
                Name = userProfileDTO.Name,
                UserId = userProfileDTO.UserId,
                Weight = userProfileDTO.Weight
            };
            return userProfile;
        }


        public static RunningActivityDTO ToRunningActivityDTOModel(this RunningActivity runningActivity)
        {
            var runningActivityDTO = new RunningActivityDTO()
            {
                DateTimeEnded = runningActivity.DateTimeEnded,
                DateTimeStarted = runningActivity.DateTimeStarted,
                Distance = runningActivity.Distance,
                Location = runningActivity.Location,
                RunningActivityId = runningActivity.RunningActivityId,
                UserId = runningActivity.UserId,
            };
            return runningActivityDTO;
        }

        public static RunningActivity ToRunningActivityModel(this RunningActivityDTO runningActivityDTO)
        {
            var runningActivity = new RunningActivity()
            {
                DateTimeEnded = runningActivityDTO.DateTimeEnded,
                DateTimeStarted = runningActivityDTO.DateTimeStarted,
                Distance = runningActivityDTO.Distance,
                Location = runningActivityDTO.Location,
                RunningActivityId = runningActivityDTO.RunningActivityId,
                UserId = runningActivityDTO.UserId,
            };
            return runningActivity;
        }

    }
}
