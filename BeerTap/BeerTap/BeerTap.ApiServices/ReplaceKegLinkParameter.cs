namespace BeerTap.ApiServices
{
    public class ReplaceKegLinkParameter
    {
        public ReplaceKegLinkParameter(int officeId, int beerId)
        {
            OfficeId = officeId;
            BeerId = beerId;
        }
        public int OfficeId { get; private set; }
        public int BeerId { get; private set; }
    }
}
