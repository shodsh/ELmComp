using BooksInquiryApi.Models;
using System.Collections.Generic;

namespace BooksInquiryApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks(int pageNumber, int pageSize, string searchTerm);
        // Add other methods as needed
    }
}
