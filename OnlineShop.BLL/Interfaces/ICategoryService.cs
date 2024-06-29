using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<ReadCategoryDTO> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<ReadCategoryDTO>> GetAllCategoriesAsync();
        Task<int> CreateCategoryAsync(CreateCategoryDTO category);
        Task UpdateCategoryAsync(UpdateCategoryDTO category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
