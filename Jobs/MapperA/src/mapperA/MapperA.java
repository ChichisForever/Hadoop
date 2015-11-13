package mapperA;

import java.io.IOException;

import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Mapper;
import org.json.JSONObject;

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

//Funcion map para el job A
public class MapperA extends Mapper<LongWritable, Text, Text, IntWritable> {
	
    public void map(LongWritable key, Text value, Context context) throws IOException, InterruptedException {
    	
    	String producto;
    	String version;
    	String codigoerror;

        String linea = value.toString();
        String[] lineasjson = linea.split("\\n");
       
        try{
        	for(int i = 0; i < lineasjson.length; i++){
        		
                JSONObject obj = new JSONObject(lineasjson[i]);
                producto = obj.getString("product");
                version= obj.getString("version");
                codigoerror = obj.getString("errorCode");
                
                context.write(new Text(producto + "," + version + "," +  codigoerror+":"), new IntWritable(1));
            }
        }
        
        catch(Exception e){
            e.printStackTrace();
        }
    }    
}

	
