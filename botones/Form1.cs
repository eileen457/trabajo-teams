using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace botones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            String codigo= txtCodigo.Text;
            String nombre= txtNombre.Text;
            String descripcion= txtDescripcion.Text;
            double precio= double.Parse(txtPreciop.Text);
            int existencia=int.Parse(txtExistencia.Text);

            string sql = "INSERT INTO articulos(codigo, nombre, descripcion, precio, existencias)" +
                "VALUES ('" + codigo + "','" + nombre + "','" + descripcion + "','" + precio + "','" + existencia + "')";

            MySqlConnection con = Conexion.conexion();
            con.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sql, con);
                command.ExecuteNonQuery();
                MessageBox.Show("registro hecho");
            }catch(MySqlException ex)
            {
                MessageBox.Show("error"+ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            MySqlDataReader reader = null;

            String sql = "SELECT Id, codigo, nombre, descripcion, precio, existencias FROM articulos WHERE codigo LIKE '" + codigo + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();

            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtId.Text = reader.GetInt32(0).ToString();
                        txtCodigo.Text = reader.GetString(1);
                        txtNombre.Text = reader.GetString(2);
                        txtDescripcion.Text = reader.GetString(3);
                        txtPreciop.Text = reader.GetDouble(4).ToString(); 
                        txtExistencia.Text = reader.GetInt32(5).ToString();

                    }
                }
                else
                {
                    MessageBox.Show(" No se encontraron registros con ese codigo");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            String id = txtId.Text;
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion=txtDescripcion.Text;
            double precio= double.Parse(txtPreciop.Text);
            int existencia=int.Parse(txtExistencia.Text);

            string sql = "UPDATE articulos SET codigo='" + codigo + "', nombre='" + nombre + "' , descripcion='" + descripcion + "', precio='" + precio + "', existencias='" + existencia + "' WHERE id= '" + id + "'";


            //instancia a la clase de conexion
            MySqlConnection con = Conexion.conexion();
            con.Open();

            try
            {
                //comprobar que se guarda en la BD
                MySqlCommand command = new MySqlCommand(sql, con);
                command.ExecuteNonQuery();
                MessageBox.Show("Regitro Modificado");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);

            }
            finally
            {
                con.Close();
            }
        }
    }
}
