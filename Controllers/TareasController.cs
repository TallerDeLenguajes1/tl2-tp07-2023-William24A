using Microsoft.AspNetCore.Mvc;
using UtilizarTarea;

namespace tl2_tp07_2023_William24A.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private Implementar implementar;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        var accesoDatos = new AccesoDatso();
        implementar = new Implementar(accesoDatos);
    }
    
}
