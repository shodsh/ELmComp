using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using BooksInquiryApi.Models;

namespace BooksInquiryApi.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //public async Task<IEnumerable<Book>> GetBooks(int pageNumber, int pageSize, string searchTerm)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        await connection.OpenAsync();
        //        var offset = (pageNumber - 1) * pageSize;

        //        var query = @"
        //                                SELECT * FROM Book 
        //                                WHERE BookInfo LIKE @SearchTerm 
        //                                ORDER BY BookId 
        //                                OFFSET @Offset ROWS 
        //                                FETCH NEXT @PageSize ROWS ONLY";

        //        var parameters = new
        //        {
        //            SearchTerm = $"%{searchTerm}%",
        //            Offset = offset,
        //            PageSize = pageSize
        //        };

        //        return await connection.QueryAsync<Book>(query, parameters);
        //    }
        //}

        public async Task<IEnumerable<Book>> GetBooks(int pageNumber, int pageSize, string searchTerm)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var offset = (pageNumber - 1) * pageSize;

                var query = @"
SELECT * FROM Book 
WHERE CONTAINS(BookInfo, @SearchTerm)
ORDER BY BookId 
OFFSET @Offset ROWS 
FETCH NEXT @PageSize ROWS ONLY";

                var parameters = new
                {
                    SearchTerm = searchTerm,
                    Offset = offset,
                    PageSize = pageSize
                };

                return await connection.QueryAsync<Book>(query, parameters);
            }
        }

    }
}
