using OnlineShop.BLL.DTO.CategoryDTO;

namespace OnlineShop.BLL.Interfaces
{
    public interface ICategoryService
    {
        ReadCategoryDTO GetCategoryById(int categoryId);
        IEnumerable<ReadCategoryDTO> GetAllCategories();
        void CreateCategory(CreateCategoryDTO category);
        void UpdateCategory(UpdateCategoryDTO category);
        void DeleteCategory(int categoryId);
        // Другие методы, связанные с категориями
    }
}