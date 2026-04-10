using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.DAL
{
    public static class CitaDAL
    {
        // 🔹 Guardar
        public static async Task<int> GuardarAsync(Cita pCita)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new ContextoDB())
                {
                    dbContexto.Cita.Add(pCita);
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
        public static async Task<int> ModificarAsync(Cita pCita)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new ContextoDB())
                {
                    var cita = await dbContexto.Cita
                        .FirstOrDefaultAsync(c => c.IdCita == pCita.IdCita);

                    if (cita != null)
                    {
                        cita.IdMascota = pCita.IdMascota;
                        cita.Fecha = pCita.Fecha;
                        cita.Descripcion = pCita.Descripcion;
                        cita.Estado = pCita.Estado;

                        dbContexto.Cita.Update(cita);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("La cita no existe");
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
        public static async Task<int> EliminarAsync(int idCita)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new ContextoDB())
                {
                    var cita = await dbContexto.Cita
                        .FirstOrDefaultAsync(c => c.IdCita == idCita);

                    if (cita != null)
                    {
                        dbContexto.Cita.Remove(cita);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("La cita no existe");
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
        public static async Task<Cita> ObtenerPorIdAsync(int idCita)
        {
            try
            {
                using (var dbContexto = new ContextoDB())
                {
                    return await dbContexto.Cita
                        .FirstOrDefaultAsync(c => c.IdCita == idCita);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 🔹 Listar todos
        public static async Task<List<Cita>> ObtenerTodosAsync()
        {
            try
            {
                using (var dbContexto = new ContextoDB())
                {
                    return await dbContexto.Cita.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
