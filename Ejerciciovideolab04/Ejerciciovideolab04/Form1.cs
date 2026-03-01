using Ejerciciovideolab04.Controllers;
using Ejerciciovideolab04.Entities;
using System;
using System.Windows.Forms;

namespace Ejerciciovideolab04
{
    public partial class Form1 : Form
    {
        //Llamar al controlador
        private AlumnoController alumnoController = new AlumnoController();
        public Form1()
        {
            InitializeComponent();
        }

        // Mostrar
        private void MostrarAlumnos(Alumno[] alumnos)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alumnos;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validar campos de entrada
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;

            }

            // Crear el alumno
            Alumno alumno = new Alumno()
            {
                Codigo = textBox1.Text,
                Nombre = textBox2.Text,
                Promedio = double.Parse(textBox3.Text)
            };

            // Registrar alumno en el arreglo
            alumnoController.Registrar(alumno);

            // Mostrar los alumnos
            MostrarAlumnos(alumnoController.ListarTodo());

            limpiarCampos();
                            

        }

        public void limpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar");
                return;
            }

            // Obtener el codigo

            String codigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            // Eliminar la fula seleccionada

            alumnoController.Eliminar(codigo);

            // Mostrar
            MostrarAlumnos(alumnoController.ListarTodo());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarAlumnos(alumnoController.Ordenar());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Validar Campo
            if (textBox4.Text == "")
            {
                MessageBox.Show("Ingrese el codigo a buscar");
                return;
            }

            // Obtener el codigo
            String codigo = textBox4.Text;

            // Mostrar los alumnos de la busqueda
            MostrarAlumnos(alumnoController.BuscarPorCodigo(codigo));

        }
    }
}
