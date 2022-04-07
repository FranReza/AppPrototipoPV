using System;
using System.Text;
using ApiBas = ApisMicrosip.ApiMspBasicaExt;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using AppPrototipoPV;
using System.Linq;

namespace conexionDB
{
    public class conexionDB
    {
        private static conexionDB conexion = null;
        private string nombreusuarioconectado = "SABINE";
        private int db = ApiBas.NewDB();
        public string[] usuarioinfo = new string[5];

        protected conexionDB() { }

        public static conexionDB Instance
        {
            get
            {
                if (conexion == null)
                    conexion = new conexionDB();

                return conexion;
            }
        }

        public int enlazar_conexion()
        {
            ApiBas.SetErrorHandling(0, 0);
            int transaccion = ApiBas.NewTrn(db, 3);
            int conecta = ApiBas.DBConnect(db, "C:/Microsip datos/PRUEBA.fdb", "SABINE", "12345");

            StringBuilder obtieneError = new StringBuilder(1000);
            int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
            String mensajeError = codigoError.ToString();

            if (codigoError > 0)
            {
                return conecta;
            }
            else
            {
                return conecta;
            }

        }

        public int desconectarDB()
        {

            int resultado = ApiBas.DBDisconnect(db);
            ApiBas.LiberarRecursos();
            return resultado;
        }

        public string[] CrearUsuarioCajero()
        {

            int id = 0;
            StringBuilder nombre = new StringBuilder();
            StringBuilder usuario = new StringBuilder();
            StringBuilder operar_Cajas = new StringBuilder();
            StringBuilder abrir_Cajas = new StringBuilder();

            int transaccion = ApiBas.NewTrn(db, 3); //transaccion
            int sql = ApiBas.NewDtst(transaccion); //dataset que hara el select
            ApiBas.TrnStart(transaccion); //inicio de la transaccion

            String cadenaConsulta = "SELECT caje.cajero_id, caje.nombre, caje.usuario, caje.operar_cajas, caje.abrir_cajas FROM cajeros caje WHERE caje.usuario = '" + nombreusuarioconectado + "'"; //consulta
            int exeConsulta = ApiBas.DtstSelQry(sql, cadenaConsulta); //
            int estado_exe = ApiBas.DtstOpen(sql);

            if (estado_exe == 0 && exeConsulta == 0)
            {
                if (ApiBas.DtstRecordCount(sql) != 0)
                {

                    ApiBas.DtstGetFieldAsInteger(sql, "cajero_id", ref id);
                    ApiBas.DtstGetFieldAsString(sql, "nombre", nombre);
                    ApiBas.DtstGetFieldAsString(sql, "usuario", usuario);
                    ApiBas.DtstGetFieldAsString(sql, "operar_cajas", operar_Cajas);
                    ApiBas.DtstGetFieldAsString(sql, "abrir_cajas", abrir_Cajas);

                    usuarioinfo[0] = id.ToString();
                    usuarioinfo[1] = nombre.ToString();
                    usuarioinfo[2] = usuario.ToString();
                    usuarioinfo[3] = operar_Cajas.ToString();
                    usuarioinfo[4] = abrir_Cajas.ToString();
                }
                else
                {
                    return usuarioinfo;
                }
            }
            else
            {
                Debug.WriteLine("owo");
            }

            return usuarioinfo;
            ApiBas.DtstClose(sql);
        }

        public List<Tuple<int, string>> obtener_Cajas_por_abrir_cerrar(int id_cajero, char operacion)
        {

            List<Tuple<Int32, String>> lista_Cajas_abiertas = new List<Tuple<int, string>>();
            int caja_id = 0;
            StringBuilder nombre_caja = new StringBuilder("");
            int transaccion = ApiBas.NewTrn(db, 3);
            int newsql = ApiBas.NewSql(transaccion);
            String cadena_consulta = $"SELECT CAJA_ID, NOMBRE_CAJA FROM CAJAS_POR_ABRIR_CERRAR({id_cajero}, '{operacion}', 0, 0);";
            Debug.WriteLine(cadena_consulta);
            int query = ApiBas.SqlQry(newsql, cadena_consulta);
            int ejecuta_consulta = ApiBas.SqlExecQuery(newsql);
            int filas_obtenidas = ApiBas.SqlRecordCount(newsql);
            Debug.WriteLine("filas obtenidas: " + filas_obtenidas);

            Debug.WriteLine($@"Estados de las variables: {transaccion} , {newsql} , {query} {ejecuta_consulta}");
            StringBuilder obtieneError = new StringBuilder(1000);
            int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
            String mensajeError = codigoError.ToString();
            if (codigoError > 0)
            {
                Debug.WriteLine("error que salio. " + obtieneError.ToString());

            }

            if (filas_obtenidas > 0)
            {
                for (int i = 0; i < filas_obtenidas; i++)
                {
                    ApiBas.SqlGetFieldAsInteger(newsql, "CAJA_ID", ref caja_id);
                    ApiBas.SqlGetFieldAsString(newsql, "NOMBRE_CAJA", nombre_caja);
                    lista_Cajas_abiertas.Add(Tuple.Create<Int32, String>(caja_id, nombre_caja.ToString()));
                    ApiBas.SqlNext(newsql);
                }
                ApiBas.SqlClose(newsql);
                return lista_Cajas_abiertas;
            }
            else
            {
                ApiBas.SqlClose(newsql);
                return lista_Cajas_abiertas;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] Obtener_cliente()
        {
            int id_cliente = 0;
            StringBuilder nombre_cliente = new StringBuilder();
            StringBuilder clave_cliente = new StringBuilder();
            string[] datos_cliente = new string[3];

            int transaccion = ApiBas.NewTrn(db, 3); //transaccion
            int sql = ApiBas.NewSql(transaccion); //dataset que hara el select
            ApiBas.TrnStart(transaccion); //inicio de la transaccion

            String cadenaConsulta = $@"SELECT cc.clave_cliente, c.cliente_id, c.nombre
									 FROM claves_clientes cc
									 JOIN clientes c ON cc.cliente_id = c.cliente_id
									WHERE c.nombre = 'Venta a Publico en Gral.' ROWS 1 TO 1"; //consulta
            ApiBas.SqlQry(sql, cadenaConsulta); //

            int estado_exe = ApiBas.SqlExecQuery(sql);

            if (estado_exe == 0)
            {
                if (ApiBas.SqlRecordCount(sql) != 0)
                {
                    Debug.WriteLine("S. " + ApiBas.SqlRecordCount(sql));
                    int z = ApiBas.SqlGetFieldAsInteger(sql, "cliente_id", ref id_cliente);
                    int x = ApiBas.SqlGetFieldAsString(sql, "nombre", nombre_cliente);
                    int c = ApiBas.SqlGetFieldAsString(sql, "clave_cliente", clave_cliente);

                    Debug.WriteLine("zz " + z + x + c);


                    datos_cliente[0] = id_cliente.ToString();
                    datos_cliente[1] = nombre_cliente.ToString();
                    datos_cliente[2] = clave_cliente.ToString();

                    ApiBas.SqlClose(sql);
                    return datos_cliente;
                }
                else
                {
                    datos_cliente[0] = "";
                    datos_cliente[1] = "";
                    datos_cliente[2] = "";
                    ApiBas.SqlClose(sql);
                }
            }
            return datos_cliente;
        }

        public string[] Obtener_almacen_caja(int caja_id)
        {
            int id_caja = 0;
            StringBuilder nombre_caja = new StringBuilder();
            int almacen_id = 0;
            StringBuilder nombre_almacen = new StringBuilder();
            string[] datos_cliente = new string[4];

            int transaccion = ApiBas.NewTrn(db, 3); //transaccion
            int sql = ApiBas.NewSql(transaccion); //dataset que hara el select
            ApiBas.TrnStart(transaccion); //inicio de la transaccion

            String cadenaConsulta = $@"SELECT c.caja_id, c.nombre AS ""NOMBRE CAJA"", a.almacen_id,
									a.nombre AS ""NOMBRE ALMACEN"" FROM CAJAS c JOIN ALMACENES a ON 
									c.almacen_id = a.almacen_id WHERE c.caja_id = {caja_id}"; //consulta

            ApiBas.SqlQry(sql, cadenaConsulta); //

            int estado_exe = ApiBas.SqlExecQuery(sql);
            if (estado_exe == 0)
            {
                if (ApiBas.SqlRecordCount(sql) != 0)
                {

                    ApiBas.SqlGetFieldAsInteger(sql, "caja_id", ref id_caja);
                    ApiBas.SqlGetFieldAsString(sql, "NOMBRE CAJA", nombre_caja);
                    ApiBas.SqlGetFieldAsInteger(sql, "almacen_id", ref almacen_id);
                    ApiBas.SqlGetFieldAsString(sql, "NOMBRE ALMACEN", nombre_almacen);

                    datos_cliente[0] = id_caja.ToString();
                    datos_cliente[1] = nombre_caja.ToString();
                    datos_cliente[2] = almacen_id.ToString();
                    datos_cliente[3] = nombre_almacen.ToString();

                    ApiBas.SqlClose(sql);
                    return datos_cliente;
                }
                else
                {
                    datos_cliente[0] = "";
                    datos_cliente[1] = "";
                    datos_cliente[2] = "";
                    datos_cliente[3] = "";
                    ApiBas.SqlClose(sql);
                }
            }
            return datos_cliente;
        }

        public List<Tuple<int, string>> obtener_cajas_por_operar(int id_cajero, char operacion)
        {
            int caja_id = 0;
            List<Tuple<Int32, String>> lista_Cajas_abiertas = new List<Tuple<int, string>>();
            StringBuilder nombre_caja = new StringBuilder("");
            int[] arreglo_caja_id;

            int transaccion_cajas_cajero = ApiBas.NewTrn(db, 3);
            int sql_cajas_cajero = ApiBas.NewSql(transaccion_cajas_cajero);

            int transaccion_nombre_cajas = ApiBas.NewTrn(db, 3);
            int sql_nombre_cajas = ApiBas.NewSql(transaccion_nombre_cajas);

            String cadena_consulta = $"SELECT CAJA_ID FROM CAJAS_CAJERO({id_cajero}, '{operacion}', 0);";
            int query_cajas_cajero = ApiBas.SqlQry(sql_cajas_cajero, cadena_consulta);

            int ejecuta_consulta = ApiBas.SqlExecQuery(sql_cajas_cajero);
            int filas_obtenidas = ApiBas.SqlRecordCount(sql_cajas_cajero);
            Debug.WriteLine("filas obtenidas: " + filas_obtenidas);

            //Debug.WriteLine($@"Estados de las variables: {transaccion} , {newsql} , {query} {ejecuta_consulta}");
            StringBuilder obtieneError = new StringBuilder(1000);
            int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
            String mensajeError = codigoError.ToString();
            if (codigoError > 0)
            {
                Debug.WriteLine("error que salio. " + obtieneError.ToString());

            }

            if (filas_obtenidas > 0)
            {
                arreglo_caja_id = new int[filas_obtenidas];

                for (int i = 0; i < filas_obtenidas; i++)
                {
                    ApiBas.SqlGetFieldAsInteger(sql_cajas_cajero, "CAJA_ID", ref caja_id);
                    arreglo_caja_id[i] = caja_id;
                    ApiBas.SqlNext(sql_cajas_cajero);
                }

                for (int i = 0; i < filas_obtenidas; i++)
                {

                    string cadena_consulta_nombres = $"SELECT NOMBRE FROM CAJAS WHERE CAJA_ID = '{arreglo_caja_id[i]}'";
                    ApiBas.SqlQry(sql_nombre_cajas, cadena_consulta_nombres);
                    ApiBas.SqlExecQuery(sql_nombre_cajas);
                    ApiBas.SqlGetFieldAsString(sql_nombre_cajas, "NOMBRE", nombre_caja);
                    lista_Cajas_abiertas.Add(Tuple.Create<Int32, String>(arreglo_caja_id[i], nombre_caja.ToString()));

                }
                ApiBas.SqlClose(sql_cajas_cajero);
                ApiBas.SqlClose(sql_nombre_cajas);
                return lista_Cajas_abiertas;
            }
            else
            {
                ApiBas.SqlClose(sql_cajas_cajero);
                ApiBas.SqlClose(sql_nombre_cajas);
                return lista_Cajas_abiertas;
            }
        }

        public string estatus_caja(int caja_id)
        {
            StringBuilder estatus_caja = new StringBuilder("");
            string? valor_caja = ""; //hacemos esto porque es posible que la caja no acepte cobros y por ende devuelva null
            int transaccion_estatus = ApiBas.NewTrn(db, 3);
            int sql_estatus = ApiBas.NewSql(transaccion_estatus);

            string query_estatus_caja = $"SELECT ESTATUS_DESCRIP FROM GET_ESTATUS_CAJA({caja_id})";
            ApiBas.SqlQry(sql_estatus, query_estatus_caja);
            ApiBas.SqlExecQuery(sql_estatus);

            if (ApiBas.SqlRecordCount(sql_estatus) > 0)
            {

                ApiBas.SqlGetFieldAsString(sql_estatus, "ESTATUS_DESCRIP", estatus_caja);
                valor_caja = estatus_caja.ToString();
                ApiBas.SqlClose(sql_estatus);
            }
            ApiBas.SqlClose(sql_estatus);
            return valor_caja;
        }

        public int Aperturar_caja(int id_cajero, string usuario_cajero, char cajeros_autorizados, int caja_id, string hora, string fecha, string fecha_capturada, string formacobro, string importe)
        {

            int transaccion = ApiBas.NewTrn(db, 3);
            int sql = ApiBas.NewSql(transaccion);
            int estado_trn = ApiBas.TrnStart(transaccion);

            string convertir_fecha_formateada = DateTime.ParseExact(fecha, "dd/MM/yyyy", null).ToString("dd.MM.yyyy");
            string convertir_fechahora_formateada = DateTime.ParseExact(fecha_capturada, "dd/MM/yyyy HH:MM:ss", null).ToString("dd.MM.yyyy HH:MM:ss");

            string query_insert_mvtos_cajas = $@"INSERT INTO MOVTOS_CAJAS (MOVTO_CAJA_ID, FECHA, HORA, TIPO_MOVTO, CAJA_ID," +
            $@"CAJEROS_HABILITADOS, FORMA_EMITIDA, USUARIO_CREADOR, FECHA_HORA_CREACION," +
            $@"USUARIO_AUT_CREACION, USUARIO_ULT_MODIF, FECHA_HORA_ULT_MODIF," +
            $@"USUARIO_AUT_MODIF)" +
            $@"VALUES (" +
            $@"-1, '{convertir_fecha_formateada}', '{hora}', 'A', {caja_id}, '{cajeros_autorizados}'," +
            $@"'N', '{usuario_cajero}', '{convertir_fechahora_formateada}', null, '{usuario_cajero}', '{convertir_fechahora_formateada}', null);";

            int preparar = ApiBas.SqlQry(sql, query_insert_mvtos_cajas);
            int ejecutar = ApiBas.SqlExecQuery(sql);

            if (ejecutar == 0)
            {
                Debug.WriteLine("Operacion exitosa dentro de movtos_cajas");
                ApiBas.TrnCommit(transaccion);
                ApiBas.SqlClose(sql);

            }
            else
            {
                Debug.WriteLine("Error de operacion.....,");
                StringBuilder obtieneError = new StringBuilder(1000);
                int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                String mensajeError = codigoError.ToString();
                if (codigoError > 0)
                {
                    Debug.WriteLine("error que salio. " + obtieneError.ToString());
                }
                return 1;
                ApiBas.TrnRollback(transaccion);
                ApiBas.SqlClose(sql);
            }

            //----------------------------------------------------------------------------------------------------------------//
            //en esta parte la idea es obtener el id de la tabla mvtos_cajas
            int transaccion_procedure = ApiBas.NewTrn(db, 3);
            int sql_procedure = ApiBas.NewSql(transaccion_procedure);
            int movto_caja_id = 0;
            String cadena_consulta = $"SELECT MOVTO_CAJA_ID FROM GET_ULT_MOVTO_CAJA({caja_id})";
            int query_procedimiento = ApiBas.SqlQry(sql_procedure, cadena_consulta);
            int ejecuta_consulta_procedimiento = ApiBas.SqlExecQuery(sql_procedure);


            if (ApiBas.SqlRecordCount(sql_procedure) > 0)
            {
                Debug.WriteLine("Operacion exitosa id obtenido");
                ApiBas.SqlGetFieldAsInteger(sql_procedure, "MOVTO_CAJA_ID", ref movto_caja_id);
                ApiBas.SqlClose(sql_procedure);
                //SqlGetFieldAsInteger
            }
            else
            {
                Debug.WriteLine("Error de operacion.");
                StringBuilder obtieneError = new StringBuilder(1000);
                int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                String mensajeError = codigoError.ToString();
                if (codigoError > 0)
                {
                    Debug.WriteLine("error que salio. " + obtieneError.ToString());
                }
                ApiBas.SqlClose(sql_procedure);
            }


            //----------------------------------------------------------------------------------------------------------------//
            //aqui se supone que insertamos en la tabla movtos_cajas_cajeros
            int transaccion_movtos_cajas_cajeros = ApiBas.NewTrn(db, 3);
            int sql_movtos_cajas_cajeros = ApiBas.NewSql(transaccion_movtos_cajas_cajeros);
            int estado_trn_movtos_cajas_cajeros = ApiBas.TrnStart(transaccion_movtos_cajas_cajeros);


            string query_movtos_cajas_cajeros = $@"INSERT INTO MOVTOS_CAJAS_CAJEROS ( " +
            $@"MOVTO_CAJA_CJO_ID, MOVTO_CAJA_ID, CAJERO_ID)" +
            $@"VALUES (-1,'{movto_caja_id}', {id_cajero})";

            ApiBas.SqlQry(sql_movtos_cajas_cajeros, query_movtos_cajas_cajeros);
            int ejecutar_movtos_cajas_cajeros = ApiBas.SqlExecQuery(sql_movtos_cajas_cajeros);

            if (ejecutar_movtos_cajas_cajeros == 0)
            {
                Debug.WriteLine("Operacion exitosa dentro de movtos_cajas");
                ApiBas.TrnCommit(transaccion_movtos_cajas_cajeros);
                ApiBas.SqlClose(sql_movtos_cajas_cajeros);

            }
            else
            {
                Debug.WriteLine("Error de operacion..");
                StringBuilder obtieneError = new StringBuilder(1000);
                int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                String mensajeError = codigoError.ToString();
                if (codigoError > 0)
                {
                    Debug.WriteLine("error que salio. " + obtieneError.ToString());
                }
                ApiBas.TrnRollback(transaccion_movtos_cajas_cajeros);
                ApiBas.SqlClose(sql_movtos_cajas_cajeros);
                return 1;
            }
            //------------------------------------------------------------------------------------------------------------------//
            //y por ultimo insertamos en la ultima tabla que se llama movtos_cajas_fondos.

            int transaccion_movtos_cajas_fondos = ApiBas.NewTrn(db, 3);
            int sql_movtos_cajas_fondos = ApiBas.NewSql(transaccion_movtos_cajas_fondos);
            int estado_trn_movtos_cajas_fondos = ApiBas.TrnStart(transaccion_movtos_cajas_fondos);


            string query_movtos_cajas_fondos = $@"INSERT INTO MOVTOS_CAJAS_FONDO (MOVTO_CAJA_FONDO_ID, MOVTO_CAJA_ID," +
            $@"FORMA_COBRO_ID, IMPORTE) VALUES (-1, {movto_caja_id}, 564, {importe});";

            ApiBas.SqlQry(sql_movtos_cajas_fondos, query_movtos_cajas_fondos);

            int ejecutar_movtos_Cajas_fondos = ApiBas.SqlExecQuery(sql_movtos_cajas_fondos);

            if (ejecutar_movtos_Cajas_fondos == 0)
            {
                Debug.WriteLine("Operacion exitosa dentro de movtos_cajas_fondos");
                ApiBas.TrnCommit(transaccion_movtos_cajas_fondos);
                ApiBas.SqlClose(sql_movtos_cajas_fondos);

            }
            else
            {
                Debug.WriteLine("Error de operacion...");
                StringBuilder obtieneError = new StringBuilder(1000);
                int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                String mensajeError = codigoError.ToString();
                if (codigoError > 0)
                {
                    Debug.WriteLine("error que salio. " + obtieneError.ToString());
                }
                ApiBas.TrnRollback(transaccion_movtos_cajas_fondos);
                ApiBas.SqlClose(sql_movtos_cajas_fondos);
                return 1;
            }


            return 0;
        }

        public int Cierre_caja(int id_cajero, string usuario_cajero, char cajeros_autorizados, int caja_id, string hora, string fecha, string fecha_capturada, string formacobro, string importe)
        {

            int transaccion = ApiBas.NewTrn(db, 3);
            int sql = ApiBas.NewSql(transaccion);
            int estado_trn = ApiBas.TrnStart(transaccion);

            string convertir_fecha_formateada = DateTime.ParseExact(fecha, "dd/MM/yyyy", null).ToString("dd.MM.yyyy");
            string convertir_fechahora_formateada = DateTime.ParseExact(fecha_capturada, "dd/MM/yyyy HH:mm:ss", null).ToString("dd.MM.yyyy HH:mm:ss");

            string query_insert_mvtos_cajas = $@"INSERT INTO MOVTOS_CAJAS (MOVTO_CAJA_ID, FECHA, HORA, TIPO_MOVTO, CAJA_ID," +
            $@"CAJEROS_HABILITADOS, FORMA_EMITIDA, USUARIO_CREADOR, FECHA_HORA_CREACION," +
            $@"USUARIO_AUT_CREACION, USUARIO_ULT_MODIF, FECHA_HORA_ULT_MODIF," +
            $@"USUARIO_AUT_MODIF)" +
            $@"VALUES (" +
            $@"-1, '{convertir_fecha_formateada}', '{hora}', 'C', {caja_id}, '{cajeros_autorizados}'," +
            $@"'N', '{usuario_cajero}', '{convertir_fechahora_formateada}', null, '{usuario_cajero}', '{convertir_fechahora_formateada}', null);";


            int preparar = ApiBas.SqlQry(sql, query_insert_mvtos_cajas);
            int ejecutar = ApiBas.SqlExecQuery(sql);

            if (ejecutar == 0)
            {
                Debug.WriteLine("Operacion exitosa dentro de movtos_cajas");
                ApiBas.TrnCommit(transaccion);
                ApiBas.SqlClose(sql);
            }
            else
            {
                Debug.WriteLine("Error de operacion.....,");
                Debug.WriteLine(query_insert_mvtos_cajas);
                StringBuilder obtieneError = new StringBuilder(1000);
                int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                String mensajeError = codigoError.ToString();
                if (codigoError > 0)
                {
                    Debug.WriteLine("error que salio. " + obtieneError.ToString());
                }
                return 1;
                ApiBas.TrnRollback(transaccion);
                ApiBas.SqlClose(sql);
            }

            //----------------------------------------------------------------------------------------------------------------//
            //en esta parte la idea es obtener el id del ultimo movimiento la tabla mvtos_cajas
            int transaccion_procedure = ApiBas.NewTrn(db, 3);
            int sql_procedure = ApiBas.NewSql(transaccion_procedure);
            int movto_caja_id = 0;
            String cadena_consulta = $"SELECT MOVTO_CAJA_ID FROM GET_ULT_MOVTO_CAJA({caja_id})";
            int query_procedimiento = ApiBas.SqlQry(sql_procedure, cadena_consulta);
            int ejecuta_consulta_procedimiento = ApiBas.SqlExecQuery(sql_procedure);


            if (ApiBas.SqlRecordCount(sql_procedure) > 0)
            {
                Debug.WriteLine("Operacion exitosa id obtenido");
                ApiBas.SqlGetFieldAsInteger(sql_procedure, "MOVTO_CAJA_ID", ref movto_caja_id);
                ApiBas.SqlClose(sql_procedure);
            }
            else
            {
                Debug.WriteLine("Error de operacion.");
                StringBuilder obtieneError = new StringBuilder(1000);
                int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                String mensajeError = codigoError.ToString();
                if (codigoError > 0)
                {
                    Debug.WriteLine("error que salio. " + obtieneError.ToString());
                }
                ApiBas.SqlClose(sql_procedure);
            }



            //------------------------------------------------------------------------------------------------------------------//
            //y por ultimo insertamos en la ultima tabla que se llama movtos_cajas_fondos.

            int transaccion_movtos_cajas_fondos = ApiBas.NewTrn(db, 3);
            int sql_movtos_cajas_fondos = ApiBas.NewSql(transaccion_movtos_cajas_fondos);
            int estado_trn_movtos_cajas_fondos = ApiBas.TrnStart(transaccion_movtos_cajas_fondos);


            string query_movtos_cajas_fondos = $@"INSERT INTO MOVTOS_CAJAS_FONDO (MOVTO_CAJA_FONDO_ID, MOVTO_CAJA_ID," +
            $@"FORMA_COBRO_ID, IMPORTE) VALUES (-1, {movto_caja_id}, 564, {importe});";

            ApiBas.SqlQry(sql_movtos_cajas_fondos, query_movtos_cajas_fondos);

            int ejecutar_movtos_Cajas_fondos = ApiBas.SqlExecQuery(sql_movtos_cajas_fondos);

            if (ejecutar_movtos_Cajas_fondos == 0)
            {
                Debug.WriteLine("Operacion exitosa dentro de movtos_cajas_fondos");
                ApiBas.TrnCommit(transaccion_movtos_cajas_fondos);
                ApiBas.SqlClose(sql_movtos_cajas_fondos);

            }
            else
            {
                Debug.WriteLine("Error de operacion...");
                StringBuilder obtieneError = new StringBuilder(1000);
                int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                String mensajeError = codigoError.ToString();
                if (codigoError > 0)
                {
                    Debug.WriteLine("error que salio. " + obtieneError.ToString());
                }
                ApiBas.TrnRollback(transaccion_movtos_cajas_fondos);
                ApiBas.SqlClose(sql_movtos_cajas_fondos);
                return 1;
            }
            return 0;
        }

        public void exis_lista_discretos() {
            int transaccion_lista_discretos = ApiBas.NewTrn(db, 3);
            int sql_lista_discretos = ApiBas.NewSql(transaccion_lista_discretos);

            string query_articulo_discreto = $@"SELECT * FROM LISTA_DISCRETOS(18491, 19, NULL)";
            ApiBas.SqlQry(sql_lista_discretos, query_articulo_discreto);
            ApiBas.SqlExecQuery(sql_lista_discretos);

            if (ApiBas.SqlRecordCount(sql_lista_discretos) != 0)
            {//si existe este articulo en la tabla de articulos discretos
             //nos traemos su existencias y sus series
                int id = 0;
                int art_discreto_id = 0;
                double existencia = 0;

                for (int i = 0; i < ApiBas.SqlRecordCount(sql_lista_discretos); i++)
                {
                    ApiBas.SqlGetFieldAsInteger(sql_lista_discretos, "ARTICULO_ID", ref id);
                    ApiBas.SqlGetFieldAsInteger(sql_lista_discretos, "ART_DISCRETO_ID", ref art_discreto_id);
                    ApiBas.SqlGetFieldAsDouble(sql_lista_discretos, "EXISTENCIA", ref existencia);
                    int c = ApiBas.SqlNext(sql_lista_discretos);
                    //aqui llenamos la tupla si tenemos articulos que pertenecen a discretos.
                    Debug.WriteLine($"SALIDA DE DATOS: {id} {art_discreto_id} : {existencia}");
                    //Tuple.Create<Int32, String>(arreglo_caja_id[i], nombre_caja.ToString())
                    //tupla_series_lotes.Add(Tuple.Create<String, String>(art_discreto_id.ToString(), existencia.ToString()));
                    //tupla_series_lotes.ins
                   
                    Debug.WriteLine("D:_" + c);
                    id = 0;
                    art_discreto_id = 0;
                    existencia = 0;
                }

            }
        }
            public Articulo Buscar_Articulo_por_clave_con_precio_impuesto(string clave_articulo, string clave_cliente_id)
        {
            //algunas variables
            int articulo_id = 0;
            StringBuilder cl_articulo = new StringBuilder();
            StringBuilder nombre_ArticuLo = new StringBuilder();
            double precio_uni = 0;
            double precio_imp = 0;
            List<Tuple<String, String>> tupla_series_lotes = new List<Tuple<string, string>>();

            //primero las transacciones.
            int transaccion_busca_articulo = ApiBas.NewTrn(db, 3);
            int transaccion_get_precio = ApiBas.NewTrn(db, 3);
            int transaccion_get_precio_impuesto = ApiBas.NewTrn(db, 3);


            //segundo las variables de sql y store procedure
            int sql_busca_articulo = ApiBas.NewSql(transaccion_busca_articulo);
            int sp_get_precio = ApiBas.NewSp(transaccion_get_precio);
            int sp_get_precio_impuesto = ApiBas.NewSp(transaccion_get_precio_impuesto);


            //PRIMERO BUSCAMOS EL ARTICULO
            string query_busca_articulo = $@"SELECT ARTICULO_ID, CLAVE_ARTICULO, NOMBRE_ARTICULO FROM BUSCA_ARTICULOS('CLAVE', 'N', 'S', '{clave_articulo}', NULL) ROWS 1 TO 1;";
            ApiBas.SqlQry(sql_busca_articulo, query_busca_articulo);
            ApiBas.SqlExecQuery(sql_busca_articulo);

            if (ApiBas.SqlRecordCount(sql_busca_articulo) > 0)
            {
                
                ApiBas.SqlGetFieldAsInteger(sql_busca_articulo, "ARTICULO_ID", ref articulo_id);
                ApiBas.SqlGetFieldAsString(sql_busca_articulo, "CLAVE_ARTICULO", cl_articulo);
                ApiBas.SqlGetFieldAsString(sql_busca_articulo, "NOMBRE_ARTICULO", nombre_ArticuLo);
                //hasta aqui ya terminamos de llenar los articulos

                //despues buscamos el precio de este articulo
                ApiBas.SpName(sp_get_precio, "GET_PRECIO_ARTCLI");
                ApiBas.SpSetParamAsInteger(sp_get_precio, "V_CLIENTE_ID", Convert.ToInt32(clave_cliente_id));
                ApiBas.SpSetParamAsInteger(sp_get_precio, "V_ARTICULO_ID", Convert.ToInt32(articulo_id));
                ApiBas.SpSetParamAsNull(sp_get_precio, "V_FECHA_VENTA");

                ApiBas.SpExecProc(sp_get_precio);
                ApiBas.SpGetParamAsDouble(sp_get_precio, "PRECIO_UNITARIO", ref precio_uni);
                //aqui ya terminamos de buscar el precio del articulo dado.

                //por ultimo buscamos su precio con impuesto incluido
                ApiBas.SpName(sp_get_precio_impuesto, "PRECIO_CON_IMPTO");
                ApiBas.SpSetParamAsInteger(sp_get_precio_impuesto, "V_ARTICULO_ID", Convert.ToInt32(articulo_id));
                ApiBas.SpSetParamAsDouble(sp_get_precio_impuesto, "V_PRECIO", precio_uni);
                ApiBas.SpSetParamAsString(sp_get_precio_impuesto, "V_CARGAR_SUN", "N");
                ApiBas.SpSetParamAsString(sp_get_precio_impuesto, "V_OPERACION", "P");

                ApiBas.SpExecProc(sp_get_precio_impuesto);
                ApiBas.SpGetParamAsDouble(sp_get_precio_impuesto, "PRECIO", ref precio_imp);


                //despues verificamos si es un articulo discreto que tiene serie o lote 
                
                    //aqui enviamos el objeto con la lista de tuplas llena.
                    Articulo art_tuple = new Articulo(articulo_id, cl_articulo.ToString(), nombre_ArticuLo.ToString(), precio_uni, precio_imp, 1, tupla_series_lotes);
                    return art_tuple;
                

                //esto es lo que nos deberia salir...
                Debug.WriteLine($"salieron los valores sigueintes a: {articulo_id} c: {cl_articulo} n: {nombre_ArticuLo} p: {precio_uni} pi: {precio_imp}");
                //aqui en caso de que sea un producto que no es de serie o lote lo enviamos vacio
                Articulo art = new Articulo(articulo_id, cl_articulo.ToString(), nombre_ArticuLo.ToString(), precio_uni, precio_imp, 1, null);
                return art;
            }

            return null;
        }

        public int Realizar_Venta_Mostrador(List<Articulo> list_art, Cliente cli, Caja caj, Cajero caje, double total_venta, double total_recibido, double total_unitario, double total_con_impuestos)
        {
            //------------------------VARIABLES--------------------------------
            string folio_generado = "W000"; //con esta variable creamos un folio desde un sp
            int folio = 0; //folio obtenido desde un sp
            int id_generado = 0; //aqui obtendremos el id para la tabla doctos_pv

            //-------------------------TRANSACCIONES---------------------------------
            int transaccion_docto_pv = ApiBas.NewTrn(db, 3);
            int transaccion_sp1 = ApiBas.NewTrn(db, 3);
            int transaccion_sp_gen_id = ApiBas.NewTrn(db, 3);
            int transaccion_doctos_pv_detalles = ApiBas.NewTrn(db, 3);
            int transaccion_doctos_pv_cobros = ApiBas.NewTrn(db, 3);
            int transaccion_doctos_pv_cobros2 = ApiBas.NewTrn(db, 3);
            int transaccion_aplica_doctos_pv_sp = ApiBas.NewTrn(db, 3);

            //--------------------------OBJETOS SQL Y SP-----------------------------
            int sql_docto_pv = ApiBas.NewSql(transaccion_docto_pv);
            int sql_doctos_pv_detalles = ApiBas.NewSql(transaccion_doctos_pv_detalles);
            int sql_doctos_pv_cobros = ApiBas.NewSql(transaccion_doctos_pv_cobros);
            int sql_doctos_pv_cobros2 = ApiBas.NewSql(transaccion_doctos_pv_cobros);
            int sp_1 = ApiBas.NewSp(transaccion_sp1);
            int sp_2 = ApiBas.NewSp(transaccion_sp_gen_id);
            int sp_3 = ApiBas.NewSp(transaccion_aplica_doctos_pv_sp);

            //------------------------primero obtenemos algunos valores para insertar----------------------
            //despues aqui obtenemos un id para la tabla doctos_pv confiando que no sera repetido.----
            ApiBas.SpName(sp_2, "GEN_DOCTO_ID");
            ApiBas.SpExecProc(sp_2);
            ApiBas.SpGetParamAsInteger(sp_2, "DOCTO_ID", ref id_generado); //aqui ya obtuvimos el id

            //primero aqui obtenemos el folio que necesitamos.
            ApiBas.SpName(sp_1, "GEN_FOLIO_TEMP");
            ApiBas.SpExecProc(sp_1);
            ApiBas.SpGetParamAsInteger(sp_1, "FOLIO_TEMP", ref folio);
            folio_generado += folio; //aqui concantenamos el folio.

            //preparamos la consulta metiendo toda la informacion que necesitamos para insertar en doctos_pv
            ApiBas.TrnStart(transaccion_docto_pv);
            string query_docto_pv = $@"INSERT INTO DOCTOS_PV (DOCTO_PV_ID,CAJA_ID,TIPO_DOCTO,
									SUCURSAL_ID,FOLIO,FECHA,HORA,CAJERO_ID,CLAVE_CLIENTE,CLIENTE_ID,
									CLAVE_CLIENTE_FAC,CLIENTE_FAC_ID,DIR_CLI_ID,ALMACEN_ID,
									LUGAR_EXPEDICION_ID,MONEDA_ID,IMPUESTO_INCLUIDO,TIPO_CAMBIO,
									TIPO_DSCTO,DSCTO_PCTJE,DSCTO_IMPORTE,ESTATUS,APLICADO,IMPORTE_NETO,
									TOTAL_IMPUESTOS,TOTAL_RETENCIONES,IMPORTE_DONATIVO,TOTAL_FPGC,
									TICKET_EMITIDO,FORMA_EMITIDA,FORMA_GLOBAL_EMITIDA,CONTABILIZADO,
									SISTEMA_ORIGEN,VENDEDOR_ID,CARGAR_SUN,PERSONA,TIPO_GEN_FAC,ES_FAC_GLOBAL,
									FECHA_INI_FAC_GLOBAL,FECHA_FIN_FAC_GLOBAL,INCL_FACTURADOS_FAC_GLOBAL,
									ALMACEN_ID_FAC_GLOBAL,REFER_RETING,UNID_COMPROM,DESCRIPCION,IMPUESTO_SUSTITUIDO_ID,
									IMPUESTO_SUSTITUTO_ID,ES_CFD, MODALIDAD_FACTURACION,ENVIADO, EMAIL_ENVIO, 
									USUARIO_CREADOR, CFDI_CERTIFICADO, USO_CFDI, METODO_PAGO_SAT, PARTIDA_AJUSTE_ID,
									PRECIO_ORIG_PARTIDA_AJUSTE, FECHA_HORA_CREACION,USUARIO_ULT_MODIF, USUARIO_AUT_CREACION, 
									FECHA_HORA_ULT_MODIF, USUARIO_CANCELACION, 
									USUARIO_AUT_MODIF, FECHA_HORA_CANCELACION, 
									FECHA_HORA_ENVIO, USUARIO_AUT_CANCELACION)
									VALUES (
									{id_generado}, {caj.Caja_id}, 'V', 11448, '{folio_generado}', 
									'TODAY', 'NOW', {caje.Idcajero}, 
									'{cli.Clave_cliente}', {cli.Cliente_id}, NULL, NULL, NULL, {caj.Almacen_id}, NULL,
									1, 'S', 1, 'P', 0, 0, 'N', 'S', {total_unitario}, {total_con_impuestos},
									0, 0, 0, 'N', 'N', 'N', 'N', 'PV', NULL, 'S', 
									NULL, NULL, 'N', NULL, NULL, 'N', NULL, NULL, 
									'N', NULL, NULL, NULL, 'N', NULL, 'N', NULL, '{caje.Usuariocajero}',
									'N', NULL, NULL, NULL, 0, 'NOW', 
									'{caje.Usuariocajero}', NULL, 'NOW', NULL,
									NULL, NULL, 'NOW', NULL);";

            //preparamos la consulta....
            ApiBas.SqlQry(sql_docto_pv, query_docto_pv); //aqui preparamos la consulta
            int q = ApiBas.SqlExecQuery(sql_docto_pv); //aqui ejecutamos y tenemos que capturar su valor para hacer commit

            if (q == 0)
            { //significa que tuvo exito para insertar en la db
                ApiBas.TrnCommit(transaccion_docto_pv); //guardamos los cambios con commit 
            }
            else
            {
                ApiBas.TrnRollback(transaccion_docto_pv); //deshacemos los cambios y devolveremos un estado.
                return q;
            }
            //aqui ya empezamos a insertar en doctos_pv_detalle
            ApiBas.TrnStart(transaccion_doctos_pv_detalles);

            //aqui hacemos una manipulacion a la data que nos esta llegando de los articulos.
            var datosAgrupados = list_art.GroupBy(d => d.Articulo_id).Select(
                g => new
                {
                    id = g.Key,
                    clave = g.First().Clave_articulo,
                    nombre = g.First().Nombre_articulo,
                    precio_u = g.First().Precio_unitario,
                    precio_i = g.First().Precio_impuesto,
                    cantidades = g.Sum(s => s.Cantidad)
                });

            foreach (var dato in datosAgrupados)
            {
                int i = 1;
                string query_docto_pv_detalles = $@"INSERT INTO DOCTOS_PV_DET (DOCTO_PV_DET_ID,
							DOCTO_PV_ID, CLAVE_ARTICULO, ARTICULO_ID, UNIDADES,
							UNIDADES_DEV, TIPO_CONTAB_UNID, PRECIO_UNITARIO,
							PRECIO_UNITARIO_IMPTO, IMPUESTO_POR_UNIDAD, PCTJE_DSCTO,
							PRECIO_TOTAL_NETO, PRECIO_MODIFICADO, VENDEDOR_ID, 
							PCTJE_COMIS, ROL, NOTAS, ES_TRAN_ELECT, ESTATUS_TRAN_ELECT,
							POSICION, DSCTO_ART, DSCTO_EXTRA)
							VALUES
							(-1, {id_generado}, '{dato.clave}', {dato.id}, 
							{dato.cantidades}, 0, '0', {dato.precio_u}, {dato.precio_i}, 0, 0, 
							{dato.precio_u}, 'N', NULL, 0, 'N', NULL, 
							'N', NULL, {i}, 0, 0);";
                ApiBas.SqlQry(sql_doctos_pv_detalles, query_docto_pv_detalles); //aqui preparamos la consulta
                int c = ApiBas.SqlExecQuery(sql_doctos_pv_detalles);
                if (c == 0)
                {
                    ApiBas.TrnCommit(transaccion_doctos_pv_detalles);//guardamos en caso de que todo este bien
                }
                else
                {
                    ApiBas.TrnRollback(transaccion_doctos_pv_detalles); //eliminamos lo que hicimos 
                    return c;//nos retorna lo que salio en caso de que no funcione este metodo.
                }
            }

            //ahora guardamos en doctos_pv_cobros
            ApiBas.TrnStart(transaccion_doctos_pv_cobros);

            string query_DOCTOS_PV_COBROS1 = $@"INSERT INTO DOCTOS_PV_COBROS (DOCTO_PV_COBRO_ID, DOCTO_PV_ID, TIPO, 
							FORMA_COBRO_ID, IMPORTE,TIPO_CAMBIO, IMPORTE_MON_DOC)
							VALUES (-1, {id_generado}, 'C', 564, {total_recibido}, 1, {total_recibido})";

            string query_DOCTOS_PV_COBROS2 = $@"INSERT INTO DOCTOS_PV_COBROS (DOCTO_PV_COBRO_ID, DOCTO_PV_ID, TIPO, 
							FORMA_COBRO_ID, IMPORTE,TIPO_CAMBIO, IMPORTE_MON_DOC)
							VALUES (-1, {id_generado}, 'A', 564, {total_recibido - total_venta}, 1, {total_recibido - total_venta})";

            ApiBas.SqlQry(sql_doctos_pv_cobros, query_DOCTOS_PV_COBROS1);
            int v = ApiBas.SqlExecQuery(sql_doctos_pv_cobros);

            if (v == 0)
            {
                ApiBas.TrnCommit(transaccion_doctos_pv_cobros);
            }
            else
            {
                ApiBas.TrnRollback(transaccion_doctos_pv_cobros);
                return v;
            }
            //hacemos una validacion en la tabla doctos_pv_cobros cuando sale que el importe mon = 0.00
            if (total_recibido - total_venta != 0) {
                ApiBas.TrnStart(transaccion_doctos_pv_cobros2);
                ApiBas.SqlQry(sql_doctos_pv_cobros2, query_DOCTOS_PV_COBROS2);
                int l = ApiBas.SqlExecQuery(sql_doctos_pv_cobros2);

                if (l == 0)
                {
                    ApiBas.TrnCommit(transaccion_doctos_pv_cobros2);
                }
                else
                {
                    StringBuilder obtieneError = new StringBuilder(1000);
                    int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
                    String mensajeError = codigoError.ToString();
                    if (codigoError > 0)
                    {
                        Debug.WriteLine("error que salio. " + obtieneError.ToString());
                    }
                    ApiBas.TrnRollback(transaccion_doctos_pv_cobros2);
                    return l;
                }
            }

            ApiBas.SpName(sp_3, "APLICA_DOCTO_PV");
            Debug.WriteLine("S:" + id_generado);
            ApiBas.SpSetParamAsInteger(sp_3, "V_DOCTO_PV_ID", id_generado);
            int u = ApiBas.SpExecProc(sp_3);

            if (u == 0)
            {
                ApiBas.TrnCommit(transaccion_aplica_doctos_pv_sp);
            }
            else
            {
                ApiBas.TrnRollback(transaccion_aplica_doctos_pv_sp);
                return u;
            }
            return 0; //si llega hasta aqui el codigo quiere decir que todo se guardo con exito.
        }
    }
}
