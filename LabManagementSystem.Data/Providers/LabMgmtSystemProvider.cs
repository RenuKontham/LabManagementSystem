using LabManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LabManagementSystem.Data.Providers
{
    public class LabMgmtSystemProvider : ILabMgmtSystemProvider
    {
        private readonly LabMgmtDbContext _labMgmtDbContext;

        public LabMgmtSystemProvider(LabMgmtDbContext labMgmtDbContext)
        {
            _labMgmtDbContext = labMgmtDbContext;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _labMgmtDbContext.Author
                .Select(s => s);
        }

        public void SaveAuthor(Author author)
        {
            _labMgmtDbContext.Author.Add(author);
            _labMgmtDbContext.SaveChanges();
        }

        public bool DeleteAuthor(int id)
        {
            bool deleted = false;
            var authorToDelete = _labMgmtDbContext.Author.FirstOrDefault(author => author.Id == id);
            if (authorToDelete != null)
            {
                _labMgmtDbContext.Author.Remove(authorToDelete);
                _labMgmtDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        public bool UpdateAuthor(Author author)
        {
            bool updated = false;
            var authorToUpdate = _labMgmtDbContext.Author.FirstOrDefault(s => s.Id == author.Id);
            if (authorToUpdate != null)
            {
                authorToUpdate.FirstName = author.FirstName;
                authorToUpdate.LastName = author.LastName;
                _labMgmtDbContext.Author.Update(authorToUpdate);
                _labMgmtDbContext.SaveChanges();
                updated = true;
            }
            return updated;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _labMgmtDbContext.Category
                .Select(s => s);
        }

        public void SaveCategory(Category category)
        {
            _labMgmtDbContext.Category.Add(category);
            _labMgmtDbContext.SaveChanges();
        }

        public bool DeleteCategory(int id)
        {
            bool deleted = false;
            var categoryToDelete = _labMgmtDbContext.Category.FirstOrDefault(category => category.Id == id);
            if (categoryToDelete != null)
            {
                _labMgmtDbContext.Category.Remove(categoryToDelete);
                _labMgmtDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        public bool UpdateCategory(Category category)
        {
            bool updated = false;
            var categoryToUpdate = _labMgmtDbContext.Category.FirstOrDefault(s => s.Id == category.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                _labMgmtDbContext.Category.Update(categoryToUpdate);
                _labMgmtDbContext.SaveChanges();
                updated = true;
            }
            return updated;
        }

        public IEnumerable<Lab> GetLabs()
        {
            return _labMgmtDbContext.Lab
                .Include(s => s.Author)
                .Include(s => s.Category)
                .Select(s => s);
        }

        public void SaveLab(Lab lab)
        {
            _labMgmtDbContext.Lab.Add(lab);
            _labMgmtDbContext.SaveChanges();
        }

        public bool DeleteLab(int id)
        {
            bool deleted = false;
            var labToDelete = _labMgmtDbContext.Lab.FirstOrDefault(lab => lab.Id == id);
            if (labToDelete != null)
            {
                _labMgmtDbContext.Lab.Remove(labToDelete);
                _labMgmtDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        public bool UpdateLab(Lab lab)
        {
            bool updated = false;
            var labToUpdate = _labMgmtDbContext.Lab.FirstOrDefault(s => s.Id == lab.Id);
            if (labToUpdate != null)
            {
                labToUpdate.Name = lab.Name;
                labToUpdate.Description = lab.Description;
                labToUpdate.AuthorId = lab.AuthorId;
                labToUpdate.CategoryId = lab.CategoryId;
                _labMgmtDbContext.Lab.Update(labToUpdate);
                _labMgmtDbContext.SaveChanges();
                updated = true;
            }
            return updated;
        }
    }
}
