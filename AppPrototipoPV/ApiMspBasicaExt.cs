using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ApisMicrosip
{
    public class ApiMspBasicaExt
    {
        // Equivalencias de Delphi en C#
        // PChar -> parametro de salida de la API: StringBuilder C#
        // PChar -> parametro de entrada de la API: string C#
        // Word -> parametro de la API: -> UInt16 (0..65535) ushort 
        // Double -> parametro de la API (double-precision 64-bit) -> Double C#

        // ********** Manejo de errores  ********** 
        // function GetLastErrorCode: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int GetLastErrorCode();

        // function GetLastIBErroCode: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int GetLastIBErroCode();

        //function GetLastErrorMessage(ErrorMessage: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int GetLastErrorMessage(StringBuilder ErrorMessage);

        //procedure SetErrorHandling(ExceptionOnError, MessageOnException: Integer); stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void SetErrorHandling(int ExceptionOnError, int MessageOnException);


        // Manejo de Excepciones y Liberar recursos.
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void SuspendExceptions(); 
        
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void RestoreExceptions(); 
        
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int ExceptionsSuspended(); 

        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern void LiberarRecursos();
 

        // ********** Base de datos  ********** 
        //function NewDB: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int NewDB();

        //function DBCount: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DBCount();

        //function DBConnect(DBHandle: Integer; DataBaseName: PChar; UserName, Password: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DBConnect(int DBHandle, string DataBaseName, string UserName, string Password);
        
        //function DBGetDefaultTrn(DBHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DBGetDefaultTrn(int DBHandle);

        //function DBCloseDatasets(DBHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DBCloseDatasets(int DBHandle);

        //function DBDisconnect(DBHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DBDisconnect(int DBHandle);

        //function DBConnected(DBHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DBConnected(int DBHandle);

        // ********** Transacciones ********** 
        //function NewTrn(DBHandle, TrnType: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int NewTrn(int DBHandle, int TrnType);

        //function TrnCount: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int TrnCount();

        //function TrnStart(TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int TrnStart(int TrnHandle);

        //function TrnInTransaction(TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int TrnInTransaction(int TrnHandle);

        //function TrnCommit(TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int TrnCommit(int TrnHandle);

        //function TrnRollback(TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int TrnRollback(int TrnHandle);

        //function TrnConfig(TrnHandle: Integer; TrnType: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int TrnConfig(int TrnHandle, int TrnType);


        // *************  DataSet  ***************
        //function NewDtst(TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int NewDtst(int TrnHandle);

        //function DtstCount: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstCount();

        //function DtstConfig(DtstHandle, TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstConfig(int DtstHandle, int TrnHandle);

        //function DtstSelQry(DtstHandle: Integer; Query: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSelQry(int DtstHandle, string Query);

        //function DtstInsQry(DtstHandle: Integer; Query: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstInsQry(int DtstHandle, string Query);

        //function DtstUpdQry(DtstHandle: Integer; Query: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstUpdQry(int DtstHandle, string Query);

        //function DtstDelQry(DtstHandle: Integer; Query: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstDelQry(int DtstHandle, string Query);

        //function DtstRefreshQry(DtstHandle: Integer; Query: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int DtstRefreshQry(int DtstHandle, string Query);

        //function DtstSetParamAsString
        //  (DtstHandle: Integer; ParamName: PChar; ParamValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetParamAsString(int DtstHandle, string ParamName, string ParamValue);

        //function DtstSetParamAsDateTime(DtstHandle: Integer; ParamName: PChar;
        //  Day, Month, Year, Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetParamAsDateTime(int DtstHandle, string ParamName,
          ushort Day, ushort Month, ushort Year, ushort Hour, ushort Minute, ushort Second);

        //function DtstSetParamAsInteger
        //  (DtstHandle: Integer; ParamName: PChar; ParamValue: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetParamAsInteger(int DtstHandle, string ParamName, int ParamValue);

        //function DtstSetParamAsDouble
        //(DtstHandle: Integer; ParamName: PChar; ParamValue: Double): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetParamAsDouble(int DtstHandle, string ParamName, double ParamValue);

        //function DtstSetParamAsNull
        //  (DtstHandle: Integer; ParamName: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetParamAsNull(int DtstHandle, string ParamName);

        //function DtstOpen(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstOpen(int DtstHandle);

        //function DtstClose(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstClose(int DtstHandle);

        //function DtstFirst(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstFirst(int DtstHandle);

        //function DtstNext(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstNext(int DtstHandle);

        //function DtstPrev(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstPrev(int DtstHandle);

        //function DtstLast(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstLast(int DtstHandle);

        //function DtstEof(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstEof(int DtstHandle);

        //function DtstBof(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstBof(int DtstHandle);

        //function DtstRecordCount(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstRecordCount(int DtstHandle);

        //function DtstGetFieldAsString
        //  (DtstHandle: Integer; FieldName: PChar; FieldValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int DtstGetFieldAsString(int DtstHandle, string FieldName, StringBuilder FieldValue);

        //function DtstGetFieldAsDate
        //  (DtstHandle: Integer; FieldName: PChar; Var Day, Month, Year: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstGetFieldAsDate
          (int DtstHandle, string FieldName, ref ushort Day, ref ushort Month, ref ushort Year);

        //function DtstGetFieldAsTime
        //  (DtstHandle: Integer; FieldName: PChar; Var Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstGetFieldAsTime
          (int DtstHandle, string FieldName, ref ushort Hour, ref ushort Minute, ref ushort Second);

        //function DtstGetFieldAsDateTime
        //  (DtstHandle: Integer; FieldName: PChar; Var Day, Month, Year, Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstGetFieldAsDateTime
          (int DtstHandle, string FieldName, ref ushort Day, ref ushort Month, ref ushort Year,
		   ref ushort Hour, ref ushort Minute, ref ushort Second);

        //function DtstGetFieldAsInteger
        //  (DtstHandle: Integer; FieldName: PChar; Var FieldValue: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstGetFieldAsInteger
        (int DtstHandle, string FieldName, ref int FieldValue);

        //function DtstGetFieldAsDouble(DtstHandle: Integer; FieldName: PChar;
        //Var FieldValue: Double): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstGetFieldAsDouble
        (int DtstHandle, string FieldName, ref Double FieldValue);

        //function DtstGetFieldAsMemo(DtstHandle: Integer; FieldName: PChar; FieldValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstGetFieldAsMemo
        (int DtstHandle, string FieldName, StringBuilder FieldValue);

        //{Asignar valores a los Campos}
        //function DtstSetFieldAsString(dtstHandle: Integer; FieldName, FieldValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetFieldAsString(int dtstHandle, string FieldName, string FieldValue);

        //function DtstSetFieldAsDate(DtstHandle: Integer; FieldName: PChar; Day, Month, Year: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetFieldAsDate(int DtstHandle, string FieldName, ushort Day, ushort Month, ushort Year);

        //function DtstSetFieldAsTime(DtstHandle: Integer; FieldName: PChar; Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetFieldAsTime(int DtstHandle, string FieldName, ushort Hour, ushort Minute, ushort Second);

        //function DtstSetFieldAsDateTime (DtstHandle: Integer; FieldName: PChar;
        // Day, Month, Year, Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetFieldAsDateTime(int DtstHandle, string FieldName,
        ushort Day, ushort Month, ushort Year, ushort Hour, ushort Minute, ushort Second);

        //function DtstSetFieldAsInteger(DtstHandle: Integer; FieldName: PChar; FieldValue: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetFieldAsInteger(int DtstHandle, string FieldName, int FieldValue);

        //function DtstSetFieldAsDouble(DtstHandle: Integer; FieldName: PChar; FieldValue: Double): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetFieldAsDouble(int DtstHandle, string FieldName, Double FieldValue);

        //function DtstSetFieldAsMemo(dtstHandle: Integer; FieldName, FieldValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]                           // Es tipo memo
        public static extern int DtstSetFieldAsMemo(int dtstHandle, string FieldName, string FieldValue);

        //function DtstSetFieldAsNull(dtstHandle: Integer; FieldName: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstSetFieldAsNull(int dtstHandle, string FieldName);

        //{Cambio de estados}
        //function DtstInsert(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstInsert(int DtstHandle);

        //function DtstEdit(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstEdit(int DtstHandle);

        //function DtstDelete(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstDelete(int DtstHandle);

        //function DtstCancel(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstCancel(int DtstHandle);

        //function DtstPost(DtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstPost(int DtstHandle);

        //{Maestro/Detalle}
        //function DtstLink(MasterDtstHandle: Integer; SlaveDtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstLink(int MasterDtstHandle, int SlaveDtstHandle);

        //function DtstUnLink(SlaveDtstHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int DtstUnLink(int SlaveDtstHandle);

        //// Objeto SQL
        //function NewSql(TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int NewSql(int TrnHandle);

        //function SqlCount: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlCount();

        //function SqlConfig(SqlHandle, TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlConfig(int SqlHandle, int TrnHandle);

        //function SqlQry(SqlHandle: Integer; Query: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlQry(int SqlHandle, string Query);

        //function SqlSetParamAsString(SqlHandle: Integer; ParamName: PChar; ParamValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlSetParamAsString(int SqlHandle, string ParamName, string ParamValue);

        //function SqlSetParamAsDateTime(SqlHandle: Integer; ParamName: PChar;
        //  Day, Month, Year, Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlSetParamAsDateTime(int SqlHandle, string ParamName,
        ushort Day, ushort Month, ushort Year, ushort Hour, ushort Minute, ushort Second);

        //function SqlSetParamAsInteger(SqlHandle: Integer; ParamName: PChar; ParamValue: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlSetParamAsInteger(int SqlHandle, string ParamName, int ParamValue);

        //function SqlSetParamAsDouble(SqlHandle: Integer; ParamName: PChar; ParamValue: Double): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlSetParamAsDouble(int SqlHandle, string ParamName, Double ParamValue);

        //function SqlSetParamAsMemo(SqlHandle: Integer; ParamName: PChar; ParamValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlSetParamAsMemo(int SqlHandle, string ParamName, string ParamValue);

        //function SqlSetParamAsNull(SqlHandle: Integer; ParamName: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlSetParamAsNull(int SqlHandle, string ParamName);

        //function SqlExecQuery(SqlHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlExecQuery(int SqlHandle);

        //function SqlClose(SqlHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlClose(int SqlHandle);

        //function SqlNext(SqlHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlNext(int SqlHandle);

        //function SqlEof(SqlHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlEof(int SqlHandle);

        //function SqlRecordCount(SqlHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlRecordCount(int SqlHandle);

        //function SqlGetFieldAsString(SqlHandle: Integer; FieldName: PChar; FieldValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlGetFieldAsString(int SqlHandle, string FieldName, StringBuilder FieldValue);

        //function SqlGetFieldAsDate(SqlHandle: Integer; FieldName: PChar;
        //  Var Day, Month, Year: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlGetFieldAsDate(int SqlHandle, string FieldName,
          ref ushort Day, ref ushort Month, ref ushort Year);

        //function SqlGetFieldAsTime(SqlHandle: Integer; FieldName: PChar;
        //  Var Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlGetFieldAsTime(int SqlHandle, String FieldName,
          ref ushort Hour, ref ushort Minute, ref ushort Second);

        //function SqlGetFieldAsDateTime(SqlHandle: Integer; FieldName: PChar;
        //  Var Day, Month, Year, Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlGetFieldAsDateTime(int SqlHandle, String FieldName,
          ref ushort Day, ref ushort Month, ref ushort Year, ref ushort Hour, ref ushort Minute, ref ushort Second);

        //function SqlGetFieldAsInteger(SqlHandle: Integer; FieldName: PChar;
        //  Var FieldValue: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlGetFieldAsInteger(int SqlHandle, string FieldName,
          ref int FieldValue);

        //function SqlGetFieldAsDouble(SqlHandle: Integer; FieldName: PChar;
        //  Var FieldValue: Double): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlGetFieldAsDouble(int SqlHandle, string FieldName,
          ref double FieldValue);

        //function SqlGetFieldAsMemo(SqlHandle: Integer; FieldName: PChar;
        //  FieldValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SqlGetFieldAsMemo(int SqlHandle, string FieldName,
        StringBuilder FieldValue);


        //// Objeto StoredProc
        //function NewSp(TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int NewSp(int TrnHandle);

        //function SpCount: Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpCount();

        // function SpConfig(SpHandle, TrnHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpConfig(int SpHandle, int TrnHandle);

        //function SpName(SpHandle: Integer; ProcName: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpName(int SpHandle, string ProcName);

        //function SpSetParamAsString(SpHandle: Integer; ParamName: PChar; ParamValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpSetParamAsString(int SpHandle, string ParamName, string ParamValue);

        //function SpSetParamAsDateTime(SpHandle: Integer; ParamName: PChar;
        //  Day, Month, Year, Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpSetParamAsDateTime(int SpHandle, string ParamName,
        ushort Day, ushort Month, ushort Year, ushort Hour, ushort Minute, ushort Second);

        //function SpSetParamAsInteger(SpHandle: Integer; ParamName: PChar; ParamValue: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpSetParamAsInteger(int SpHandle, string ParamName, int ParamValue);

        //function SpSetParamAsDouble(SpHandle: Integer; ParamName: PChar; ParamValue: Double): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpSetParamAsDouble(int SpHandle, string ParamName, double ParamValue);

        //function SpSetParamAsNull(SpHandle: Integer; ParamName: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpSetParamAsNull(int SpHandle, string ParamName);

        //function SpExecProc(SpHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpExecProc(int SpHandle);

	//function SpGetParamAsString(SpHandle: Integer; ParamName: PChar; ParamValue: PChar): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpGetParamAsString(int SpHandle, string ParamName, StringBuilder ParamValue);

        //function SpGetParamAsDate(SpHandle: Integer; ParamName: PChar;
        //  Var Day, Month, Year: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpGetParamAsDate(int SpHandle, string ParamName,
        ref ushort Day, ref ushort Month, ref ushort Year);

        //function SpGetParamAsTime(SpHandle: Integer; ParamName: PChar;
        //  Var Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpGetParamAsTime(int SpHandle, string ParamName,
        ref ushort Hour, ref ushort Minute, ref ushort Second);

        //function SpGetParamAsDateTime(SpHandle: Integer; ParamName: PChar;
        //  Var Day, Month, Year, Hour, Minute, Second: Word): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpGetParamAsDateTime(int SpHandle, string ParamName,
		ref ushort Day, ref ushort Month, ref ushort Year, ref ushort Hour, ref ushort Minute, ref ushort Second);

        // function SpGetParamAsInteger(SpHandle: Integer; ParamName: PChar;
        //   Var ParamValue: Integer): Integer; stdcall;
		[DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpGetParamAsInteger(int SpHandle, string ParamName,
		  ref int ParamValue);

        // function SpGetParamAsDouble(SpHandle: Integer; ParamName: PChar;
        // var ParamValue: Double): Integer; stdcall;
		[DllImport("ApiMicrosip.dll", SetLastError = true)]
        public static extern int SpGetParamAsDouble(int SpHandle, string ParamName,
		  ref Double ParamValue);

        //// Objeto semaforo
        //function NewSem(DBHandle: Integer): Integer; stdcall;
        [DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int NewSem(int DBHandle);

		//function SemCount: Integer; stdcall;
		[DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int SemCount();

		//function SemGetSemaforos(SemHandle: Integer; NombresSemaforos: PChar): Integer; stdcall;
		[DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int SemGetSemaforos(int SemHandle, string NombresSemaforos);

		//function SemRelSemaforos(SemHandle: Integer): Integer; stdcall;
		[DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int SemRelSemaforos(int SemHandle);

		//function SemGetSemaforoNoWait(SemHandle: Integer; NombreSemaforo: PChar):Integer; stdcall;
		[DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int SemGetSemaforoNoWait(int SemHandle, string NombreSemaforo);

		//function SemConfig(SemHandle, DBHandle: Integer): Integer; stdcall;}
		[DllImport("ApiMicrosip.dll", SetLastError = true)]
		public static extern int SemConfig(int SemHandle, int DBHandle);

       // Objeto Lista de parámetros 
	   //function NewPL: Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
	   public static extern int NewPL();

	   // function PLCount: Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
	   public static extern int PLCount();

	   // function PLParamCount (PLHandle: Integer; var ParamCount: Integer): Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
	   public static extern int PLParamCount(int PLHandle, ref int ParamCount);

	   //function PLSetParamValue (PLHandle: Integer; ParamName, ParamValue: PChar): Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
	   public static extern int PLSetParamValue (int PLHandle, string ParamName, string  ParamValue);

	   // function PLGetParamValue (PLHandle: Integer; ParamName, ParamValue: PChar): Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
	   public static extern int PLGetParamValue(int PLHandle, string ParamName, StringBuilder ParamValue);

	   // function PLGetParamName(PLHandle, Index: Integer; ParamName: PChar): Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
       public static extern int PLGetParamName(int PLHandle, int Index, StringBuilder ParamName);

	   // function PLDeleteParam (PLHandle: Integer; AParamName: PChar): Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
	   public static extern int PLDeleteParam (int PLHandle, string AParamName);

	   // function PLClear(PLHandle: Integer): Integer; stdcall;
	   [DllImport("ApiMicrosip.dll", SetLastError = true)]
	   public static extern int PLClear(int PLHandle);
	}
}