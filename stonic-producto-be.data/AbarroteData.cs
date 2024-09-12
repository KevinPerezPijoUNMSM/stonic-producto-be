using Npgsql;
using stonic_producto_be.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace stonic_producto_be.data
{
    public class AbarroteData
    {
        public ReturnValue Registrar(Producto item)
        {
            string jsonData = JsonConvert.SerializeObject(item);

            ReturnValue oReturn = new ReturnValue();
            try
            {
                using (var cnn = new NpgsqlConnection(HelpData.ConnectionString()))
                {
                    using (var cmd = new NpgsqlCommand("pos_man_abarrote_ins", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar el parámetro de entrada con el JSON serializado
                        cmd.Parameters.AddWithValue("p_datos", NpgsqlTypes.NpgsqlDbType.Jsonb, jsonData);

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
