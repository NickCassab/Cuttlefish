using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Rhino;
using Rhino.Geometry;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.FileIO;
using Rhino.Input.Custom;
using Rhino.Input;

namespace SampleCsModelessForm
{
    public partial class SampleCsModelessTextForm : Form
    {
        public SampleCsModelessTextForm()
        {
            InitializeComponent();
            g = pnlDraw.CreateGraphics();
        }


        //
        // START Class variables
        //

        bool startPaint = false;
        bool startPageTurn = false;
        bool draw = false;
        Graphics g;
        Color paintcolor;

        // nullable int for storing Null value << for graphics drawing
        int? initX = null;
        int? initY = null;

        int zDepth = 0;
        static RhinoDoc mRhinoDoc;
        Rhino.Display.RhinoView view3;
        Rhino.Geometry.NurbsSurface srf1;
        Rhino.Geometry.Point3d org;
        Rhino.Geometry.Plane plane1;

        //
        // END Class variables 
        //



        //
        // START Helper Methods
        //

        /// <summary> Sets the rhino doc to current doc </summary>
        /// <param name="doc"></param>
        public static void setRhinoDoc(RhinoDoc doc)
        {
            mRhinoDoc = doc;
        }

        /// <summary> get current rhino doc </summary>
        /// <returns> RhinoDoc doc </returns>
        public static RhinoDoc getRhinoDoc()
        {

            return mRhinoDoc;
        }

        /// <summary> Add a point </summary>
        /// <param name="doc"></param>
        /// <param name="point"></param>
        /// <returns> ?? </returns>
        public Rhino.Geometry.Point3d AddPoint(RhinoDoc doc, System.Drawing.Point point)
        {

            Rhino.Geometry.Point3d start1 = new Point3d((point.X) - 400, (-point.Y ) + 400, zDepth + .5);

            Rhino.Geometry.Transform plnXForm = Rhino.Geometry.Transform.PlaneToPlane(Rhino.Geometry.Plane.WorldXY, plane1);
            start1.Transform(plnXForm);

            mRhinoDoc.Objects.AddPoint(start1);
            mRhinoDoc.Views.Redraw();

            return start1;
        }

        /// <summary> Add a user determined point object and add point in Rhino space </summary>
        /// <returns> Rhino Point 3D </returns>
        public Rhino.Commands.Result selectPoint()
        {
            Rhino.Input.Custom.GetPoint gp = new Rhino.Input.Custom.GetPoint();
            gp.SetCommandPrompt("Drawing plane origin");
            gp.Get();
            org = gp.Point();
            mRhinoDoc.Objects.AddPoint(org);
            mRhinoDoc.Views.Redraw();
            return Rhino.Commands.Result.Success;

        }

        /// <summary> RunCommandPickPlane is a helper method for picking an existing surface to draw on </summary>
        /// <param name="mRhinoDoc"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        protected Result RunCommandPickPlane(RhinoDoc mRhinoDoc, RunMode mode)
        {
            //routine for picking an existing surface to draw on

            //please select a plane

            Rhino.DocObjects.ObjectType filter = Rhino.DocObjects.ObjectType.Surface;
            Rhino.DocObjects.ObjRef objref = null;
            Rhino.Commands.Result rc = Rhino.Input.RhinoGet.GetOneObject("Select surface", false, filter, out objref);
            if (rc != Rhino.Commands.Result.Success || objref == null)
                return rc;

            Rhino.Geometry.Surface refSrf = objref.Surface();
            refSrf.FrameAt(.5, .5, out plane1);

            Point3d pOrigin = refSrf.PointAt(1, 1);
            Point3d pY = refSrf.PointAt(0.5, 1);
            Point3d pX = refSrf.PointAt(1, 0.75);
            Vector3d vX = Rhino.Geometry.Point3d.Subtract(pX, pOrigin);
            Vector3d vY = Rhino.Geometry.Point3d.Subtract(pY, pOrigin);
            plane1 = new Plane(pOrigin, vX, vY);

            Rhino.DocObjects.RhinoObject rhobj = objref.Object();
            rhobj.Select(false);

            mRhinoDoc.Objects.AddPoint(pOrigin);
            mRhinoDoc.Objects.AddPoint(pX);
            mRhinoDoc.Objects.AddPoint(pY);
            mRhinoDoc.Views.Redraw();

            return Result.Success;
        }

        //
        // END Helper Methods
        //



        //
        // START Mouse Event Methods
        //

        // Event Fired when the mouse pointer is over Panel and a mouse button is pressed
        private void pnlDraw_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            startPageTurn = true;
        }

        //Fired when the mouse pointer is over the pnl_Draw and a mouse button is released.
        private void pnlDraw_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            startPageTurn = false;
            initX = null;
            initY = null;
        }

        // Event fired when the mouse pointer is moved over the Panel(pnlDraw).
        private void pnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (draw) 
            {
                if (startPaint)
                {
                    //Setting the Pen BackColor and line Width
                    Pen p = new Pen(Color.Navy, 3);
                    //Drawing the line.
                    System.Drawing.Point point1 = new System.Drawing.Point(e.X, e.Y);
                    g.DrawLine(p, new System.Drawing.Point(initX ?? e.X, initY ?? e.Y), point1);

                    AddPoint(mRhinoDoc, point1);
                    initX = e.X;
                    initY = e.Y;
                }
            }
            else 
            {
                if (startPageTurn)
                {
                    Pen p2 = new Pen(Color.Navy, 3);
                    System.Drawing.Point point2 = new System.Drawing.Point(300, 650);
                    g.Clear(Color.White);
                    System.Drawing.SolidBrush paper = new System.Drawing.SolidBrush(System.Drawing.Color.Beige);
                    System.Drawing.SolidBrush paperBack = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGoldenrod);
                    System.Drawing.SolidBrush desk = new System.Drawing.SolidBrush(System.Drawing.Color.White);
                    g.FillRectangle(paper, new Rectangle(300, 150, 800, 500));

                    System.Drawing.Point mousePoint = new System.Drawing.Point(initX ?? e.X, initY ?? e.Y);
                    //g.DrawLine(p2, mousePoint, point2);

                    double a = e.X - point2.X;
                    double b = e.Y - point2.Y;
                    double distance = Math.Sqrt(a * a + b * b);
                    double hyp2 = distance / 2;

                    double angle = Math.Atan(e.Y / e.X);
                    double cosAngle = Math.Cos(angle);
                    double x1 = hyp2 / cosAngle;

                    double o = Math.Abs(90 - angle);
                    double p = Math.Cos(o);

                    double y1 = hyp2 / p;

                    int r = 650 - (int)y1;
                    int s = 300 + (int)x1;


                    
                    System.Drawing.Point pointa = new System.Drawing.Point(300, r);
                    System.Drawing.Point pointb = new System.Drawing.Point(s, 650);
                    g.DrawLine(p2, pointb, mousePoint);
                    g.DrawLine(p2, mousePoint, pointa);
                    g.DrawLine(p2, pointb, pointa);

                    System.Drawing.Point[] points = new System.Drawing.Point[] { pointb, pointa, mousePoint};
                    System.Drawing.Point[] points2 = new System.Drawing.Point[] { pointb, pointa, new System.Drawing.Point(300, 650)};

                    g.FillPolygon(paperBack, points);
                    g.FillPolygon(desk, points2);

                }
            }
        }

        //
        // END Mouse Event Methods
        //



        //
        // START Button Methods
        //

        /// <summary> trackBarSetOpacity allows user to change window opacity </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarSetOpacity_Scroll(object sender, EventArgs e)
        {
            SampleCsModelessTextForm.ActiveForm.Opacity = trackBarSetOpacity.Value * 000.1d;
        }

        /// <summary> btnBegin3d opens new perspective viewport for 3D drawing </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBegin3d_Click(object sender, EventArgs e)
        {
            IntPtr hwnd = RhinoApp.MainWindowHandle();

            view3 = mRhinoDoc.Views.ActiveView;
            Rhino.DocObjects.Tables.ViewTable viewTable = mRhinoDoc.Views;
            var newDisplaymode = Rhino.Display.DisplayModeDescription.FindByName("Ghosted");
            Rhino.Display.DisplayModeDescription.UpdateDisplayMode(newDisplaymode);
            view3 = viewTable.Add("squid2", Rhino.Display.DefinedViewportProjection.Perspective, System.Drawing.Rectangle.FromLTRB(1000, 300, 1700, 1000), true);
            view3.Redraw();
        }

        /// <summary> btnPickOrigin allows user to select origin of drawing plane </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickOrigin_Click(object sender, EventArgs e)
        {
            Rhino.Commands.Result result1 = selectPoint();
        }

        /// <summary> btnNewDwgPlane creates new drawing plane perpedicular to camera centered around chosed origin </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewDwgPlane_Click(object sender, EventArgs e)
        {
            Rhino.Geometry.Point3d pt1 = org;

            Rhino.Geometry.Transform move1 = Rhino.Geometry.Transform.Translation(view3.MainViewport.CameraX);
            Rhino.Geometry.Transform move2 = Rhino.Geometry.Transform.Translation(view3.MainViewport.CameraY);

            var xRev = view3.MainViewport.CameraX;
            var yRev = view3.MainViewport.CameraY;
            xRev.Reverse();
            yRev.Reverse();

            Rhino.Geometry.Transform move3 = Rhino.Geometry.Transform.Translation(xRev);
            Rhino.Geometry.Transform move4 = Rhino.Geometry.Transform.Translation(yRev);

            Rhino.Geometry.Point3d pt2 = org;
            Rhino.Geometry.Point3d pt3 = org;
            Rhino.Geometry.Point3d pt4 = org;
            Rhino.Geometry.Point3d pt5 = org;

            //Rhino.Geometry.Vector3d.l

            pt2.Transform(move1);
            pt2.Transform(move2);

            pt3.Transform(move3);
            pt3.Transform(move4);

            pt4.Transform(move1);
            pt4.Transform(move4);

            pt5.Transform(move3);
            pt5.Transform(move2);

            srf1 = Rhino.Geometry.NurbsSurface.CreateFromCorners(pt2, pt4, pt3, pt5);
            plane1 = new Plane(org, view3.MainViewport.CameraX, view3.MainViewport.CameraY);
            Rhino.Geometry.Transform scale1 = Rhino.Geometry.Transform.Scale(org, 400);
            srf1.Transform(scale1);

            mRhinoDoc.Objects.AddPoint(pt1);
            mRhinoDoc.Objects.AddPoint(pt2);
            mRhinoDoc.Objects.AddPoint(pt3);
            mRhinoDoc.Objects.AddPoint(pt4);
            mRhinoDoc.Objects.AddPoint(pt5);

            mRhinoDoc.Objects.AddSurface(srf1);

            mRhinoDoc.Views.Redraw();

        }

        /// <summary> btnPickDwgPlane is a routine for picking an existing surface to draw on </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickDwgPlane_Click(object sender, EventArgs e)
        {
            RunCommandPickPlane(mRhinoDoc, RunMode.Interactive);
        }

        /// <summary> btnOrientView is a routine for orienting the view to the current drawing plane </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrientView_Click(object sender, EventArgs e)
        {
            //set camera target to center of global drawing plane
            mRhinoDoc.Views.ActiveView.MainViewport.SetCameraLocations(plane1.PointAt(0, 0), plane1.PointAt(0, 0, 100));
            //set camera vector to the reverse of the normal at that point
            //redraw view
            view3.Redraw();
        }

        private void SampleCsModelessTextForm_Load(object sender, EventArgs e)
        {

        }

        private void pnlDraw_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newTraceBtn_Click(object sender, EventArgs e)
        {
            //Pen p1 = new Pen(Color.Black, 1);
            //g.DrawRectangle(p1, 300, 150, 800, 500);

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Beige);
            g.FillRectangle(myBrush, new Rectangle(300, 150, 800, 500));

            //myBrush.Dispose();
            //g.Dispose();
        }

        private void drawButton_CheckedChanged(object sender, EventArgs e)
        {
            draw = true;
        }

        private void draw2_CheckStateChanged(object sender, EventArgs e)
        {
            if (draw)
            {
                draw = false;
            }
            else
            {
                draw = true;
            }
        }

        // btnOk

        // btnCancel

        //
        // END Button Methods
        //

    }
}
