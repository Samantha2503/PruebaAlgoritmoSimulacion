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
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Los numeros deben ser mayores a 0");
            }

            //Paso 1: Inicializa par�metros
            int puntosTotales = Convert.ToInt32(textBox1.Text);
            int maximo = Convert.ToInt32(textBox2.Text);
            int minimo = Convert.ToInt32(textBox3.Text);

            //Paso 2: llamar algoritmo
            GeneradorAleatorios generador = new GeneradorAleatorios();
            List<Asignacion> listaSalida = generador.CrearListaOrigen(puntosTotales, minimo, maximo);
            llenarGrid(listaSalida);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void llenarGrid(List<Asignacion> lista)
        {
            //Paso 0: Indicas el n�mero de columnas 
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";
            string numeroColumna3 = "3";
            //Paso 1: Determinas la cantidad de columnas 
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Id");
            dataGridView1.Columns.Add(numeroColumna2, "Latitud");
            dataGridView1.Columns.Add(numeroColumna3, "Longitud");
            //Paso 2: Recorrer el grid para cada fila y llenar de valores aleatorios
            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = (lista[i].IdPunto).ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna2) - 1].Value = lista[i].Latitud.ToString();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna3) - 1].Value = lista[i].Longitud.ToString();
            }
        }

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

