using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_njwilke
{
    public class Booking
    {
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private int trainerID; 
        private string trainerName;
        private string sessionStatus;

        // Overloaded Method 
        public Booking(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, string sessionStatus) {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.sessionStatus = sessionStatus;
        }

        // No Arg Constructor
        public Booking() {
            sessionID = 0;
            customerName = "William McIntyre";
            customerEmail = "wjmcintyre@crimson.ua.edu";
            trainingDate = "04/11/2023";
            trainerID = 0;
            trainerName = "Nick";
            sessionStatus = "Booked";
        }

        public void SetCustomerName(string customerName) {
            this.customerName = customerName;
        }

        public void SetCustomerEmail(string customerEmail) {
            this.customerEmail = customerEmail;
        }

        public void SetSessionStatus(string sessionStatus) {
            this.sessionStatus = sessionStatus;
        }
        public int GetSessionID() {
            return sessionID;
        }

        public string GetCustomerName() {
            return customerName;
        }

        public string GetCustomerEmail() {
            return customerEmail;
        }

        public string GetTrainingDate() {
            return trainingDate;
        }

        public int GetTrainerID() {
            return trainerID;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public string GetSessionStatus() {
            return sessionStatus;
        }
    }
}