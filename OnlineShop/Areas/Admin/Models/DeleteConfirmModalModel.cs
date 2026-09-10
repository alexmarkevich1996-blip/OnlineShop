namespace OnlineShop.Areas.Admin.Models
{
    public class DeleteConfirmModalModel
    {
        public required string ModalId { get; set; }

        public required string Message { get; set; }

        public required string DeleteUrl { get; set; }
    }
}