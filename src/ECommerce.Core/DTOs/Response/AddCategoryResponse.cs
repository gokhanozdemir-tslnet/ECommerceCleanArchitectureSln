

using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.DTOs.Response
{
    public class AddCategoryResponse
    {
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
