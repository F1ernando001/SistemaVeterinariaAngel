using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.DAL
{
    public class StatusDAL
    {
        public static async Task<int> GuardarAsync(Status pStatus)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    dbContexto.Status.Add(pStatus);
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

        //  Modificar
        public static async Task<int> ModificarAsync(Status pStatus)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var status = await dbContexto.Status
                        .FirstOrDefaultAsync(s => s.IdEstado == pStatus.IdEstado);

                    if (status != null)
                    {
                        status.Estado = pStatus.Estado;


                        dbContexto.Status.Update(status);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El status no existe");
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

        // Eliminar
        public static async Task<int> EliminarAsync(int pStatus)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var status = await dbContexto.Status
                        .FirstOrDefaultAsync(s => s.IdEstado == pStatus);

                    if (status != null)
                    {
                        dbContexto.Status.Remove(status);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El status no existe");
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

        // Obtener por ID
        public static async Task<Status> ObtenerPorIdAsync(int idStatus)
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.Status
                        .FirstOrDefaultAsync(s => s.IdEstado == idStatus);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Listar todos
        public static async Task<List<Status>> ObtenerTodosAsync()
        {
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    return await dbContexto.Status.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
