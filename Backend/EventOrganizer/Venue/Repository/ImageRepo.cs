using Microsoft.EntityFrameworkCore;
using Venue.Context;
using Venue.Interfaces.Repository;
using Venue.Models;

namespace Venue.Repository
{
    public class ImageRepo : IRepo<int, Image>
    {
        private readonly VenueContext _context;

        public ImageRepo(VenueContext context)
        {
            _context = context;
        }
        public async Task<Image?> Add(Image item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Images == null)
            {
                throw new Exception("Images collection is null");
            }

            try
            {
                await _context.Images.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add Image", ex);
            }
        }

        public async Task<Image?> Delete(Image item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Images == null)
            {
                throw new Exception("Images collection is null");
            }

            var existingImage = await _context.Images.FindAsync(item.ImageID) ?? throw new InvalidOperationException($"Image with ID {item.ImageID} not found.");
            try
            {
                _context.Images.Remove(existingImage);
                await _context.SaveChangesAsync();
                return existingImage;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Image", ex);
            }
        }

        public async Task<Image?> Get(int key)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Images == null)
            {
                throw new Exception("Images collection is null");
            }

            try
            {
                var image = await _context.Images.FindAsync(key);
                return image;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Image", ex);
            }
        }

        public async Task<List<Image>?> GetAll()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Images == null)
            {
                throw new Exception("Images collection is null");
            }

            try
            {
                var images = await _context.Images.ToListAsync();
                return images;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all Images", ex);
            }
        }

        public async Task<Image?> Update(Image item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item is null.");

            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Images == null)
            {
                throw new Exception("Images collection is null");
            }

            var existingImage = await _context.Images.FindAsync(item.ImageID) ?? throw new InvalidOperationException($"Image with ID {item.ImageID} not found.");
            try
            {
                _context.Entry(existingImage).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update Image", ex);
            }
        }
    }
}
