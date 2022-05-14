using System.Data.SqlClient;
using System.Data;

namespace connectionDb
{
    class connection
    {
        // Change data source for your local server
        string provider = @"Data Source=DESKTOP-1B3K7PC;" +
                "Initial Catalog=TIENDA;" +
                "Integrated Security=True";

        public SqlConnection connect = new SqlConnection();

        public connection()
        {
            connect.ConnectionString = provider;
        }


    }


    public class classClienterData
    {

        public DataTable getClientes()
        {
            connection database = new connection();
            database.connect.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DOCUMENTO, NOMBRESYAPELLIDOS AS NOMBRE_Y_APELLIDO, TELEFONO, EMAIL, nombres AS CUIDAD, Estado FROM CLIENTE INNER JOIN CUIDADES nombres ON CUIDAD = id", database.connect);
            DataTable data = new DataTable();

            adapter.Fill(data);
            return data;

        }

        public void  getCuidades(ComboBox CB)
        {
            connection database = new connection();
            database.connect.Open();

            SqlCommand data = new SqlCommand("SELECT nombres FROM CUIDADES", database.connect);
            SqlDataReader result = data.ExecuteReader();

            while (result.Read() == true)
            {
             CB.Items.Add(result[0]);
            }

        }


        public DataTable getClientesAC(string value, string value2)
        {
            connection database = new connection();
            database.connect.Open();

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT DOCUMENTO, NOMBRESYAPELLIDOS AS NOMBRE_Y_APELLIDO,TELEFONO, EMAIL,nombres AS CUIDAD, Estado FROM CLIENTE INNER JOIN CUIDADES nombres ON CUIDAD = id WHERE nombres LIKE '%{value}%' AND Estado LIKE '%{value2}%';", database.connect);
            DataTable data = new DataTable();

            adapter.Fill(data);
            return data;


        }

        

        public DataTable getClientesEstadoActivo()
        {
            connection database = new connection();
            database.connect.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DOCUMENTO, NOMBRESYAPELLIDOS AS NOMBRE_Y_APELLIDO,TELEFONO, EMAIL,nombres AS CUIDAD, Estado FROM CLIENTE INNER JOIN CUIDADES nombres ON CUIDAD = id WHERE Estado LIKE 'activo';", database.connect);
            DataTable data = new DataTable();

            adapter.Fill(data);
            return data;

        }

        public DataTable getClientesDesactivo()
        {
            connection database = new connection();
            database.connect.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DOCUMENTO, NOMBRESYAPELLIDOS AS NOMBRE_Y_APELLIDO,TELEFONO, EMAIL,nombres AS CUIDAD, Estado FROM CLIENTE INNER JOIN CUIDADES nombres ON CUIDAD = id WHERE Estado LIKE 'desactivo';", database.connect);
            DataTable data = new DataTable();

            adapter.Fill(data);
            return data;

        }



        public DataTable getClientesCuiades(string value)
        {
            connection database = new connection();
            database.connect.Open();

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT DOCUMENTO, NOMBRESYAPELLIDOS AS NOMBRE_Y_APELLIDO,TELEFONO, EMAIL,nombres AS CUIDAD, Estado FROM CLIENTE INNER JOIN CUIDADES nombres ON CUIDAD = id WHERE nombres LIKE '%{value}%';", database.connect);
            DataTable data = new DataTable();

            adapter.Fill(data);
            return data;


        }

    }





}