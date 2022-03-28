namespace Multiplication_table_generator
{
    public partial class Form1 : Form
    {
        private int currentTableRowAndColumns { get; set; }
        private List<string> columns = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentTableRowAndColumns = 0;
            listView1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetListView();
            addColumnsToListView();
            plotMultiplicationTableBaseOnUserInput();
        }

        private void resetListView()
        {
            listView1.Items.Clear();

            if (currentTableRowAndColumns > 0)
            {
                for (int i = currentTableRowAndColumns; i <= 0; i--)
                {
                    listView1.Columns.RemoveAt(i);
                }
            }
        }

        private void addColumnsToListView()
        {
            var input = String.IsNullOrEmpty(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text);

            currentTableRowAndColumns = input;

            if (currentTableRowAndColumns == 0) return;

            for (int i = 0; i <= currentTableRowAndColumns; i++)
            {
                if (i == 0) columns.Add("");
                else columns.Add(i.ToString());
            }

            foreach (var item in columns)
            {
                listView1.View = View.Details;
                listView1.Columns.Add(item);
            }
        }

        private void plotMultiplicationTableBaseOnUserInput()
        {
            if (currentTableRowAndColumns == 0) return;

            for (int row = 0; row <= currentTableRowAndColumns; row++)
            {
                var listViewItem = new ListViewItem(row.ToString());

                for (int column = 1; column <= currentTableRowAndColumns; column++)
                {
                    if (row == 0) listViewItem.SubItems.Add(((row + 1) * column).ToString());

                    else listViewItem.SubItems.Add((row * column).ToString());
                }

                listView1.Items.Add(listViewItem);
            }
        }
    }
}