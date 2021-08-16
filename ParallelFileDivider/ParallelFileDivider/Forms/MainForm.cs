using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelFileDivider.Forms
{
    public partial class MainForm : Form
    {
        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            divideFileControl.ConfigureDependencies(serviceProvider);
            joinFilesControl1.ConfigureDependencies(serviceProvider);
        }
    }
}
