namespace SampleCsModelessForm
{
  partial class SampleCsModelessTextForm
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
            this.btnOrientView = new System.Windows.Forms.Button();
            this.btnPickDwgPlane = new System.Windows.Forms.Button();
            this.lblSetOpacity = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnNewDwgPlane = new System.Windows.Forms.Button();
            this.btnPickOrigin = new System.Windows.Forms.Button();
            this.trackBarSetOpacity = new System.Windows.Forms.TrackBar();
            this.btnBegin3d = new System.Windows.Forms.Button();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.newTraceBtn = new System.Windows.Forms.Button();
            this.draw2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSetOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOrientView
            // 
            this.btnOrientView.Location = new System.Drawing.Point(270, 38);
            this.btnOrientView.Name = "btnOrientView";
            this.btnOrientView.Size = new System.Drawing.Size(146, 23);
            this.btnOrientView.TabIndex = 26;
            this.btnOrientView.Text = "Orient Camera";
            this.btnOrientView.UseVisualStyleBackColor = true;
            this.btnOrientView.Click += new System.EventHandler(this.btnOrientView_Click);
            // 
            // btnPickDwgPlane
            // 
            this.btnPickDwgPlane.Location = new System.Drawing.Point(126, 38);
            this.btnPickDwgPlane.Name = "btnPickDwgPlane";
            this.btnPickDwgPlane.Size = new System.Drawing.Size(140, 23);
            this.btnPickDwgPlane.TabIndex = 25;
            this.btnPickDwgPlane.Text = "Pick Exist. Drawing Plane";
            this.btnPickDwgPlane.UseVisualStyleBackColor = true;
            this.btnPickDwgPlane.Click += new System.EventHandler(this.btnPickDwgPlane_Click);
            // 
            // lblSetOpacity
            // 
            this.lblSetOpacity.AutoSize = true;
            this.lblSetOpacity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSetOpacity.Location = new System.Drawing.Point(17, 44);
            this.lblSetOpacity.Name = "lblSetOpacity";
            this.lblSetOpacity.Size = new System.Drawing.Size(104, 13);
            this.lblSetOpacity.TabIndex = 24;
            this.lblSetOpacity.Text = "Set Window Opacity";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1394, 879);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(1310, 879);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 23);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnNewDwgPlane
            // 
            this.btnNewDwgPlane.Location = new System.Drawing.Point(422, 12);
            this.btnNewDwgPlane.Name = "btnNewDwgPlane";
            this.btnNewDwgPlane.Size = new System.Drawing.Size(120, 23);
            this.btnNewDwgPlane.TabIndex = 21;
            this.btnNewDwgPlane.Text = "New Drawing Plane";
            this.btnNewDwgPlane.UseVisualStyleBackColor = true;
            this.btnNewDwgPlane.Click += new System.EventHandler(this.btnNewDwgPlane_Click);
            // 
            // btnPickOrigin
            // 
            this.btnPickOrigin.Location = new System.Drawing.Point(270, 12);
            this.btnPickOrigin.Name = "btnPickOrigin";
            this.btnPickOrigin.Size = new System.Drawing.Size(146, 23);
            this.btnPickOrigin.TabIndex = 20;
            this.btnPickOrigin.Text = "Pick Drawing Plane Origin";
            this.btnPickOrigin.UseVisualStyleBackColor = true;
            this.btnPickOrigin.Click += new System.EventHandler(this.btnPickOrigin_Click);
            // 
            // trackBarSetOpacity
            // 
            this.trackBarSetOpacity.BackColor = System.Drawing.SystemColors.ControlLight;
            this.trackBarSetOpacity.Location = new System.Drawing.Point(19, 13);
            this.trackBarSetOpacity.Name = "trackBarSetOpacity";
            this.trackBarSetOpacity.Size = new System.Drawing.Size(104, 45);
            this.trackBarSetOpacity.TabIndex = 19;
            this.trackBarSetOpacity.Tag = "";
            this.trackBarSetOpacity.Value = 10;
            this.trackBarSetOpacity.Scroll += new System.EventHandler(this.trackBarSetOpacity_Scroll);
            // 
            // btnBegin3d
            // 
            this.btnBegin3d.Location = new System.Drawing.Point(126, 12);
            this.btnBegin3d.Name = "btnBegin3d";
            this.btnBegin3d.Size = new System.Drawing.Size(140, 23);
            this.btnBegin3d.TabIndex = 18;
            this.btnBegin3d.Text = "Begin 3D Sketch";
            this.btnBegin3d.UseVisualStyleBackColor = true;
            this.btnBegin3d.Click += new System.EventHandler(this.btnBegin3d_Click);
            // 
            // pnlDraw
            // 
            this.pnlDraw.AutoSize = true;
            this.pnlDraw.BackColor = System.Drawing.Color.White;
            this.pnlDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDraw.Location = new System.Drawing.Point(18, 70);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(1449, 800);
            this.pnlDraw.TabIndex = 27;
            this.pnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraw_Paint);
            this.pnlDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseDown);
            this.pnlDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseMove);
            this.pnlDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDraw_MouseUp);
            // 
            // newTraceBtn
            // 
            this.newTraceBtn.Location = new System.Drawing.Point(422, 39);
            this.newTraceBtn.Name = "newTraceBtn";
            this.newTraceBtn.Size = new System.Drawing.Size(120, 23);
            this.newTraceBtn.TabIndex = 28;
            this.newTraceBtn.Text = "New Sheet of Trace";
            this.newTraceBtn.UseVisualStyleBackColor = true;
            this.newTraceBtn.Click += new System.EventHandler(this.newTraceBtn_Click);
            // 
            // draw2
            // 
            this.draw2.AutoSize = true;
            this.draw2.Location = new System.Drawing.Point(604, 16);
            this.draw2.Name = "draw2";
            this.draw2.Size = new System.Drawing.Size(57, 17);
            this.draw2.TabIndex = 30;
            this.draw2.Text = "Draw2";
            this.draw2.UseVisualStyleBackColor = true;
            this.draw2.CheckStateChanged += new System.EventHandler(this.draw2_CheckStateChanged);
            // 
            // SampleCsModelessTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1484, 912);
            this.Controls.Add(this.draw2);
            this.Controls.Add(this.newTraceBtn);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.btnOrientView);
            this.Controls.Add(this.btnPickDwgPlane);
            this.Controls.Add(this.lblSetOpacity);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnNewDwgPlane);
            this.Controls.Add(this.btnPickOrigin);
            this.Controls.Add(this.trackBarSetOpacity);
            this.Controls.Add(this.btnBegin3d);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SampleCsModelessTextForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SampleCsModelessTextForm";
            this.Load += new System.EventHandler(this.SampleCsModelessTextForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSetOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOrientView;
    private System.Windows.Forms.Button btnPickDwgPlane;
    private System.Windows.Forms.Label lblSetOpacity;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnNewDwgPlane;
    private System.Windows.Forms.Button btnPickOrigin;
    private System.Windows.Forms.TrackBar trackBarSetOpacity;
    private System.Windows.Forms.Button btnBegin3d;
    private System.Windows.Forms.Panel pnlDraw;
    private System.Windows.Forms.Button newTraceBtn;
    private System.Windows.Forms.CheckBox draw2;

  }
}