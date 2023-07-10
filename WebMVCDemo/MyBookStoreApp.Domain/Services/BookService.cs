using MyBookStoreApp.MyBookStoreApp.Domain.Interfaces;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookStoreApp.MyBookStoreApp.Domain.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task CreateBook(Book book)
        {
            await _bookRepository.CreateBook(book);
        }

        public async Task UpdateBook(Book book)
        {
            await _bookRepository.UpdateBook(book);
        }

        public async Task DeleteBook(Guid id)
        {
            await _bookRepository.DeleteBook(id);
        }
    }
}
