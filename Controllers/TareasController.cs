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

    [HttpPost("Crear Tarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        Tarea tareanueva = implementar.CrearTarea(tarea);
        if(tareanueva != null)
        {
            return Ok(tareanueva);
        }
        return NotFound("False");
    }
    /* Obtener una tarea por id.
    ● Actualizar una tarea.
    ● Eliminar una tarea.
    ● Listar todas las tareas.
    ● Listar todas las tareas completadas.*/
    [HttpGet]
    [Route("Mostrar Tarea ID")]
    public ActionResult<Tarea> MostrarTareaId(int id)
    {
        Tarea tarea = implementar.ObtenerTareaID(id);
        if(tarea != null)
        {
            return Ok(tarea);
        }
        return NotFound("False");
    }

    [HttpPut("Actualizar Tarea")]
    public ActionResult<List<Tarea>> ActualizarTarea(Tarea tarea, int id)
    {
        var tareas = implementar.ActualizarTarea(tarea,id);
        return Ok(tareas);
    }

    [HttpDelete("Eliminar Tarea")]
    public ActionResult<List<Tarea>> EliminarTarea(int id)
    {
        var tareas = implementar.EliminarTarea(id);
        return Ok(tareas);
    }
    [HttpGet]
    [Route("Listar Tareas")]
    public ActionResult<List<Tarea>> ListarTareas()
    {
        var tareas = implementar.ListarTareas();
        return Ok(tareas);
    }

    [HttpGet]
    [Route("Listar Tareas Completadas")]
    public ActionResult<List<Tarea>> ListarTareasCompletadas()
    {
        var tareas = implementar.ListaTareasCompletadas();
        return Ok(tareas);
    }

}
