
using ExamenII_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ExamenII_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public HomeController(
            ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        //public async Task<ActionResult<ResponseDto<List<TaskDto>>>> GetAll(string searchTerm = "")
        //{
          //  var taskResponse = await _taskService.ge
        //}

        [HttpPost]
        public IActionResult CalcularIMC([FromBody] DatosPaciente datos)
        {
            if (datos == null)
            {
                return BadRequest("Datos de paciente no proporcionados.");
            }
            double imc = CalcularIMC(datos.Peso, datos.Altura);
            string categoriaIMC = DeterminarCategoriaIMC(imc);
            string mensaje = $"Hola {datos.Nombre}, tu IMC es {imc}, lo que corresponde a: {categoriaIMC}";

            return Ok(mensaje);
        }
        private double CalcularIMC(double peso, double altura)
        {
            double alturaMetros = altura / 100;
            return peso / (alturaMetros * alturaMetros);
        }

        private string DeterminarCategoriaIMC(double imc)
        {
            if (imc < 18.5)
            {
                return "Bajo peso";
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                return "Peso normal";
            }
            else if (imc >= 25.0 && imc <= 29.9)
            {
                return "Sobrepeso";
            }
            else if (imc >= 30.0 && imc <= 34.9)
            {
                return "Obesidad grado I";
            }
            else if (imc >= 35.0 && imc <= 39.9)
            {
                return "Obesidad grado II";
            }
            else
            {
                return "Obesidad grado III";
            }
        }
        public class DatosPaciente
        {
            public string Nombre { get; set; }
            public string Genero { get; set; }
            public double Peso { get; set; }
            public double Altura { get; set; }
        }
    }
}
