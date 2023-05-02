using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_njwilke
{
    public class Rating
    {
        private int trainerID;
        private string trainerName;
        private string customerName;
        private int starRating;
        private string rating;

        // Overloaded method 
        public Rating(int trainerID, string trainerName, string customerName, int starRating, string rating) {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.customerName = customerName;
            this.starRating = starRating;
            this.rating = rating;
        }

        // No Arg Method
        public Rating() {
            trainerID = 0;
            trainerName = "Nick Wilke";
            customerName = "Will McIntyre";
            starRating = 5;
            rating = "Very Good";
        }
        public int GetTrainerID() {
            return trainerID;
        }
        public string GetTrainerName() {
            return trainerName;
        }
        public void SetCustomerName(string customerName) {
            this.customerName = customerName;
        }
        public string GetCustomerName() {
            return customerName;
        }
        public void SetStarRating(int starRating) {
            this.starRating = starRating;
        }
        public int GetStarRating() {
            return starRating;
        }
        public void SetRating(string rating) {
            this.rating = rating;
        }
        public string GetRating() {
            return rating;
        }
    }
}