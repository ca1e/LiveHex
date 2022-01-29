namespace USP.Plugins
{
    public partial class ItemShow : DataUserControl
    {
        public override byte[] Data { get => v; set => v = value; }

        private byte[] v = new byte[4];

        public ItemShow()
        {
            InitializeComponent();

            numericUpDown1.DataBindings.Add("Value", v, "Hu");
            textBox1.DataBindings.Add("Text", v, "Hu");
        }
    }
}
