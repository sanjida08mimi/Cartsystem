namespace CartSystem.Models.ViewModel
{
    public class EditCartRequest
    {
        public int Id { get; set; }
        public string? Colour { get; set; }
        public int Quantity { get; set; }
    }
}
