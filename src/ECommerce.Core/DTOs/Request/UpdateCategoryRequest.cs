

namespace ECommerce.Core.DTOs.Request
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTime UpdatedDate { get; set; }=DateTime.Now;
    }
}
