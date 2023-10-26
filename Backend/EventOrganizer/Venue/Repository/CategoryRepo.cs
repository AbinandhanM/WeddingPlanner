using Microsoft.EntityFrameworkCore;
using Venue.Context;
using Venue.Interfaces.Repository;
using Venue.Models;

namespace Venue.Repository
{
    public class CategoryRepo : IRepo<int, Category>
    {
        private readonly VenueContext _context;

        public CategoryRepo(VenueContext context)
        {
            _context = context;
        }

        public async Task<Category?> Add(Category item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Categories == null)
                throw new Exception("The Categories collection in the database context is null. Make sure it's properly configured.");

            try
            {
                await _context.Categories.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add Category", ex);
            }
        }

        public async Task<Category?> Delete(Category item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Categories == null)
                throw new Exception("The Categories collection in the database context is null. Make sure it's properly configured.");

            var existingCategory = await _context.Categories.FindAsync(item.CategoryID) ?? throw new InvalidOperationException($"Category with ID {item.CategoryID} not found.");
            try
            {
                _context.Categories.Remove(existingCategory);
                await _context.SaveChangesAsync();
                return existingCategory;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Category", ex);
            }
        }

        public async Task<Category?> Get(int key)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Categories == null)
                throw new Exception("The Categories collection in the database context is null. Make sure it's properly configured.");

            try
            {
                var category = await _context.Categories.FindAsync(key);
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Category", ex);
            }
        }

        public async Task<List<Category>?> GetAll()
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Categories == null)
                throw new Exception("The Categories collection in the database context is null. Make sure it's properly configured.");

            try
            {
                var categories = await _context.Categories.ToListAsync();
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all Categories", ex);
            }
        }

        public async Task<Category?> Update(Category item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Categories == null)
                throw new Exception("The Categories collection in the database context is null. Make sure it's properly configured.");

            var existingCategory = await _context.Categories.FindAsync(item.CategoryID) ?? throw new InvalidOperationException($"Category with ID {item.CategoryID} not found.");
            try
            {
                _context.Entry(existingCategory).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update Category", ex);
            }
        }
    }

}
