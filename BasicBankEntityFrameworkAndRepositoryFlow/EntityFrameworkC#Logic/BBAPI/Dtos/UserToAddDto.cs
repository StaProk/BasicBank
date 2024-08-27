namespace BBAPI.Dtos
{
    public partial class UserToAddDto
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}

        public UserToAddDto()
        {
            if (FirstName == null)
            {
                FirstName = "";
            }
            if (LastName == null)
            {
                LastName = "";
            }
            if (Email == null)
            {
                Email = "";
            }
        }
    }
}
