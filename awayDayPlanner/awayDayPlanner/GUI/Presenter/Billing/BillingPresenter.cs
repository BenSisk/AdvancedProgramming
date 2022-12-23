﻿using awayDayPlanner.GUI.Billing;
using awayDayPlanner.GUI.Model.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awayDayPlanner.GUI
{
    public class BillingPresenter
    {
        private readonly IBillingView _view;
        private readonly IBillingModel _model;

        public BillingPresenter(IBillingView view, IBillingModel model)
        {
            _view = view;
            view.Presenter = this;
            _model = model;
        }

        public void Submit ()
        {
            _view.buttonClose.Hide();
            _view.buttonCapture.Hide();
            _view.Title.Hide();
            _view.TopPanel.BackColor = System.Drawing.Color.White;
            _model.Submit(_view.AwayDay);
            _view.buttonClose.Show();
            _view.buttonCapture.Show();
            _view.Title.Show();
            _view.TopPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#fc9403");
        }

        public void BillingLoad (AwayDay awayDay)
        {
           // _view.Confirmed = awayDay.Confirmed; //this is tomorrows job //look in billingpresenter
            _view.BuyerName.Text = awayDay.User.firstname + " " + awayDay.User.lastname;
            _view.BuyerAddress.Text = awayDay.User.Address.FirstLine + ", " + awayDay.User.Address.SecondLine 
                + ", " + awayDay.User.Address.PostCode;
            _view.BuyerPhone.Text = awayDay.User.phone;
            _view.BuyerEmail.Text = awayDay.User.email;

            _view.TotalCost.Text = "£ " + awayDay.TotalCost.ToString("0.00");
            PopulateDataGrid(awayDay);
        }

        public void PopulateDataGrid(AwayDay awayDay)
        {
            DataGridSetup();
            foreach (var activity in awayDay.AwayDayActivities)
            {
                _view.addItemToDGV.Rows.Add(activity.Name, activity.EstimatedCost);
            }
        }

        public void DataGridSetup()
        {
            _view.addItemToDGV.ColumnCount = 2;

            _view.addItemToDGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _view.addItemToDGV.Columns[1].Width = 150;

            _view.addItemToDGV.Columns[0].Name = "Activity";
            _view.addItemToDGV.Columns[1].Name = "Cost";

            _view.addItemToDGV.Columns["Cost"].DefaultCellStyle.Format = "N2";
            _view.addItemToDGV.Columns["Cost"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            _view.addItemToDGV.Columns["Cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewColumn column in _view.addItemToDGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void Close ()
        {
            FormProvider.BillingForm.Close();
        }


    }
}
