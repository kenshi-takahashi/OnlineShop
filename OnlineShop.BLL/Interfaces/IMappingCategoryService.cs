using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;

namespace OnlineShop.BLL.Interfaces
{
    public interface IMappingCategoryService
    {
        ReadCategoryDTO MapCategorysToReadCategoryDTO(Category category);
        Category MapCreateCategorysDTOToCategory(CreateCategoryDTO createCategoryDto);
        Category MapUpdateCategorysDTOToCategory(UpdateCategoryDTO updateCategoryDto);
    }
}