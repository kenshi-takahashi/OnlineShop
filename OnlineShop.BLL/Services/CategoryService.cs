using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL.DTO.RequestDTO;
using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.BLL.Interfaces;
using OnlineShop.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class CategoriesService : ICategoryService
    {
        private readonly OnlineShopDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesService(OnlineShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadCategoryDTO> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            return _mapper.Map<ReadCategoryDTO>(category);
        }

        public async Task<IEnumerable<ReadCategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ReadCategoryDTO>>(categories);
        }

        public async Task<int> CreateCategoryAsync(CreateCategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);

            _context.Categories.Add(categoryEntity);
            await _context.SaveChangesAsync();

            return categoryEntity.Id;
        }


        public async Task UpdateCategoryAsync(UpdateCategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);

            _context.Categories.Update(categoryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
