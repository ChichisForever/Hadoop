package MapperF;

import java.io.IOException;
import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Reducer;

public class ReducerF extends Reducer<Text, IntWritable, Text, IntWritable> {

public void reduce(Text key, Iterable<IntWritable> values, Context context)
	throws IOException {

	int ContadorErrores = 0;
	
	try{
     	for (IntWritable cantidad : values) {
     		ContadorErrores += cantidad.get();
     	}    	
        context.write(key, new IntWritable(ContadorErrores));
     }
	 
	 catch(Exception e){
         e.printStackTrace();
     }
	}
}