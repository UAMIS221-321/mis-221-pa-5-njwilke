using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_njwilke
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmail;
        
        // overloaded method
        public Trainer(int trainerID, string trainerName, string mailingAddress, string trainerEmail) {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmail = trainerEmail;
        }
        // no args
        public Trainer() {
            trainerID = 0;
            trainerName = "Nick";
            mailingAddress = "My House on 13th";
            trainerEmail = "njwilke@crimson.ua.edu";
        }
        public void SetTrainerID(int trainerID) {
            this.trainerID = trainerID;
        }

        public int GetTrainerID() {
            return trainerID;
        }

        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }

        public string GetTrainerName() {
            return trainerName;
        }

        public void SetMailingAddress(string mailingAddress) {
            this.mailingAddress = mailingAddress;
        }

        public string GetMailingAddress() {
            return mailingAddress;
        }

        public void SetTrainerEmail(string trainerEmail) {
            this.trainerEmail = trainerEmail;
        }

        public string GetTrainerEmail() {
            return trainerEmail;
        }
    }
}