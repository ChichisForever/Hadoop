package MapperG;

import java.io.*;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Reducer;

public class ReducerG extends Reducer<Text, Text, Text, Text> {

	public void reduce(Text key, Iterable<Text> values, Context context) throws IOException {
	
		String resultado = "";
		boolean containsio;
		boolean containsdisk;
		
		try {
			for (Text stack : values){
				
				containsio = stack.toString().matches("(?i).*I/O.*");
				containsdisk = stack.toString().matches("(?i).*disk.*");
				
				if (containsio == true && containsdisk == true) {
					resultado += stack.toString();
					resultado += ",";
				}
			}
			
		if (resultado == ""){
			resultado += "NULL";
			context.write(key, new Text(resultado));
		}
		else {
			context.write(key, new Text(resultado));
		}
				
		}
		
		catch(Exception e){
			e.printStackTrace();
	    }
	}
}