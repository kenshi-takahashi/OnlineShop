using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;

namespace OnlineShop.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<ReadCategoryDTO> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<ReadCategoryDTO>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDTO category);
        Task UpdateCategoryAsync(UpdateCategoryDTO category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
