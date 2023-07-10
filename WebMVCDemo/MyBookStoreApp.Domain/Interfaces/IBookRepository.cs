using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task CreateBook(Book author);
        Task DeleteBook(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task UpdateBook(Book book);
    }
}
