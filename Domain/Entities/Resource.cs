namespace CommunalServices.Domain.Entities
{
    /// <summary>
    /// Представляет ресурс в системе.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Уникальный идентификатор ресурса.
        /// </summary>
        public int ResourceId { get; set; }

        /// <summary>
        /// Название ресурса.
        /// </summary>
        public string ResourceName { get; set; }
    }
}
