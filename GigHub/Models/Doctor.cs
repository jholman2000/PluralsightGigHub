using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PracticeID { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Pager { get; set; }
        public string EmailAddress { get; set; }
        public Attitude Attitude { get; set; }        
        public bool FavAdultEmergency { get; set; }
        public bool FavAdultNonEmergency { get; set; }
        public bool NotFavAdult { get; set; }
        public bool FavChildEmergency { get; set; }
        public bool FavChildNonEmergency { get; set; }
        public bool NotFavChild { get; set; }
        public bool AcceptsMedicaid { get; set; }
        public bool ConsultAdultEmergency { get; set; }
        public bool ConsultChildEmergency { get; set; }
        public string NOTES { get; set; }
        public string DOCNOTES { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }

        //-- New fields 1/30/11
        public Status Status { get; set; }
        public DateTime StatusDate { get; set; }
        public YesNoUnknown RegContacted { get; set; }
        public YesNoUnknown SpecificallyKnown { get; set; }
        public YesNoUnknown FrequentlyTreat { get; set; }
        public YesNoUnknown Helpful { get; set; }
        public int TreatYears { get; set; }
        public bool IsHRP { get; set; }         // High Risk Pregnancy
        public bool IsBSMP { get; set; }        // Bloodless Surgery Management Program
        public string PeerReview { get; set; }
    }

    public enum Attitude
    {
        Unknown,
        Cooperative,
        Favorable,
        Limitations,
        NotFavorable
    }

    public enum Status
    {
        Unknown,
        NewlyIdentified,
        LetterSent,
        notused3,
        notused4,
        notused5,
        notused6,
        Deceased,
        MovedOutOfArea,
        Active,
        Retired
    }
    public enum YesNoUnknown
    {
        Unknown,
        Yes,
        No
    }
}