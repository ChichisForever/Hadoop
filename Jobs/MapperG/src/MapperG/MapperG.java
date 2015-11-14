package MapperG;

import java.io.IOException;
import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Mapper;
import org.json.JSONObject;

public class MapperG extends Mapper<LongWritable, Text, Text, Text> {
	
    public void map(LongWritable key, Text value, Context context) throws IOException, InterruptedException {
    	
    	String errorStack;
    	String codigoerror;

        String linea = value.toString();
        String[] lineasjson = linea.split("\\n");
       
        try{
        	for(int i = 0; i < lineasjson.length; i++){
        		
                JSONObject obj = new JSONObject(lineasjson[i]);
                errorStack = obj.getString("errorStact");
                codigoerror = obj.getString("errorCode");
                
                context.write(new Text(codigoerror + ":"), new Text(errorStack));
            }
        }
        
        catch(Exception e){
            e.printStackTrace();
        }
    }    
}

	
