using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.DAL
{
    public class RazaDAL
    {
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
                        raza.IdRaza = pRaza.IdRaza;
                        raza.Nombre = pRaza.Nombre;



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
        public static async Task<int> EliminarAsync(int pRaza)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var raza = await dbContexto.Raza
                        .FirstOrDefaultAsync(r => r.IdRaza == pRaza);

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
        public static async Task<Raza> ObtenerPorIdAsync(int pRaza)
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.Raza
                        .FirstOrDefaultAsync(r => r.IdRaza == pRaza);
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
}
