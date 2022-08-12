using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_cine
{
    class SQLControl
    {
        SqlConnection cnn;
        //SqlCommand cmd;
        //SqlDataReader dr;
        
        public SQLControl()
        {
            try
            {
                cnn = new SqlConnection("Data Source =.; Initial Catalog = Cine; Integrated Security = True");
               // cnn.Open();
                //MessageBox.Show("Conectado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conecto a la base de datos: "+ex.ToString());
            }
        }


       // private SqlConnection cnn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Cine;Integrated Security = true");
            //"Data Source=DAVID-LAPTOP \\SQLEXPRESS;Initial Catalog=PruebaDB; Integrated Security = true";
        
        public int Login(string usuario, string pass)
        {                     
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spLogin",cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Pass", pass);
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    return dr.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            finally
            {
                cnn.Close();
            }
            return -1;
        }
       
        public  DataTable mostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spMostrarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;
        }
          
        public string grabarUsuario(string Nombre, string Apellido, string Sexo, string DNI, 
            string Email, string Telefono, string Fecha_nac,string Direccion, string Username,
            string Contraseña, string Fecha_ingreso , string Estado , string Rol )

            {
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spInsertarUsuario", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Nombre",Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", Apellido));
                cmd.Parameters.Add(new SqlParameter("@Sexo", Sexo));
                cmd.Parameters.Add(new SqlParameter("@DNI", DNI));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                cmd.Parameters.Add(new SqlParameter("@Fecha_nac", Fecha_nac));
                cmd.Parameters.Add(new SqlParameter("@Direccion", Direccion));
                cmd.Parameters.Add(new SqlParameter("@Username", Username));
                cmd.Parameters.Add(new SqlParameter("@Contraseña", Contraseña));
                cmd.Parameters.Add(new SqlParameter("@Fecha_ingreso", Fecha_ingreso));
                cmd.Parameters.Add(new SqlParameter("@Estado", Estado));
                cmd.Parameters.Add(new SqlParameter("@Rol", Rol));
                cmd.ExecuteNonQuery();
                mensaje = "Se guardo correctamente";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }


        public string eliminarUsuario(string ID)
        {
            string mensaje = "";
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spEliminarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            cmd.ExecuteNonQuery();
            mensaje = "Se eliminó el registro correctamente";
            cnn.Close();
            return mensaje;
         }


        public DataTable buscarUser(string ID)
        {
            //este metodo para buscar Usuario x código
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spBuscarUsuario", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;
        }


        public DataTable mostrarCliente()
        {
            //este metodo esta para mostrar todos los clientes en el datagridview
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spMostrarCliente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }

        public DataTable vertodoClient()
        {
            //este metodo esta para mostrar todos los clientes en el datagridview REPORTE
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spMostrarTodoClient", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }



        public string grabarCliente(string ClientID,string Nombre, string Apellido, string Sexo, string DNI,
            string Email, string Telefono, string Fecha_nac, string Distrito)

        {
            //ESTE METODO ES PARA INSERTAR CLIENTE
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spInsertarCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ClientID", ClientID));
                cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", Apellido));
                cmd.Parameters.Add(new SqlParameter("@Sexo", Sexo));
                cmd.Parameters.Add(new SqlParameter("@DNI", DNI));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                cmd.Parameters.Add(new SqlParameter("@Fecha_nac", Fecha_nac));
                cmd.Parameters.Add(new SqlParameter("@Distrito", Distrito));
                cmd.ExecuteNonQuery();
                mensaje = "Se guardó el registro correctamente";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }

        public string eliminarRegistro(string ClientID)
        {
            //este metodo es PARA ELIMINAR CLIENTE
            string mensaje = "";
            try
            {                           
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spEliminarCliente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ClientID", ClientID));
            cmd.ExecuteNonQuery();
            mensaje = "Se eliminó el registro correctamente";

            } catch(Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }

        public string editarCliente(string ClientID, string Nombre, string Apellido, string Sexo, string DNI,
           string Email, string Telefono, string Fecha_nac, string Distrito)

        {
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spActualizarCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ClientID", ClientID));
                cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                cmd.Parameters.Add(new SqlParameter("@Apellido", Apellido));
                cmd.Parameters.Add(new SqlParameter("@Sexo", Sexo));
                cmd.Parameters.Add(new SqlParameter("@DNI", DNI));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                cmd.Parameters.Add(new SqlParameter("@Fecha_nac", Fecha_nac));
                cmd.Parameters.Add(new SqlParameter("@Distrito", Distrito));
                cmd.ExecuteNonQuery();
                mensaje = "Se actualizó el registro correctamente";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }


        public DataTable buscarCs(string filtro)
        {
            //este metodo para buscar clientes x código,nombre o apellido
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spBuscarClientes", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@filtro", filtro));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;
        }


        public DataTable filtrarCliente(string Distrito)
        {
            //este metodo esta para filtrar todos los clientes en el datagridview REPORTE
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spFiltrarCliente", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Distrito", Distrito));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }

        public DataTable mostrarPeli()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spMostrarPeli", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;
        }

        public string IngresarPelicula(string PeliculaID,string Titulo, string Director, byte[] foto, string Duracion,
            string Genero, string Clasificacion, string Formato, string Estreno)
        {
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spInsertarP", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PeliculaID", SqlDbType.Char,5).Value= PeliculaID;
                cmd.Parameters.Add("@Titulo", SqlDbType.VarChar, 40).Value = Titulo;
                cmd.Parameters.Add("@Director", SqlDbType.VarChar, 40).Value = Director;
                cmd.Parameters.Add("@foto", SqlDbType.Image).Value = foto;
                cmd.Parameters.Add("@Duracion", SqlDbType.Time).Value = Duracion;
                cmd.Parameters.Add("@Genero", SqlDbType.VarChar, 40).Value = Genero;
                cmd.Parameters.Add("@Clasificacion", SqlDbType.VarChar, 40).Value = Clasificacion;
                cmd.Parameters.Add("@Formato", SqlDbType.VarChar, 40).Value = Formato;
                cmd.Parameters.Add("@Estreno", SqlDbType.Date).Value = Estreno;
                cmd.ExecuteNonQuery();
                mensaje = "Se guardó el registro correctamente";
             }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }

        public DataTable buscarPelicula(string PeliculaID)
        {
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spBuscarPelicula", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PeliculaID", PeliculaID));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return tabla;
        }

        public string eliminarPelicula(string PeliculaID)
        {
            string mensaje = "";
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spEliminar_Pelicula", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@PeliculaID", PeliculaID));
            cmd.ExecuteNonQuery();
            mensaje = "Se eliminó el registro correctamente";
            cnn.Close();
            return mensaje;
        }


        public DataTable filtraGenero(string Genero)
        {
            //este metodo esta para filtrar por genero de las películas
            //reporte
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spFiltrarGeneroP", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Genero", Genero));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }

        public DataTable filtraFormat(string Format)
        {
            //este metodo esta para filtrar por formato de las películas
            //reporte
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spFiltrarFormtP", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Formato", Format));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }

        public DataTable filtraClasific(string Clasificacion)
        {
            //este metodo esta para filtrar por clasificacion de las películas
            //reporte
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spFiltrarClasP", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Clasificacion", Clasificacion));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }

        public DataTable filtraEstreno(string Fecha)
        {
            //este metodo esta para filtrar por año de estreno de las películas
            //reporte
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spFiltrarFechaP", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }
        public DataTable vertodoPeli()
        {
            //este metodo esta para mostrar todos las pelis en reporte
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spVertodoP", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }



        public void Add(string TicketID, string Fecha, string Hora,string Cod_client, string Cod_User,List<Concepto> lst )
        {
            //para hacer insert a las 2 tablas
            var dt = new DataTable();
            dt.Columns.Add("Id");
           // dt.Columns.Add("num_ticket");
            dt.Columns.Add("Peli");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("HoraP");
            dt.Columns.Add("Cant");
            dt.Columns.Add("Price");
            dt.Columns.Add("Asiento");
            int i = 0;
            foreach(var oElement in lst)
            {
                dt.Rows.Add(i,oElement.pelicula,oElement.fecha,oElement.hora,
                   oElement.cantidad,oElement.precio,oElement.fila_asiento );
                i++;
            }


            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spGuardarVenta", cnn);
                
                var parametrolista = new SqlParameter("@lstConceptos",SqlDbType.Structured);
                parametrolista.TypeName = "dbo.Detaiils";
                parametrolista.Value = dt;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(parametrolista);
                cmd.Parameters.Add(new SqlParameter("@TicketID", TicketID));
               // cmd.Parameters.AddWithValue("@TicketID", TicketID);
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                cmd.Parameters.Add(new SqlParameter("@Hora", Hora));
                cmd.Parameters.Add(new SqlParameter("@Cod_client", Cod_client));
                cmd.Parameters.Add(new SqlParameter("@Cod_User", Cod_User));

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }

        }


        public DataTable mostrarCartelera()
        {
            //este metodo esta para mostrar todos los clientes en el datagridview
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("spMostrarCartelera", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tabla);
            cnn.Close();
            return tabla;

        }

        public string IngresarCartelera(string Cod_pelicula, string CodSala, string Fecha, string Hora_Inicio,
            string Hora_Termino)
        {
            string mensaje = "";
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spInsertarCartelera", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Cod_pelicula",Cod_pelicula));
                cmd.Parameters.Add(new SqlParameter("@CodSala",CodSala));
                cmd.Parameters.Add(new SqlParameter("@Fecha ",Fecha));
                cmd.Parameters.Add(new SqlParameter("@Hora_Inicio",Hora_Inicio));
                cmd.Parameters.Add(new SqlParameter("@Hora_Termino", Hora_Termino));
                cmd.ExecuteNonQuery();
                mensaje = "Se insertó el registro correctamente";

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return mensaje;
        }



        //metodos para seleccionar asiento y guardar en la base de datos

        public DataTable buscarAsiento(int AsientoID)
        {
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spBuscarAs", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AsientoID", AsientoID));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adapter.Fill(tabla);
                cnn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
            return tabla;
        }


        public void seleccionarAsiento(int cod)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spReservaAsiento", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AsientoID", cod));
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        public void quitarAsiento(int cod)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spQuitarReservacion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AsientoID", cod));
                cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }

        }

        //metodos para el Reporte_Ventas*************
        public DataTable verFTodoVenta(string Fecha1, string Fecha2)
        {
            //este metodo es para filtrar tickets x 2 fechas
            //reporte
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spVerTodoVentas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", Fecha1));
                cmd.Parameters.Add(new SqlParameter("@Fecha2", Fecha2));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }               
            return tabla;
        }

        public DataTable ventasMes(string Fecha)
        {
            //este metodo esta para filtrar ventas mensuales x cualquier año           
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spVentasMensuales", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }        
            return tabla;
        }

        public DataTable ventasDia(string Fecha)
        {
            //este metodo esta para filtrar ventas diarias x cualquier año
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spVentasDiarias", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }        
           return tabla;
        }

        public DataTable contarTMes(string Fecha)
        {
            //este metodo para contar los tickets x Mes
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spCant_TMensuales", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }       
            return tabla;
        }

        public DataTable contarTDia(string Fecha)
        {
            //este metodo para contar los tickets x dia 
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spCant_TDiarios", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }             
            return tabla;
        }

        public DataTable contarxClient()
        {
            // Cuántos tickets tiene cada cliente
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spCantXClient", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
                cnn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }            
            return tabla;
        }

        public DataTable contarxVend()
        {
            // Cuántos tickets GENERA CADA VENDEDOR
            DataTable tabla = new DataTable();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spCantXVend", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }         
            return tabla;
        }

        //fin_reporte ventas**************

        //sp Insertar Venta:
        public void insertarVenta(string TicketID,string Cod_client, string Cod_User)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spInsertarVentas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TicketID",TicketID));
                cmd.Parameters.Add(new SqlParameter("@Cod_client",Cod_client));
                cmd.Parameters.Add(new SqlParameter("@Cod_User",Cod_User));
                cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            finally
            {
                cnn.Close();
            }
        }
        //sp Insertar Detalle_Venta:
        public void insertarDventa(string Num_ticket, string idPeli, string FechaP, 
            string HoraP, string Cantidad, string Precio, string Fila_Asiento)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("spInsertarDVentas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Num_ticket", Num_ticket));
                cmd.Parameters.Add(new SqlParameter("@idPeli", idPeli));
                cmd.Parameters.Add(new SqlParameter("@FechaP", FechaP));
                cmd.Parameters.Add(new SqlParameter("@HoraP", HoraP));
                cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
                cmd.Parameters.Add(new SqlParameter("@Precio ", Precio));
                cmd.Parameters.Add(new SqlParameter("@Fila_Asiento", Fila_Asiento));
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

    }
}