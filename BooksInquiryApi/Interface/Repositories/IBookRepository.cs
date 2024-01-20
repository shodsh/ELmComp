using BooksInquiryApi.Models;
using System.Collections.Generic;

namespace BooksInquiryApi.Data
{
    public interface IBookRepository
    {        
        Task<IEnumerable<Book>> GetBooks(int pageNumber, int pageSize, string searchTerm);
        // Add other methods as needed (e.g., GetBookById, AddBook, UpdateBook, DeleteBook)
    }
}
