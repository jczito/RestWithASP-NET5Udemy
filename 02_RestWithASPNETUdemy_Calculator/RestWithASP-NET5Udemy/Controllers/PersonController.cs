using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Services;
using System.Numerics;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService; 
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }        
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }


        //Calculadora 

        //[HttpGet("Subtraction/{firstNumber}/{secondNumber}")]
        //public IActionResult Subtraction(string firstNumber, string secondNumber)
        //{
        //    // sum/2/4

        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("Invalid Input");
        //}
        //[HttpGet("Multiplication/{firstNumber}/{secondNumber}")]
        //public IActionResult Multiplication(string firstNumber, string secondNumber)
        //{
        //    // sum/2/4

        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("Division/{firstNumber}/{secondNumber}")]
        //public IActionResult Division(string firstNumber, string secondNumber)
        //{
        //    // sum/2/4

        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("mean/{firstNumber}/{secondNumber}")]
        //public IActionResult Mean(string firstNumber, string secondNumber)
        //{
        //    // sum/2/4

        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) /2;
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("Invalid Input");
        //}

        //[HttpGet("sum/{firstNumber}/{secondNumber}")]
        //public IActionResult sum(string firstNumber, string secondNumber)
        //{
        //    // sum/2/4

        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        //        return Ok(sum.ToString());
        //    }
        //    return BadRequest("Invalid Input");
        //}
        //[HttpGet("aquareroot/{firstNumber}")]
        //public IActionResult SquareRoot(string firstNumber)
        //{
        //    // sum/2/4

        //    if (IsNumeric(firstNumber))
        //    {
        //        var squareroot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
        //        return Ok(squareroot.ToString());
        //    }
        //    return BadRequest("Invalid Input");
        //}
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
