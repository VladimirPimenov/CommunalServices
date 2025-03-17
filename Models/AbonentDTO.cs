namespace CommunalServices.Models
{
    public class AbonentDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Abonent ConvertToAbonent()
        {
            return new Abonent()
            {
                Login = this.Login,
                Password = this.Password,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}
