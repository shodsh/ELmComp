using BooksInquiryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksInquiryApi.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100, [FromQuery] string searchTerm = "")
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Invalid page number or page size.");
            }

            var books = await _bookService.GetBooks(pageNumber, pageSize, searchTerm);
            return Ok(books);
        }


        // Add more actions as needed
    }
}