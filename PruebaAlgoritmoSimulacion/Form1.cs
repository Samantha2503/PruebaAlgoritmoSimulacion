using PruebaAlgoritmoSimulacion.Algoritmos;
using PruebaAlgoritmoSimulacion.Clases;
using System;


namespace PruebaAlgoritmoSimulacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Paso 0: condicion vacia
            Validaciones(textBox1.Text, textBox2.Text, textBox3.Text,textBox4.Text);

            //Paso 1: Inicializa parámetros
            int x = Convert.ToInt32(textBox1.Text);
            int c = Convert.ToInt32(textBox2.Text);
            int a = Convert.ToInt32(textBox3.Text);
            int mod = Convert.ToInt32(textBox4.Text);


            //Paso 2: llamar algoritmo
            GeneradorAleatorios generador = new GeneradorAleatorios();
            List<Asignacion> listaSalida = generador.CrearListaOrigen(x, c, a,mod);
            llenarGrid(listaSalida);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Validaciones(string w, string b, string z,string d)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("Los numeros deben ser mayores a 0");
                return;
            }
            int x = Convert.ToInt32(textBox1.Text);
            int c = Convert.ToInt32(textBox2.Text);
            int a = Convert.ToInt32(textBox3.Text);
            int mod = Convert.ToInt32(textBox4.Text);
            if ( x > 0 && a > 0 && c > 0 && mod > 0)
            {
                if (mod > a && mod > c && mod > x) { }
                else
                {
                    MessageBox.Show("m debe ser mayor a x, a y c");
                    return;
                }

            }

            else
            {

                MessageBox.Show("Los numeros tienen que ser MAYOR que cero");
                return;
            }




        }


        public void llenarGrid(List<Asignacion> lista)
        {
            //Paso 0: Indicas el número de columnas 
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";
            string numeroColumna3 = "3";
            //Paso 1: Determinas la cantidad de columnas 
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "X(n)");
            dataGridView1.Columns.Add(numeroColumna2, "a*X(n)+c");
            dataGridView1.Columns.Add(numeroColumna3, "[a*X(n)+c] mod m");
            //Paso 2: Recorrer el grid para cada fila y llenar de valores aleatorios
            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = (lista[i].IdPunto).ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = lista[i].Latitud.ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna3) - 1].Value = lista[i].Longitud.ToString();
            }
        }
        /*
        public void DescargaExcel(DataGridView data)
        {
            //Paso 0: Instalar completamente de excel
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;
            //Paso 1: Construyes columnas y los nombres de las "cabeceras"
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }
            //Paso 2: Construyes filas y llenas valores
            int indiceFilas = 0;
            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFilas++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFilas + 1, indiceColumna] = fila.Cells[columna.Name].Value;

                }
            }
            //Paso 3: visibilidad
            exportarExcel.Visible = true;
        }
        */
        public void DescargaCSV(DataGridView data)
        {
            // Paso 0: Definir la ruta donde se guardará el archivo CSV
            string filePath = @"C:\Users\Samantha\Desktop\files\file.csv"; // Cambia la ruta según sea necesario

            // Paso 1: Crear el archivo CSV y usar StreamWriter para escribir
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Paso 1.1: Escribir las cabeceras
                string[] columnHeaders = data.Columns.Cast<DataGridViewColumn>()
                    .Select(column => column.HeaderText)
                    .ToArray();
                writer.WriteLine(string.Join(",", columnHeaders));

                // Paso 2: Escribir las filas
                foreach (DataGridViewRow row in data.Rows)
                {
                    // Ignorar filas vacías
                    if (!row.IsNewRow)
                    {
                        string[] cellValues = row.Cells.Cast<DataGridViewCell>()
                            .Select(cell => cell.Value?.ToString().Replace(",", ";")).ToArray();
                        writer.WriteLine(string.Join(",", cellValues));
                    }
                }
            }

            // Mensaje de éxito
            MessageBox.Show("CSV exportado exitosamente en: " + filePath);
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DescargaCSV(dataGridView1);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

