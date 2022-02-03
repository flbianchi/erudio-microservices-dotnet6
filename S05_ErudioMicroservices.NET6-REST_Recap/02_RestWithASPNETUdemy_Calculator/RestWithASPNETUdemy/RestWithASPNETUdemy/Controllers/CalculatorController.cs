using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        #region calculator
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNUmeric(firstNumber) && IsNUmeric(secondNumber))
            {
                var sum = convertToDecimal(firstNumber) + convertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtraction(string firstNumber, string secondNumber)
        {
            if (IsNUmeric(firstNumber) && IsNUmeric(secondNumber))
            {
                var subtraction = convertToDecimal(firstNumber) - convertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{multiplying}/{multiplier}")]
        public IActionResult GetMultiplication(string multiplying, string multiplier)
        {
            if (IsNUmeric(multiplying) && IsNUmeric(multiplier))
            {
                var multiplication = convertToDecimal(multiplying) * convertToDecimal(multiplier);
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("division/{dividend}/{divider}")]
        public IActionResult GetDivision(string dividend, string divider)
        {
            if (IsNUmeric(dividend) && IsNUmeric(divider) && !divider.Equals("0"))
            {
                var division = convertToDecimal(dividend) / convertToDecimal(divider);
                return Ok(division.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult GetAverage(string firstNumber, string secondNumber)
        {
            if (IsNUmeric(firstNumber) && IsNUmeric(secondNumber))
            {
                var average = (convertToDecimal(firstNumber) + convertToDecimal(secondNumber)) / 2;
                return Ok(average.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult GetSquareRoot(string number)
        {
            if (IsNUmeric(number))
            {
                var squareroot = Math.Sqrt(convertToDouble(number));
                return Ok(squareroot.ToString());
            }
            return BadRequest("Invalid input");
        }
        private decimal convertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private Double convertToDouble(string strNumber)
        {
            double doubleValue;
            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }

        private bool IsNUmeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
        #endregion calculator
        #region Controler and Model
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum1(string firstNumber, string secondNumber)
        {
            
            return BadRequest("Invalid input");
        }
        #endregion Controler and Model
    }
}