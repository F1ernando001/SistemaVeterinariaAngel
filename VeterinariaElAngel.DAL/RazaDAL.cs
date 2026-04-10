using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.EN;

public static class RazaDAL
{
    // 🔹 Guardar
    public static async Task<int> GuardarAsync(Raza pRaza)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Raza.Add(pRaza);
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
    public static async Task<int> ModificarAsync(Raza pRaza)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var raza = await dbContexto.Raza
                    .FirstOrDefaultAsync(r => r.IdRaza == pRaza.IdRaza);

                if (raza != null)
                {
                    raza.Nombre = pRaza.Nombre;
                    raza.IdEspecie = pRaza.IdEspecie;
                    raza.Descripcion = pRaza.Descripcion;
                    raza.Estado = pRaza.Estado;

                    dbContexto.Raza.Update(raza);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("La raza no existe");
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
    public static async Task<int> EliminarAsync(int idRaza)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var raza = await dbContexto.Raza
                    .FirstOrDefaultAsync(r => r.IdRaza == idRaza);

                if (raza != null)
                {
                    dbContexto.Raza.Remove(raza);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("La raza no existe");
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
    public static async Task<Raza> ObtenerPorIdAsync(int idRaza)
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Raza
                    .FirstOrDefaultAsync(r => r.IdRaza == idRaza);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // 🔹 Listar todos
    public static async Task<List<Raza>> ObtenerTodosAsync()
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Raza.ToListAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}