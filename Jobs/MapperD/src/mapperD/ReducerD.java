package mapperD;


import java.io.IOException;

import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Reducer;

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

//Funcion reduce para el job D
//Cuenta la cantidad de errores para cada mes
public class ReducerD extends Reducer<Text, IntWritable, Text, IntWritable> {

public void reduce(Text key, Iterable<IntWritable> values, Context context)
	throws IOException {

	int ContadorErrores = 0;
	int ContadorErroresMayor = 0;
	
	try{
     	for (IntWritable cantidad : values) {
     		ContadorErrores += cantidad.get();
     		
   	     if(ContadorErrores > ContadorErroresMayor)	{
	    	 ContadorErroresMayor = ContadorErrores;
	     }
     	}
     	
        context.write(key,new IntWritable(ContadorErroresMayor));
     }
	 
	 catch(Exception e){
         e.printStackTrace();
     }
	}
}