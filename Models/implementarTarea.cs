
namespace UtilizarTarea;
public class Implementar
{
    private AccesoDatso accesoDatso;

    public Implementar( AccesoDatso accesoDatso)
    {
        this.accesoDatso = accesoDatso;
    }

    public Tarea CrearTarea(Tarea tarea)
    {
        var tareas = accesoDatso.Obtener();
        tareas.Add(tarea);
        tarea.Id = tareas.Count;
        accesoDatso.Guardar(tareas);
        return tarea;
    }

    public Tarea ObtenerTareaID(int id)
    {
        var tareas = accesoDatso.Obtener();
        var tarea = tareas.FirstOrDefault(t => t.Id == id );
        return tarea;
    }

    public List<Tarea> ActualizarTarea(Tarea tareanueva, int id)
    {
        var tareas = accesoDatso.Obtener();
        var tarea = tareas.FirstOrDefault(t=> t.Id == id);
        if(tarea != null)
        {
            var idnuevo = tarea.Id;
            tareas.Remove(tarea);
            tareas.Add(tareanueva);
            tareanueva.Id = idnuevo;
            accesoDatso.Guardar(tareas);
        }
        return tareas;
    }

    public List<Tarea> EliminarTarea(int id)
    {
        var tareas = accesoDatso.Obtener();
        var tarea = tareas.FirstOrDefault(t=> t.Id == id);
        if(tarea != null)
        {
            tareas.Remove(tarea);
            accesoDatso.Guardar(tareas);
        }
        return tareas;
    }

    public List<Tarea> ListarTareas()
    {
        return accesoDatso.Obtener();
    }

    public List<Tarea> ListaTareasCompletadas()
    {
        var tareas = accesoDatso.Obtener();
        var tareasCompletadas = tareas.FindAll(t=> t.Estado == Estado.Completada);
        return tareasCompletadas;
    }
}