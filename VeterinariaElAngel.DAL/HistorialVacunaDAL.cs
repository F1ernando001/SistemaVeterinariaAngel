using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.DAL
{
    public class HistorialVacunaDAL
    {
        public static async Task<int> GuardarAsync(HistorialVacuna pHistorialVacuna)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.HistorialVacuna.Add(pHistorialVacuna);
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
        public static async Task<int> ModificarAsync(HistorialVacuna pHistorialVacuna)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var vacuna = await dbContexto.HistorialVacuna
                        .FirstOrDefaultAsync(v => v.IdHistorialVacuna == pHistorialVacuna.IdHistorialVacuna);

                    if (vacuna != null)
                    {
                        vacuna.IdHistorialVacuna = pHistorialVacuna.IdHistorialVacuna;
                        vacuna.NombreVacuna = pHistorialVacuna.NombreVacuna;
                        vacuna.FechaVacuna = pHistorialVacuna.FechaVacuna;


                        dbContexto.HistorialVacuna.Update(vacuna);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El historial de vacuna no existe");
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
        public static async Task<int> EliminarAsync(int idHistorialVacuna)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var vacuna = await dbContexto.HistorialVacuna
                        .FirstOrDefaultAsync(v => v.IdHistorialVacuna == idHistorialVacuna);

                    if (vacuna != null)
                    {
                        dbContexto.HistorialVacuna.Remove(vacuna);
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
        public static async Task<HistorialVacuna> ObtenerPorIdAsync(int idHistorialVacuna)
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.HistorialVacuna
                        .FirstOrDefaultAsync(v => v.IdHistorialVacuna == idHistorialVacuna);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 🔹 Listar todos
        public static async Task<List<HistorialVacuna>> ObtenerTodosAsync()
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.HistorialVacuna.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
