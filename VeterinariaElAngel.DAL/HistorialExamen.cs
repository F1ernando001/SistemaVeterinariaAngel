using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

public static class HistorialExamenDAL
{
    // 🔹 Guardar
    public static async Task<int> GuardarAsync(HistorialExamen pHistorialExamen)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                dbContexto.HistorialExamen.Add(pHistorialExamen);
                result = await dbContexto.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            result = 0;
            throw new Exception(ex.Message);
        }
        return result;
    }

    // 🔹 Modificar
    public static async Task<int> ModificarAsync(HistorialExamen pHistorialExamen)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var examen = await dbContexto.HistorialExamen
                    .FirstOrDefaultAsync(e => e.IdHistorialExamen == pHistorialExamen.IdHistorialExamen);

                if (examen != null)
                {
                    examen.IdExpediente = pHistorialExamen.IdExpediente;
                    examen.Fecha = pHistorialExamen.Fecha;
                    examen.Descripcion = pHistorialExamen.Descripcion;
                    examen.Resultado = pHistorialExamen.Resultado;
                    examen.Status = pHistorialExamen.Status;

                    dbContexto.HistorialExamen.Update(examen);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El historial de examen no existe");
                }
            }
        }
        catch (Exception ex)
        {
            result = 0;
            throw new Exception(ex.Message);
        }
        return result;
    }

    // 🔹 Eliminar
    public static async Task<int> EliminarAsync(int idHistorialExamen)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var examen = await dbContexto.HistorialExamen
                    .FirstOrDefaultAsync(e => e.IdHistorialExamen == idHistorialExamen);

                if (examen != null)
                {
                    dbContexto.HistorialExamen.Remove(examen);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El registro no existe");
                }
            }
        }
        catch (Exception ex)
        {
            result = 0;
            throw new Exception(ex.Message);
        }
        return result;
    }

    // 🔹 Obtener por ID
    public static async Task<HistorialExamen> ObtenerPorIdAsync(int idHistorialExamen)
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.HistorialExamen
                    .FirstOrDefaultAsync(e => e.IdHistorialExamen == idHistorialExamen);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // 🔹 Listar todos
    public static async Task<List<HistorialExamen>> ObtenerTodosAsync()
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.HistorialExamen.ToListAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
