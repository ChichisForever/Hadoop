using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graficador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobA.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CargarA_Click(object sender, EventArgs e)
        {
            //Conexion a la BD
           
                SqlConnection conexion;
                SqlCommand cmd;
                //SqlDataReader reader;
                conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
               conexion.Open();
              int counter = 0;
              string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobA.txt");
            while ((line = file.ReadLine()) != null)
            {
                char[] delimiterChars = { ',', ':',};
                string[] words = line.Split(delimiterChars);
                String casa = words[3];
                int numeroVeces = Int32.Parse(casa);
                String query = "INSERT INTO[Graficos].[dbo].[jobA]([producto],[version],[codigoError],[cantidadErrores]) VALUES('" + words[0] + "','" + words[1] + "','" + words[2] + "'," + numeroVeces + " )";
                try
                {
                    cmd = new SqlCommand(query,conexion);
                    cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops.Parece que tenemos un problema" + ex);
                }

                counter++;
            }

            file.Close();
            conexion.Close();
//Cargar combox de productos
            SqlConnection conexion2;
            SqlCommand cmd2;
            SqlDataReader reader;
            conexion2 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion2.Open();
            String query2 = "Select DISTINCT producto from Graficos.dbo.jobA ";
            cmd2= new SqlCommand(query2, conexion2);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                ProdA.Items.Add(reader[0]);
            }
            reader.Close();
            conexion2.Close();
//Cargar combox de versiones
            SqlConnection conexion3;
            SqlCommand cmd3;
            SqlDataReader reader3;
            conexion3 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion3.Open();
            String query3 = "Select DISTINCT version from Graficos.dbo.jobA";
            cmd3 = new SqlCommand(query3, conexion3);
            reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                VerA.Items.Add(reader3[0]);
            }
            reader3.Close();
            conexion3.Close();


        }

        private void ProdA_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }

        private void JobA_Click(object sender, EventArgs e)
        {
            graficoA.Series.Clear();
 
            SqlConnection conexion;
            SqlCommand cmd;
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            String query = "Select codigoError, cantidadErrores from jobA where producto = '"+ProdA.Text+"' and version = '"+VerA.Text+"'";
            MessageBox.Show(query);
            try
            {
                cmd = new SqlCommand(query, conexion);
                reader = cmd.ExecuteReader();
                
                //Crear Grafico
                while (reader.Read())
                {
                    Series series = graficoA.Series.Add(reader[0].ToString());
                    series.Label = reader[1].ToString();
                    int num = Int32.Parse(reader[1].ToString());
                    series.Points.Add(num);
                }
                reader.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("error" +ex);
            }
                conexion.Close();
        }

        private void CargarB_Click(object sender, EventArgs e)
        {
            //Conexion a la BD

            SqlConnection conexion;
            SqlCommand cmd;
            //SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobB.txt");
            while ((line = file.ReadLine()) != null)
            {
                char[] delimiterChars = { ',', ':', };
                string[] words = line.Split(delimiterChars);
                String casa = words[4];
                int numeroVeces = Int32.Parse(casa);
                String query = "INSERT INTO[Graficos].[dbo].[jobB]([producto],[version],[mes],[codigoError],[cantidadErrores]) VALUES('" + words[0] + "','" + words[1] + "','" + words[2] + "','"+words[3]+"'," + numeroVeces + " )";
                try
                {
                    cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops.Parece que tenemos un problema" + ex);
                }

                counter++;
            }

            file.Close();
            conexion.Close();
            //Cargar combox de productos
            SqlConnection conexion2;
            SqlCommand cmd2;
            SqlDataReader reader;
            conexion2 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion2.Open();
            String query2 = "Select DISTINCT producto from Graficos.dbo.jobB ";
            cmd2 = new SqlCommand(query2, conexion2);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                ProdB.Items.Add(reader[0]);
            }
            reader.Close();
            conexion2.Close();
            //Cargar combox de versiones
            SqlConnection conexion3;
            SqlCommand cmd3;
            SqlDataReader reader3;
            conexion3 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion3.Open();
            String query3 = "Select DISTINCT version from Graficos.dbo.jobB";
            cmd3 = new SqlCommand(query3, conexion3);
            reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                VerB.Items.Add(reader3[0]);
            }
            reader3.Close();
            conexion3.Close();

            //Cargar combox de mes
            SqlConnection conexion4;
            SqlCommand cmd4;
            SqlDataReader reader4;
            conexion4 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion4.Open();
            String query4 = "Select DISTINCT mes from Graficos.dbo.jobB";
            cmd4 = new SqlCommand(query4, conexion4);
            reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                MesB.Items.Add(reader4[0]);
            }
            reader4.Close();
            conexion4.Close();


        }

        private void jobB_Click(object sender, EventArgs e)
        {

            graficoB.Series.Clear();

            SqlConnection conexion;
            SqlCommand cmd;
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int mes = Int32.Parse(MesB.Text);
            String query = "Select codigoError, cantidadErrores from Graficos.dbo.jobB where producto= '"+ProdB.Text+"' and version= '"+VerB.Text+"'and mes = "+mes;
           
            try
            {
                cmd = new SqlCommand(query, conexion);
                reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    Series series = graficoB.Series.Add(reader[0].ToString());
                    series.Label = reader[1].ToString();
                    int num = Int32.Parse(reader[1].ToString());
                    series.Points.Add(num);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            conexion.Close();
        }

        private void cargarC_Click(object sender, EventArgs e)
        {

            //Conexion a la BD

            SqlConnection conexion;
            SqlCommand cmd;
            //SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobC.txt");
            while ((line = file.ReadLine()) != null)
            {
                char[] delimiterChars = { ',', ':', };
                string[] words = line.Split(delimiterChars);
                String casa = words[3];
                int numeroVeces = Int32.Parse(casa);
                String query = "INSERT INTO[Graficos].[dbo].[jobC]([producto],[mes],[codigoError],[cantidadErrores]) VALUES('" + words[0] + "','" + words[1] + "','" + words[2] + "',"+ numeroVeces + " )";
                try
                {
                    cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops.Parece que tenemos un problema" + ex);
                }

                counter++;
            }

            file.Close();
            conexion.Close();
            //Cargar combox de productos
            SqlConnection conexion2;
            SqlCommand cmd2;
            SqlDataReader reader;
            conexion2 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion2.Open();
            String query2 = "Select DISTINCT producto from Graficos.dbo.jobC ";
            cmd2 = new SqlCommand(query2, conexion2);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                ProdC.Items.Add(reader[0]);
            }
            reader.Close();
            conexion2.Close();
            

            //Cargar combox de mes
            SqlConnection conexion4;
            SqlCommand cmd4;
            SqlDataReader reader4;
            conexion4 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion4.Open();
            String query4 = "Select DISTINCT mes from Graficos.dbo.jobC";
            cmd4 = new SqlCommand(query4, conexion4);
            reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                MesC.Items.Add(reader4[0]);
            }
            reader4.Close();
            conexion4.Close();


        }

        private void jobC_Click(object sender, EventArgs e)
        {
            graficoC.Series.Clear();

            SqlConnection conexion;
            SqlCommand cmd;
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int mes = Int32.Parse(MesC.Text);
            String query = "Select codigoError, cantidadErrores from Graficos.dbo.jobC where producto= '" + ProdC.Text + "'and mes = " + mes;

            try
            {
                cmd = new SqlCommand(query, conexion);
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Series series = graficoC.Series.Add(reader[0].ToString());
                    series.Label = reader[1].ToString();
                    int num = Int32.Parse(reader[1].ToString());
                    series.Points.Add(num);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            conexion.Close();
        }

        private void CargarD_Click(object sender, EventArgs e)
        {
            //Conexion a la BD

            SqlConnection conexion;
            SqlCommand cmd;
            //SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobD.txt");
            while ((line = file.ReadLine()) != null)
            {
                char[] delimiterChars = { ',', ':', };
                string[] words = line.Split(delimiterChars);
                String casa = words[2];
                int numeroVeces = Int32.Parse(casa);
                String query = "INSERT INTO[Graficos].[dbo].[jobD]([mes],[codigoError],[cantidadErrores]) VALUES('" + words[0] + "','" + words[1] + "'," + numeroVeces + " )";
                try
                {
                    cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops.Parece que tenemos un problema" + ex);
                }

                counter++;
            }

            file.Close();
            conexion.Close();


            //Cargar combox de mes
            SqlConnection conexion4;
            SqlCommand cmd4;
            SqlDataReader reader4;
            conexion4 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion4.Open();
            String query4 = "Select DISTINCT mes from Graficos.dbo.jobD";
            cmd4 = new SqlCommand(query4, conexion4);
            reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {
                MesD.Items.Add(reader4[0]);
            }
            reader4.Close();
            conexion4.Close();

        }

        private void jobD_Click(object sender, EventArgs e)
        {
            graficoD.Series.Clear();

            SqlConnection conexion;
            SqlCommand cmd;
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int mes = Int32.Parse(MesD.Text);
            String query = "Select codigoError, cantidadErrores from Graficos.dbo.jobC where mes = " + mes;

            try
            {
                cmd = new SqlCommand(query, conexion);
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Series series = graficoD.Series.Add(reader[0].ToString());
                    series.Label = reader[1].ToString();
                    int num = Int32.Parse(reader[1].ToString());
                    series.Points.Add(num);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            conexion.Close();
        }

        private void CargarE_Click(object sender, EventArgs e)
        {
            //Conexion a la BD

            SqlConnection conexion;
            SqlCommand cmd;
            //SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobE.txt");
            while ((line = file.ReadLine()) != null)
            {
                char[] delimiterChars = { ',', ':', };
                string[] words = line.Split(delimiterChars);
                String casa = words[2];
                int numeroVeces = Int32.Parse(casa);
                String query = "INSERT INTO[Graficos].[dbo].[jobE]([producto],[version],[cantidadErrores]) VALUES('" + words[0] + "','" + words[1] + "'," + numeroVeces + " )";
                try
                {
                    cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops.Parece que tenemos un problema" + ex);
                }

                counter++;
            }

            file.Close();
            conexion.Close();
            //Cargar combox de productos
            SqlConnection conexion2;
            SqlCommand cmd2;
            SqlDataReader reader;
            conexion2 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion2.Open();
            String query2 = "Select DISTINCT producto from Graficos.dbo.jobE ";
            cmd2 = new SqlCommand(query2, conexion2);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                ProdE.Items.Add(reader[0]);
            }
            reader.Close();
            conexion2.Close();
        }

        private void jobE_Click(object sender, EventArgs e)
        {
            graficoE.Series.Clear();

            SqlConnection conexion;
            SqlCommand cmd;
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            String query = "Select version, cantidadErrores from Graficos.dbo.jobE where producto = '" + ProdE.Text + "'";
            
            try
            {
                cmd = new SqlCommand(query, conexion);
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Series series = graficoE.Series.Add(reader[0].ToString());
                    series.Label = reader[1].ToString();
                    int num = Int32.Parse(reader[1].ToString());
                    series.Points.Add(num);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            conexion.Close();
        }

        private void CargarF_Click(object sender, EventArgs e)
        {
            //Conexion a la BD

            SqlConnection conexion;
            SqlCommand cmd;
            //SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobF.txt");
            while ((line = file.ReadLine()) != null)
            {
                char[] delimiterChars = { ',', ':', };
                string[] words = line.Split(delimiterChars);
                String casa = words[2];
                int numeroVeces = Int32.Parse(casa);
                String query = "INSERT INTO[Graficos].[dbo].[jobF]([producto],[codigoError],[cantidadErrores]) VALUES('" + words[0] + "','" + words[1] + "'," + numeroVeces + " )";
                try
                {
                    cmd = new SqlCommand(query, conexion);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ops.Parece que tenemos un problema" + ex);
                }

                counter++;
            }

            file.Close();
            conexion.Close();
            //Cargar combox de productos
            SqlConnection conexion2;
            SqlCommand cmd2;
            SqlDataReader reader;
            conexion2 = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion2.Open();
            String query2 = "Select DISTINCT producto from Graficos.dbo.jobF ";
            cmd2 = new SqlCommand(query2, conexion2);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                ProdF.Items.Add(reader[0]);
            }
            reader.Close();
            conexion2.Close();
        }

        private void jobF_Click(object sender, EventArgs e)
        {
            graficoF.Series.Clear();

            SqlConnection conexion;
            SqlCommand cmd;
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            String query = "Select codigoError, cantidadErrores from Graficos.dbo.jobF where producto = '" + ProdF.Text + "'";

            try
            {
                cmd = new SqlCommand(query, conexion);
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Series series = graficoF.Series.Add(reader[0].ToString());
                    series.Label = reader[1].ToString();
                    int num = Int32.Parse(reader[1].ToString());
                    series.Points.Add(num);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            conexion.Close();
        }

        private void CaregarG_Click(object sender, EventArgs e)
        {
            //Conexion a la BD

            SqlConnection conexion;
            SqlCommand cmd;
            //SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Nelson\Documents\Visual Studio 2015\Projects\Graficador\Hadoop\JobG.txt");
            while ((line = file.ReadLine()) != null)
            {
                char[] delimiterChars = { ',', ':', };
                string[] words = line.Split(delimiterChars);
                
                    String query = "INSERT INTO[Graficos].[dbo].[jobG]([codigoError],[errorStack]) VALUES('" + words[0] + "','" + words[1] + "')";
                    try
                    {
                        cmd = new SqlCommand(query, conexion);
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ops.Parece que tenemos un problema" + ex);
                    }
                }
                counter++;
            

            file.Close();
            conexion.Close();
            
        }

        private void jobG_Click(object sender, EventArgs e)
        {
            SqlConnection conexion;
            SqlCommand cmd;
            SqlDataReader reader;
            conexion = new SqlConnection("Data Source=.;Initial Catalog=" + "Graficos" + ";Integrated Security=True");
            conexion.Open();
            String query = "select codigoError from Graficos.dbo.jobG where errorStack !='	NULL'";
            try
            {
                cmd = new SqlCommand(query, conexion);
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    listBoxG.Items.Add(reader[0]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            conexion.Close();

        }
    }
}



