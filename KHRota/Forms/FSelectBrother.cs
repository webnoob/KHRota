﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KHRota.Classes;
using KHRota.Services;

namespace KHRota.Forms
{
    public partial class FSelectBrother : Form
    {
        private readonly BrotherService _brotherService;
        private ICollection<Brother> _allowedBrothers;

        public Brother Brother { get; set; }
        
        public FSelectBrother(List<Brother> allowedBrothers)
        {
            _brotherService = new BrotherService();
            _allowedBrothers = allowedBrothers;

            InitializeComponent();
            
            LoadBrotherList(null);
        }

        private void LoadBrotherList(Brother brother)
        {
            var brothersToBind = new List<Brother>();
            brothersToBind.AddRange(_allowedBrothers.OrderBy(b => b.FirstName).ThenBy(b => b.LastName));
            cbEditBrother.DataSource = brothersToBind;
            cbEditBrother.DisplayMember = "FullName";
            cbEditBrother.ValueMember = "Guid";

            if (brother != null)
                cbEditBrother.SelectedItem = brother;
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            Brother = cbEditBrother.SelectedItem as Brother;
            DialogResult = DialogResult.OK;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
