using System.ComponentModel.DataAnnotations;


namespace TravelAPI
{
    public class PrototypeModel
    {
        [Key]
        public int PrototypeModelId { get; private set; }
        public string Name { get; private set; }
    }
}