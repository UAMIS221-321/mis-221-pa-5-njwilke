using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_njwilke
{
    public class Membership
    {
        private string customerName;
        private string customerEmail;
        private int membershipCost;
        private string membershipDate;
        private string membershipStatus;

        // Overloaded Method
        public Membership(string customerName, string customerEmail, int membershipCost, string membershipDate, string membershipStatus) {
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.membershipCost = membershipCost;
            this.membershipDate = membershipDate;
            this.membershipStatus = membershipStatus;
        }

        // No Arg Method
        public Membership() {
            customerName = "Will McIntyre";
            customerEmail = "wjmcintyre@crimson.ua.edu";
            membershipCost = 120;
            membershipDate = "05/01/23";
            membershipStatus = "Active";
        }

        public void SetCustomerName(string customerName) {
            this.customerName = customerName;
        }
        public string GetCustomerName() {
            return customerName;
        }
        public void SetCustomerEmail(string customerEmail) {
            this.customerEmail = customerEmail;
        }
        public string GetCustomerEmail() {
            return customerEmail;
        }
        public int GetMembershipCost() {
            return membershipCost;
        }
        public string GetMembershipDate() {
            return membershipDate;
        }
        public void SetMembershipStatus(string membershipStatus) {
            this.membershipStatus = membershipStatus;
        }
        public string GetMembershipStatus() {
            return membershipStatus;
        }
    }
}