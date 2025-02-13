﻿namespace awayDayPlanner.GUI.View.ControlPanel

{
    partial class ControlPanelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewEvent = new System.Windows.Forms.Button();
            this.btnExistingEvents = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewEvent
            // 
            this.btnNewEvent.Location = new System.Drawing.Point(258, 82);
            this.btnNewEvent.Name = "btnNewEvent";
            this.btnNewEvent.Size = new System.Drawing.Size(252, 114);
            this.btnNewEvent.TabIndex = 0;
            this.btnNewEvent.Text = "Plan New Away Day";
            this.btnNewEvent.UseVisualStyleBackColor = true;
            this.btnNewEvent.Click += new System.EventHandler(this.btnNewEvent_Click);
            // 
            // btnExistingEvents
            // 
            this.btnExistingEvents.Location = new System.Drawing.Point(258, 262);
            this.btnExistingEvents.Name = "btnExistingEvents";
            this.btnExistingEvents.Size = new System.Drawing.Size(252, 114);
            this.btnExistingEvents.TabIndex = 1;
            this.btnExistingEvents.Text = "View Your Planned Away Days";
            this.btnExistingEvents.UseVisualStyleBackColor = true;
            this.btnExistingEvents.Click += new System.EventHandler(this.btnExistingEvents_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(630, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(158, 90);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Enabled = false;
            this.btnAdmin.Location = new System.Drawing.Point(630, 348);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(158, 90);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Visible = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // ControlPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExistingEvents);
            this.Controls.Add(this.btnNewEvent);
            this.Name = "ControlPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControlPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanelForm_FormClosing);
            this.ResumeLayout(false);

        }
            private System.Windows.Forms.Button btnNewEvent;
            private System.Windows.Forms.Button btnExistingEvents;
            private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAdmin;
    }

        #endregion

    }