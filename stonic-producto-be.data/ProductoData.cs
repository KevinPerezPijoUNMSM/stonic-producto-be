using Npgsql;
using stonic_producto_be.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stonic_producto_be.data
{
    public class ProductoData
    {
        public ReturnValue Registrar(Producto item)
        {
            ReturnValue oReturn = new ReturnValue();
            try
            {
                using (var cnn = new NpgsqlConnection(HelpData.ConnectionString()))
                {
                    using (var cmd = new NpgsqlCommand("gen_man_producto_ins", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros de entrada
                        cmd.Parameters.AddWithValue("p_nombre", item.Nombre);
                        cmd.Parameters.AddWithValue("p_codigo", item.Codigo);
                        cmd.Parameters.AddWithValue("p_idproductora", item.IdProductora);
                        cmd.Parameters.AddWithValue("p_contenido", item.Contenido);
                        cmd.Parameters.AddWithValue("p_idmedida", item.IdMedida);
                        cmd.Parameters.AddWithValue("p_urlimagen", item.UrlImagen);
                        cmd.Parameters.AddWithValue("p_flagrevendible", item.flagRevendible);

                        // Agregar parámetros de salida
                        var pMessage = new NpgsqlParameter("p_message", NpgsqlTypes.NpgsqlDbType.Varchar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(pMessage);

                        var pCode = new NpgsqlParameter("p_code", NpgsqlTypes.NpgsqlDbType.Integer)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(pCode);

                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        // Obtener los valores de los parámetros de salida
                        oReturn.Message = pMessage.Value.ToString();
                        oReturn.Success = Convert.ToInt32(pCode.Value) == 1;

                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn.Success = false;
                oReturn.Message = $"Error: {ex.Message}";
            }

            return oReturn;
        }
    }
}
