using connectionDb;


namespace Clientes

{
    public partial class Form1 : Form
    {
        classClienterData data = new classClienterData();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = data.getClientes();
            data.getCuidades(comboBox1);
         


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string item = comboBox1.Text;

            if (item != "")
            {

                if (rbEstadoActivo.Checked == true )
                {

                    dataGridView1.DataSource = data.getClientesAC(item, "activo");

                }else if (rbEstadoDesactivo.Checked == true)
                {
                    dataGridView1.DataSource = data.getClientesAC(item,"desactivo");


                }
                else
                {

                dataGridView1.DataSource = data.getClientesCuiades(item);
                }



            }
            else if(rbEstadoActivo.Checked == true)
            {
                dataGridView1.DataSource = data.getClientesEstadoActivo();

            }
            else if (rbEstadoDesactivo.Checked == true)
            {
                dataGridView1.DataSource = data.getClientesDesactivo();

            }
            else
            {
                dataGridView1.DataSource = data.getClientes();

            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {

            rbEstadoActivo.Checked = false;
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = data.getClientes();

        }



    }
}