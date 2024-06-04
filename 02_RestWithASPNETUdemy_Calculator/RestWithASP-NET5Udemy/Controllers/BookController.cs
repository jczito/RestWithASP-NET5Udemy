using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET5Udemy.Business;
using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase 
    {
            
        private readonly ILogger<BookController> _logger;

        private IBooksBusiness _BookBusiness;

        public BookController(ILogger<BookController> logger, IBooksBusiness BookBusiness)
        {
            _logger = logger;
            _BookBusiness = BookBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_BookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Book = _BookBusiness.FindByID(id);
            if (Book == null) return NotFound();
            return Ok(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookVO Book)
        {
            if (Book == null) return BadRequest();
            return Ok(_BookBusiness.Create(Book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookVO Book)
        {
            if (Book == null) return BadRequest();
            return Ok(_BookBusiness.Update(Book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _BookBusiness.Delete(id);
            return NoContent();
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
