using Microsoft.AspNetCore.Mvc;

namespace RestWithASP_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                                            strNumber,
                                            System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                                            out number
                                           );
            return isNumber; 

        }

        private decimal ConvertToDecimal(string strNunber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNunber, out decimalValue))
                return decimalValue; 
            return 0; // Caso de falha
        }

    }
}