using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAA.Helpers
{
    public class Utility
    {
        public static string GetOfferText(string offer)
        {
            if(string.IsNullOrEmpty(offer)) return string.Empty;

            switch (offer.Trim().ToUpper())
            {
                case "R":
                    return "Reject";

                case "P":
                    return "Pending";

                case "C":
                    return "Conditional";

                case "U":
                    return "Unconditional";
                default:
                    return offer.Trim().ToUpper();
            }
        }
    }
}