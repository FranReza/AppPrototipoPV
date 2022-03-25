using System;
using System.Text;
using ApiBas = ApisMicrosip.ApiMspBasicaExt;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

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

		public int enlazar_conexion() {
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

		public int desconectarDB() {
			
			int resultado = ApiBas.DBDisconnect(db);
			ApiBas.LiberarRecursos();
			return resultado;
		}

		public string[] CrearUsuarioCajero() {

			int id = 0;
			StringBuilder nombre = new StringBuilder();
			StringBuilder usuario = new StringBuilder();
			StringBuilder operar_Cajas = new StringBuilder();
			StringBuilder abrir_Cajas = new StringBuilder();

			int transaccion = ApiBas.NewTrn(db, 3); //transaccion
			int sql = ApiBas.NewDtst(transaccion); //dataset que hara el select
			ApiBas.TrnStart(transaccion); //inicio de la transaccion

			String cadenaConsulta = "SELECT caje.cajero_id, caje.nombre, caje.usuario, caje.operar_cajas, caje.abrir_cajas FROM cajeros caje WHERE caje.usuario = '"+nombreusuarioconectado+"'"; //consulta
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
				else {
					return usuarioinfo;
				}	
			}
			else {
				Debug.WriteLine("owo");
			}

			return usuarioinfo;
			ApiBas.DtstClose(sql);
		}

		public List<Tuple<int, string>> obtener_Cajas_por_abrir_cerrar(int id_cajero, char operacion) {

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
			Debug.WriteLine("filas obtenidas: "+filas_obtenidas);

			Debug.WriteLine($@"Estados de las variables: {transaccion} , {newsql} , {query} {ejecuta_consulta}");
			StringBuilder obtieneError = new StringBuilder(1000);
			int codigoError = ApiBas.GetLastErrorMessage(obtieneError);
			String mensajeError = codigoError.ToString();
			if (codigoError > 0)
			{
				Debug.WriteLine("error que salio. "+obtieneError.ToString());
				
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
			else {
				ApiBas.SqlClose(newsql);
				return lista_Cajas_abiertas;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string[] Obtener_cliente() {
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
					Debug.WriteLine("S. "+ ApiBas.SqlRecordCount(sql));
					int z = ApiBas.SqlGetFieldAsInteger(sql, "cliente_id", ref id_cliente);
					int x = ApiBas.SqlGetFieldAsString(sql, "nombre", nombre_cliente);
					int c = ApiBas.SqlGetFieldAsString(sql, "clave_cliente", clave_cliente);

					Debug.WriteLine("zz "+z + x+ c);


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
									c.almacen_id = a.almacen_id WHERE c.caja_id = 750"; //consulta

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

				for (int i = 0; i < filas_obtenidas; i++) {

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

		public string estatus_caja(int caja_id) {
			StringBuilder estatus_caja = new StringBuilder("");
			string? valor_caja = ""; //hacemos esto porque es posible que la caja no acepte cobros y por ende devuelva null
			int transaccion_estatus = ApiBas.NewTrn(db, 3);
			int sql_estatus = ApiBas.NewSql(transaccion_estatus);

			string query_estatus_caja = $"SELECT ESTATUS_DESCRIP FROM GET_ESTATUS_CAJA({caja_id})";
			ApiBas.SqlQry(sql_estatus, query_estatus_caja);
			ApiBas.SqlExecQuery(sql_estatus);

			if (ApiBas.SqlRecordCount(sql_estatus) > 0) {

				ApiBas.SqlGetFieldAsString(sql_estatus, "ESTATUS_DESCRIP", estatus_caja);
				valor_caja = estatus_caja.ToString();
				ApiBas.SqlClose(sql_estatus);
			}
			ApiBas.SqlClose(sql_estatus);
			return valor_caja;
		}

		public int Aperturar_caja(int id_cajero, string usuario_cajero, char cajeros_autorizados, int caja_id, string hora, string fecha, string fecha_capturada, string formacobro, string importe) {
			
			int transaccion = ApiBas.NewTrn(db, 3);
			int sql = ApiBas.NewSql(transaccion);
			int estado_trn = ApiBas.TrnStart(transaccion);

			string convertir_fecha_formateada = DateTime.ParseExact(fecha, "dd/MM/yyyy", null).ToString("dd.MM.yyyy");
			string convertir_fechahora_formateada = DateTime.ParseExact(fecha_capturada, "dd/MM/yyyy HH:MM:ss", null).ToString("dd.MM.yyyy HH:MM:ss");

			string query_insert_mvtos_cajas = $@"INSERT INTO MOVTOS_CAJAS (MOVTO_CAJA_ID, FECHA, HORA, TIPO_MOVTO, CAJA_ID,"+
			$@"CAJEROS_HABILITADOS, FORMA_EMITIDA, USUARIO_CREADOR, FECHA_HORA_CREACION,"+
			$@"USUARIO_AUT_CREACION, USUARIO_ULT_MODIF, FECHA_HORA_ULT_MODIF,"+
			$@"USUARIO_AUT_MODIF)"+
			$@"VALUES ("+
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
			else {
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
			}
			else {
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
			
			
			string query_movtos_cajas_fondos = $@"INSERT INTO MOVTOS_CAJAS_FONDO (MOVTO_CAJA_FONDO_ID, MOVTO_CAJA_ID,"+
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
			string convertir_fechahora_formateada = DateTime.ParseExact(fecha_capturada, "dd/MM/yyyy HH:MM:ss", null).ToString("dd.MM.yyyy HH:MM:ss");

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

		public void Buscar_Articulo() {
		
		}
	}
}
