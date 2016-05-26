namespace BeerTap.ApiServices
{
    public class EmployeeLinkParameter
    {
        public EmployeeLinkParameter(int officeId)
        {
            OfficeId = officeId;
        }
        public int OfficeId { get; private set; }
    }
}
