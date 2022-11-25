using LabManagementSystem.Data.Models;

namespace LabManagementSystem.Data.Providers
{
    public interface ILabMgmtSystemProvider
    {
        IEnumerable<Author> GetAuthors();
        void SaveAuthor(Author author);
        bool DeleteAuthor(int id);
        bool UpdateAuthor(Author author);
        IEnumerable<Category> GetCategories();
        void SaveCategory(Category category);
        bool DeleteCategory(int id);
        bool UpdateCategory(Category category);
        IEnumerable<Lab> GetLabs();
        void SaveLab(Lab lab);
        bool DeleteLab(int id);
        bool UpdateLab(Lab lab);
    }
}
