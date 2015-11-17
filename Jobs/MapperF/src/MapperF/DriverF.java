package MapperF;

import org.apache.hadoop.conf.Configuration;
import org.apache.hadoop.fs.Path;
import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Job;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;

public class DriverF {

	public static void main(String[] args) throws Exception {
		// Validate that two arguments were passed from the command line.
		String input, output;
		if (args.length == 2) {
			input = args[0];
			output = args[1];
		} else {
			System.err.println("Incorrect number of arguments.  Expected: input output");
			return;
		}
		
		// Create a instance of Job, based on a configuration
		Configuration conf = new Configuration();
		Job job = Job.getInstance(conf);
		
		// Give the job a name.  This name will be used in the reports and logs.
		job.setJobName("ErroresComunesA"); 
		 
		// Specify the jar files that contains the driver, mapper and reducer
		// This jar will be copied to all the nodes in the cluster, so that they 
		// can run as mapper or reducer tasks
		job.setJarByClass(DriverF.class);
		
		// Specify the mapper and reducer classes
		job.setMapperClass(MapperF.class);
		//job.setCombinerClass(ReducerA.class);
		job.setReducerClass(ReducerF.class);
		
		// Specify the format of the output of the mapper and the reducer
		job.setMapOutputKeyClass(Text.class);
		job.setMapOutputValueClass(IntWritable.class);
		job.setOutputKeyClass(Text.class);
		job.setOutputValueClass(IntWritable.class);		
		
		// Specify the paths for the input and output
		FileInputFormat.setInputPaths(job, new Path(input));
		FileOutputFormat.setOutputPath(job, new Path(output));

		// Start the job and wait for it to finish.
		// If it finishes successfully return a 0, otherwise a 1.
		boolean success = job.waitForCompletion(true);
		System.exit(success ? 0 : 1);
	}
}

