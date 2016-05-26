namespace BeerTap.ApiServices
{
    public class BeerLinkParameter
    {
        public BeerLinkParameter(int officeId)
        {
            OfficeId = officeId;
        }
        public int OfficeId { get; private set; }
    }
}
