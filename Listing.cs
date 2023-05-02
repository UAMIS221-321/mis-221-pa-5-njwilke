using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_njwilke
{
    public class Listing
    {
        private int listingID;
        private string trainerName;
        private string sessionDate;
        private string sessionTime;
        private double sessionCost;
        private int sessionAvailability;

        // Overloaded Method
        public Listing(int listingID, string trainerName, string sessionDate, string sessionTime, double sessionCost, int sessionAvailability) {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost;
            this.sessionAvailability = sessionAvailability;
        }

        // No Arg Method

        public Listing() {
            listingID = 0;
            trainerName = "Nick";
            sessionDate = "04/11/2023";
            sessionTime = "3:30 PM";
            sessionCost = 50;
            sessionAvailability = 15;
        }

        public void SetListingID(int listingID) {
            this.listingID = listingID;
        }

        public int GetListingID() {
            return listingID;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public void SetSessionDate(string sessionDate) {
            this.sessionDate = sessionDate;
        }

        public string GetSessionDate() {
            return sessionDate;
        }

        public void SetSessionTime(string sessionTime) {
            this.sessionTime = sessionTime;
        }

        public string GetSessionTime() {
            return sessionTime;
        }

        public void SetSessionCost(double sessionCost) {
            this.sessionCost = sessionCost;
        }

        public double GetSessionCost() {
            return sessionCost;
        }

        public void SetSessionAvailability(int sessionAvailability) {
            this.sessionAvailability = sessionAvailability;
        }

        public int GetSessionAvailability() {
            return sessionAvailability;
        }
    }
}