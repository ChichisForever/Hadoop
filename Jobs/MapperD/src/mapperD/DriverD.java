package mapperD;

import org.apache.hadoop.conf.Configuration;
import org.apache.hadoop.fs.Path;
import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Job;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;

/*
 * Instituto Tecnologico de Costa Rica
 * Bases de Datos II
 * Tarea programada #2
 * II Semestre 2015
 * 
 * Estudiantes:
 * Nelson Abarca Quiros
 * Liza Chavez Carranza
 * Melissa Molina Corrales
 * Amanda Solano Astorga
 * 
 */


//Funcion encargada de correr el job con las funciones map y reduce
public class DriverD{

	public static void main(String[] args) throws Exception {
		//Valida que los dos argumentos sean pasados desde la linea de comandos.
		String input, output;
		if (args.length == 2) {
			input = args[0];
			output = args[1];
		} else {
			System.err.println("Incorrect number of arguments.  Expected: input output");
			return;
		}
		
		//Crea una instancia Job basada en una configuracion
		Configuration conf = new Configuration();
		Job job = Job.getInstance(conf);
		
		// Dar un nombre al job. Este nombre sera usado en los reportes y logs.
		job.setJobName("ErroresComunesC"); 
		 
		//Especificar los archivos jar que contiene el driver, mapper y reducer
		//Este jar sera copiado a todos los nodos en un cluster, asi estos podran ser corridos como mapper o reducer tasks
		job.setJarByClass(DriverD.class);
		
		//Especificar las clases en donde estan las funciones map y reduce
		job.setMapperClass(MapperD.class);
		//job.setCombinerClass(ReducerA.class);
		job.setReducerClass(ReducerD.class);
		
		//Especificar el formato de la salida del mapper y del reducer
		job.setMapOutputKeyClass(Text.class);
		job.setMapOutputValueClass(IntWritable.class);
		job.setOutputKeyClass(Text.class);
		job.setOutputValueClass(IntWritable.class);		
		
		//Especificar las rutas de entrada y salida
		FileInputFormat.setInputPaths(job, new Path(input));
		FileOutputFormat.setOutputPath(job, new Path(output));

		//Inicia el job y se espera hasta que este haya terminado
		//Si termina satisfactoriamente retornara un 0 de lo contrario un 1.
		boolean success = job.waitForCompletion(true);
		System.exit(success ? 0 : 1);
	}
}

