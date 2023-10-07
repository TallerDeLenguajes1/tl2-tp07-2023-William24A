using System.Text.Json;

namespace UtilizarTarea;

public class AccesoDatso
{   
    private string ruta = "TareaJSON.json";
    public List<Tarea> Obtener()
    {
        var tareas = new List<Tarea>();

        if(File.Exists(ruta))
        {
            string objetosJson = File.ReadAllText(ruta);
            if(objetosJson != "")
            {
                tareas = JsonSerializer.Deserialize<List<Tarea>>(objetosJson);
            }
        }
        return tareas;
    }

    public void Guardar(List<Tarea> tareas)
    {
        string objetosJson = JsonSerializer.Serialize(tareas);
        File.WriteAllText(ruta, objetosJson);
    }
}