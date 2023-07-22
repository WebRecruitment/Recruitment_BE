namespace WebRecruitment.Application.Model.Request.CompanyRequest
{
    public class UpdateRequestCompany
    {
        public UpdateRequestCompany()
        {
        }

        public UpdateRequestCompany(string firstName, string lastName, string email, string address, int contactNumber, string nameCompany)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.address = address;
            this.contactNumber = contactNumber;
            this.nameCompany = nameCompany;
        }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public int contactNumber { get; set; }

        public string nameCompany { get; set; }

    }
}
