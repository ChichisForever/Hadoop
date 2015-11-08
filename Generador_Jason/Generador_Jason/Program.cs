using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Generador_Jason
{
    class Program
    {
        static void Main(string[] args)
        {
            Random num = new Random();

            //Lista donde van los Logs
            List<Log> _data = new List<Log>();
            //Lista donde van los productos
            List<String> productos = new List<string>();
            productos.Add("Oracle Database");
            productos.Add("SQL Server");

            //Lista de versiones
            List<String> versiones = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                int generado = num.Next(10);
                versiones.Add(generado.ToString());
            }

            //Lista de codigos de error
            List<Error> errores_oracle = new List<Error>();
            errores_oracle.Add(new Error("ORA-00001", "unique constraint (string.string) violated"));
            errores_oracle.Add(new Error("ORA-00017","session requested to set trace event"));
            errores_oracle.Add(new Error("ORA-00018", "maximum number of sessions exceeded"));
            errores_oracle.Add(new Error("ORA-00019", "maximum number of session licenses exceeded"));
            errores_oracle.Add(new Error("ORA-00020", "maximum number of processes (string) exceeded"));
            errores_oracle.Add(new Error("ORA-00021", "session attached to some other process; cannot switch session"));
            errores_oracle.Add(new Error("ORA-00022", "invalid session ID; access denied"));
            errores_oracle.Add(new Error("ORA-00023", "session references process private memory; cannot detach session"));
            errores_oracle.Add(new Error("ORA-12401", "invalid label string: string"));
            errores_oracle.Add(new Error("ORA-12400","invalid argument to facility error handling"));
            errores_oracle.Add(new Error("ORA-12402", "invalid format string: string"));
            errores_oracle.Add(new Error("ORA-12404","invalid privilege string: string"));
            errores_oracle.Add(new Error("ORA-12405","invalid label list"));
            errores_oracle.Add(new Error("ORA-12406","unauthorized SQL statement for policy string"));
            errores_oracle.Add(new Error("ORA-12407","unauthorized operation for policy string"));
            errores_oracle.Add(new Error("ORA-12408"," unsupported operation string"));
            errores_oracle.Add(new Error("ORA-12410"," internal policy error for policy: string Error: string"));
            errores_oracle.Add(new Error("ORA-12411"," invalid label value"));
            errores_oracle.Add(new Error("ORA-12412"," policy package string is not installed"));
            errores_oracle.Add(new Error("ORA-12413"," labels do not belong to the same policy"));

            List<Error> errores_sql = new List<Error>();
            errores_sql.Add(new Error("101", "Query not allowed in Waitfor"));
            errores_sql.Add(new Error("102", "Incorrect syntax near '%.*ls'."));
            errores_sql.Add(new Error("103", "The %S_MSG that starts with '%.*ls' is too long. Maximum length is %d."));
            errores_sql.Add(new Error("104", "ORDER BY items must appear in the select list if the statement contains a UNION, INTERSECT or EXCEPT operator."));
            errores_sql.Add(new Error("105", "Unclosed quotation mark after the character string '%.*ls'."));
            errores_sql.Add(new Error("106", "Too many table names in the query. The maximum allowable is %d."));
            errores_sql.Add(new Error("107", "The column prefix '%.*ls' does not match with a table name or alias name used in the query."));
            errores_sql.Add(new Error("108", "The ORDER BY position number %ld is out of range of the number of items in the select list."));
            errores_sql.Add(new Error("19030", "SQL Trace ID % d was started by login %s"));
            errores_sql.Add(new Error("19031", "SQL Trace stopped. Trace ID = '%d'. Login Name = '%s'."));
            errores_sql.Add(new Error("19032", "SQL Trace was stopped due to server shutdown.Trace ID = '%d'.This is an informational message only; no user action is required."));
            errores_sql.Add(new Error("19033", "Server started with '-f' option. Auditing will not be started. This is an informational message only; no user action is required."));
            errores_sql.Add(new Error("19034", "Cannot start C2 audit trace. SQL Server is shutting down. Error = %ls"));
            errores_sql.Add(new Error("19035", "OLE task allocator failed to initialize. Heterogeneous queries, distributed queries, and remote procedure calls are unavailable. Confirm that DCOM is properly installed and configured."));
            errores_sql.Add(new Error("19036", "The OLE DB initialization service failed to load. Reinstall Microsoft Data Access Components. If the problem persists, contact product support for the OLEDB provider."));
            errores_sql.Add(new Error("19051", "Unknown error occurred in the trace."));
            errores_sql.Add(new Error("19052", "The active trace must be stopped before modification."));
            errores_sql.Add(new Error("19053", "The trace event ID is not valid."));
            errores_sql.Add(new Error("19054", "The trace column ID is not valid."));
            errores_sql.Add(new Error("19055", "Filters with the same event column ID must be grouped together."));

            List<String> stack = new List<string>();
            stack.Add("Can not access to the disk");
            stack.Add("Problems reading an write files");
            stack.Add("File do not found");
            stack.Add("Problems of I/O of the disk");
            stack.Add("Not fount I/O parameters");
            stack.Add("No internet access");
            stack.Add("Error en la linea 2 del procedimiento");
            stack.Add("Error en la linea 2 de la funcion");
            stack.Add("Error en la linea 3 del procedimiento");
            stack.Add("Error en la linea 3 de la funcion");
            stack.Add("Error en la linea 4 del procedimiento");
            stack.Add("Error en la linea 4 de la funcion");


            Console.WriteLine("Procesando");
            for (int i = 0; i < 499999; i++)
            {
                int valor_actual = i + 1;
                Console.WriteLine("Escribiendo archivo #" +valor_actual.ToString());
                String fecha = num.Next(1995, 2015).ToString() + "-" + num.Next(1, 12).ToString() + "-" + num.Next(1, 28);
                DateTime tiempo = DateTime.Parse(fecha);

                String producto = productos[num.Next(0, 1)];
                Error error;
                if (producto == "Oracle")
                {
                    error = errores_oracle[num.Next(0, 19)];
                }
                else
                {
                    error = errores_sql[num.Next(0, 19)];
                }
                _data.Add(new Log(tiempo, producto, versiones[num.Next(0, 9)].ToString(), error.codigo, error.mensaje, stack[num.Next(0,11)]));
                String json = JsonConvert.SerializeObject(_data.ToArray());
                //Cambiar direccion.
                String path = @"D:\JSON\log" + i + ".json";
                System.IO.File.WriteAllText(path,json);
                _data.Clear();

                Console.WriteLine("Subiendo archivo");
                service.WebServiceSoapClient ser = new service.WebServiceSoapClient();
                //Crear carpeta en la maquina virtual en cloudera llamada JSON,cambiar solamente la direccion ip
                string estado = ser.UploadFileToFtp("ftp://192.168.1.6/JSON/", path);
                Console.WriteLine(estado);

                

            }
            

            

            Console.WriteLine("Listo");
            Console.Read();
        }
    }
}
