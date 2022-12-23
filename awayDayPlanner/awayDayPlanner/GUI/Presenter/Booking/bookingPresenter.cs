﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awayDayPlanner.GUI;
using awayDayPlanner.Source.Activities;
using awayDayPlanner.GUI.View.Booking;
using awayDayPlanner.GUI.Model.Booking;

namespace awayDayPlanner.GUI.Presenter.Booking
{
    public partial class bookingPresenter : IbookingPresenter
    {
        private IbookingModel model;
        private IbookingForm view;
        private List<IActivity> activities = new List<IActivity>();

        public bookingPresenter(IbookingForm view, IbookingModel model)
        {
            this.view = view;
            this.model = model;
            view.register(this);
            model.register(this);
        }

        public void submit()
        {
            if (model.submit(this.activities, view.getDate()) == 0)
            {
                view.message("Application Submitted Successfully");
                this.Close();
            }
            else
            {
                view.message("Something went wrong.");
            }
        }

        public void addActivity()
        {
            if (view.displayFormAsDialog(FormProvider.addNewItem) == DialogResult.OK)
            {
                //call a factory to create an activity object with activity type, name and notes
                var activity = FormProvider.addNewItem.getActivityType();
                string custom = FormProvider.addNewItem.getCustomRequest().ToString();
                string notes = FormProvider.addNewItem.getNotes().ToString();

                IActivity activityInstance = ActivityFactory.ActivityFactorySingleton.getActivityInstance(activity);
                activityInstance.Type = activity;
                activityInstance.Name = custom;
                activityInstance.Notes = notes;

                this.activities.Add(activityInstance);
                view.addItemToDGV(activityInstance.Name, activityInstance.Notes, activityInstance.Type.ActivityTypeEstimatedPrice);
            }
        }

        public void deleteRows(DataGridViewSelectedRowCollection rows)
        {
            foreach (DataGridViewRow row in rows)
            {
                this.activities.RemoveAt(row.Index);
                view.deleteRow(row);
            }
        }

        public void Close()
        {
            FormProvider.bookingForm.Hide();
            FormProvider.ControlPanelForm.Show();
            activities.Clear();
            view.Reset();
        }
    }
}