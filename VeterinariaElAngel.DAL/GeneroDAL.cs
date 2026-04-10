using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public static class GeneroDAL
{
    // 🔹 Guardar
    public static async Task<int> GuardarAsync(Genero pGenero)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Genero.Add(pGenero);
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
    public static async Task<int> ModificarAsync(Genero pGenero)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var genero = await dbContexto.Genero
                    .FirstOrDefaultAsync(g => g.IdGenero == pGenero.IdGenero);

                if (genero != null)
                {
                    genero.Nombre = pGenero.Nombre;
                    genero.Descripcion = pGenero.Descripcion;
                    genero.Estado = pGenero.Estado;

                    dbContexto.Genero.Update(genero);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El género no existe");
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
    public static async Task<int> EliminarAsync(int idGenero)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var genero = await dbContexto.Genero
                    .FirstOrDefaultAsync(g => g.IdGenero == idGenero);

                if (genero != null)
                {
                    dbContexto.Genero.Remove(genero);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El género no existe");
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
    public static async Task<Genero> ObtenerPorIdAsync(int idGenero)
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Genero
                    .FirstOrDefaultAsync(g => g.IdGenero == idGenero);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // 🔹 Listar todos
    public static async Task<List<Genero>> ObtenerTodosAsync()
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Genero.ToListAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}