/*
 * This program is licensed by Lrn2Network under a Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License. 
 * You may obtain a copy of the license at: http://creativecommons.org/licenses/by-nc-sa/3.0/.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkypeBase
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        static MainForm instance;
        public static MainForm Instance { get { return instance; } }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            instance = this;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            instance = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SkypeBot sb = new SkypeBot();
        }
    }
}
