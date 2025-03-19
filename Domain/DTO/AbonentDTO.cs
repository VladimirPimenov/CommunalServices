using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.DTO
{
    /// <summary>
    /// DTO для передачи данных об абоненте.
    /// </summary>
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
                Login = Login,
                Password = Password,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName
            };
        }

        public static AbonentDTO FromAbonent(Abonent abonent)
        {
            return new AbonentDTO
            {
                Login = abonent.Login,
                Password = abonent.Password,
                Email = abonent.Email,
                FirstName = abonent.FirstName,
                LastName = abonent.LastName
            };
        }
    }
}
