using BooksInquiryApi.Data;
using BooksInquiryApi.Models;
using System.Collections.Generic;

namespace BooksInquiryApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooks(int pageNumber, int pageSize, string searchTerm)
        {
            // Use _bookRepository to retrieve books and apply any business logic
            return await _bookRepository.GetBooks(pageNumber, pageSize, searchTerm);
        }

        // Implement other methods as needed
    }
}
