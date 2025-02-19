﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using awayDayPlanner.GUI.Presenter.ControlPanel;
using awayDayPlanner.Source.Activities;

namespace awayDayPlanner.GUI.View.NewItem
{
    public partial class AddNewItem : Form, IAddNewItem
    {
        public AddNewItem()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void addNewItem_Load(object sender, EventArgs e)
        {
            txtCustomActivity.Enabled = false;
            txtCustomActivity.TabStop = false;
            txtCustomActivity.Text = "";
            txtNotes.Text = "";

            if (cmbxActivity.Items.Count > 0)
            {
                cmbxActivity.SelectedIndex = 0;
                CheckCustom();
            }
        }


        private void PopulateComboBox()
        {
            ActivityType custom = null;
            foreach (var item in LoadActivitiesFromDB())
            {
                if (item.ActivityTypeName != "Custom")
                {
                    cmbxActivity.Items.Add(item);
                }
                else
                {
                    custom = item;
                }
            }

            cmbxActivity.Items.Add(custom);

            if (cmbxActivity.Items.Count > 0)
            {
                cmbxActivity.SelectedIndex = 0;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbxActivity.SelectedItem != null && cmbxActivity.Items.Contains(cmbxActivity.SelectedItem))
            {
                if (cmbxActivity.SelectedItem.ToString().Equals("Custom"))
                {
                    if (txtCustomActivity.Text.Length == 0)
                    {
                        MessageBox.Show("You must enter a name for the custom activity", "Error");
                        txtCustomActivity.Focus();
                        return;
                    }
                }
                else
                {
                    txtCustomActivity.Text = cmbxActivity.SelectedItem.ToString();
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please choose a valid activity, or select Custom to enter your own.", "Error");
            }
        }

        public ActivityType GetActivityType()
        {
            return (ActivityType) cmbxActivity.SelectedItem;
        }

        public string GetCustomRequest()
        {
            return (string)txtCustomActivity.Text;
        }

        public string GetNotes()
        {
            return txtNotes.Text;
        }

        private void cmbxActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckCustom();
        }

        private void CheckCustom()
        {
            txtEstimatedCost.Text = this.GetActivityType().ActivityTypeEstimatedPrice.ToString();
            if (cmbxActivity.SelectedItem.ToString().Equals("Custom"))
            {
                txtCustomActivity.Enabled = true;
                txtCustomActivity.TabStop = true;
                txtCustomActivity.Focus();
            }
            else
            {
                txtCustomActivity.Enabled = false;
                txtCustomActivity.TabStop = false;
                txtCustomActivity.Text = "";
            }
        }

        public Form GetForm()
        {
            return this;
        }

        private List<ActivityType> LoadActivitiesFromDB()
        {
            var query = from activities in Database.Database.Data.ActivityOptions
                        select activities;

            List<ActivityType> list = query.ToList();
            ActivityType custom = null;

            foreach (var item in list)
            {
                if (item.ActivityTypeName != "Custom")
                {
                    ActivityFactory.ActivityFactorySingleton.RegisterActivity(item, new Activity(item));
                }
                else
                {
                    custom = item;
                }
            }

            if (custom == null)
            {
                custom = new ActivityType("Custom", 0);
                Database.Database.Data.ActivityOptions.Add(custom);
                Database.Database.Data.SaveChanges();
                list.Add(custom);
            }

            ActivityFactory.ActivityFactorySingleton.RegisterActivity(custom, new Activity(custom));
            return list;
        }
    }
}