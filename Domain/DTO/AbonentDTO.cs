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
    }
}
