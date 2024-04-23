namespace TestTask.Models.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
