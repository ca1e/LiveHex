using USP.Core;

namespace USP.Plugins
{
    public partial class DigiShow : DataUserControl
    {
        public override byte[] Data { get => vd.Bytes; set => vd.HumanValue = new ValueData(value, _vt).HumanValue; }

        private ValueData vd;

        private ValueType _vt;
        public DigiShow(ValueType vt)
        {
            InitializeComponent();

            _vt = vt;
            vd = new ValueData(null, vt);

            resultBox.DataBindings.Add("Text", vd, "HumanValue");
        }
    }
}
