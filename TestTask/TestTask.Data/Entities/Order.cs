using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public User User { get; set; }

    }
}
