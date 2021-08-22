using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelFileDivider.Components
{
    public partial class MultiWorkersProgressControl : UserControl
    {
        public Color MainBorderColor { get; set; } = Color.Black;
        public Color DivisionBorderColor { get; set; } = Color.Blue;
        public Brush ProgressFillBrush { get; set; } = Brushes.Green;
        public int VerticalPadding { get; set; } = 10;
        public bool IsMeshVisible { get; set; } = false;
        public bool AreDividersVisible { get; set; } = true;

        private int[] _values { get; set; } = new int[100];
        private int _maxValue { get; set; } = 100;

        public MultiWorkersProgressControl()
        {
            InitializeComponent();

            DoubleBuffered = true;
        }

        public void UpdateProgress(int[] values, int maxValue)
        {
            _values = values;
            _maxValue = maxValue;
            Invalidate();
        }

        private void MultiWorkersProgressControl_Paint(object sender, PaintEventArgs e)
        {
            var barsCount = _values.Length;
            var bordersCount = barsCount + 1;

            var bottom = Height - VerticalPadding;
            var barWidth = (Width - bordersCount - 0f) / barsCount;
            DrawProgressBars(e.Graphics, bottom, barWidth);

            if (IsMeshVisible)
            {
                DrawMesh(e.Graphics);
            }
        }

        private void DrawProgressBars(Graphics g, int bottom, float barWidth)
        {
            var barMaxHeight = Height - 2 * VerticalPadding - 2;

            var left = 1f;
            for (var i = 0; i < _values.Length; i++, left += barWidth + 1)
            {
                var barHeight = _values[i] * barMaxHeight / _maxValue;
                g.FillRectangle(ProgressFillBrush, left, bottom - barHeight, barWidth, barHeight);

                if (AreDividersVisible)
                {
                    g.DrawRectangle(new Pen(DivisionBorderColor), left, bottom - barHeight, barWidth, barHeight);
                }
            }
        }

        private void DrawMesh(Graphics g)
        {
            var top = VerticalPadding;
            g.DrawRectangle(new Pen(MainBorderColor), 0, top, Width - 1, Height - 2 * VerticalPadding);
        }
    }
}
