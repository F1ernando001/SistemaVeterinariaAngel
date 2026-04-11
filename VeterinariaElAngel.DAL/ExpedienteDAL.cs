using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.DAL
{
    public class ExpedienteDAL
    {
        public static async Task<int> GuardarAsync(Expediente pExpediente)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Expediente.Add(pExpediente);
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
        public static async Task<int> ModificarAsync(Expediente pExpediente)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var expediente = await dbContexto.Expediente
                        .FirstOrDefaultAsync(e => e.IdExpediente == pExpediente.IdExpediente);

                    if (expediente != null)
                    {
                        expediente.IdMascota = pExpediente.IdMascota;
                        expediente.FechaNacimiento = pExpediente.FechaNacimiento;
                        expediente.NumeroExpediente = pExpediente.NumeroExpediente;
                        expediente.Peso = pExpediente.Peso;

                        dbContexto.Expediente.Update(expediente);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El expediente no existe");
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
        public static async Task<int> EliminarAsync(int idExpediente)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var expediente = await dbContexto.Expediente
                        .FirstOrDefaultAsync(e => e.IdExpediente == idExpediente);

                    if (expediente != null)
                    {
                        dbContexto.Expediente.Remove(expediente);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El expediente no existe");
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
        public static async Task<Expediente> ObtenerPorIdAsync(int idExpediente)
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.Expediente
                        .FirstOrDefaultAsync(e => e.IdExpediente == idExpediente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 🔹 Listar todos
        public static async Task<List<Expediente>> ObtenerTodosAsync()
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.Expediente.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
