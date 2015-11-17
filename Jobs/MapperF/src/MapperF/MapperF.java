package MapperF;

import java.io.IOException;

import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Mapper;
import org.json.JSONObject;

public class MapperF extends Mapper<LongWritable, Text, Text, IntWritable> {
	
    public void map(LongWritable key, Text value, Context context) throws IOException, InterruptedException {
    	
    	String producto;
    	String codigoerror;

        String linea = value.toString();
        String[] lineasjson = linea.split("\\n");
       
        try{
        	for(int i = 0; i < lineasjson.length; i++){
        		
                JSONObject obj = new JSONObject(lineasjson[i]);
                producto = obj.getString("product");
                codigoerror = obj.getString("errorCode");
                
                context.write(new Text(producto + "," + codigoerror + ":"), new IntWritable(1));
            }
        }
        
        catch(Exception e){
            e.printStackTrace();
        }
    }    
}

	
