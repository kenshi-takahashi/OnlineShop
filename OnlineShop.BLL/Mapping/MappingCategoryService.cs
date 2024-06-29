using AutoMapper;
using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.BLL.Interfaces;

namespace OnlineShop.BLL.Services
{
    public class MappingCategoryService : IMappingCategoryService
    {
        private readonly IMapper _mapper;

        public MappingCategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ReadCategoryDTO MapCategorysToReadCategoryDTO(Category category)
        {
            return _mapper.Map<ReadCategoryDTO>(category);
        }

        public Category MapCreateCategorysDTOToCategory(CreateCategoryDTO createCategoryDto)
        {
            return _mapper.Map<Category>(createCategoryDto);
        }

        public Category MapUpdateCategorysDTOToCategory(UpdateCategoryDTO updateCategoryDto)
        {
            return _mapper.Map<Category>(updateCategoryDto);
        }
    }
}