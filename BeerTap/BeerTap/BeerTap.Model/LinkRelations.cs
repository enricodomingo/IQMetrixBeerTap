namespace BeerTap.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>

        public const string Office = "iq:Office";

        public static class Offices
        {
            public const string BeerTap = "iq:BeerTap";
            public const string EmployeeTap = "iq:EmployeeTap";
            public const string ReplaceKeg = "iq:ReplaceKeg";
        }
    }
    

}
