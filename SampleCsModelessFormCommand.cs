using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace SampleCsModelessForm
{
    [System.Runtime.InteropServices.Guid("49297d36-642b-431c-8e1e-1980a6ef493d")]
    public class SampleCsModelessFormCommand : Command
    {
        /// <summary>
        /// Form accessor
        /// </summary>
        public SampleCsModelessTextForm Form
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SampleCsModelessFormCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        /// <summary>
        /// The only instance of this command.
        /// </summary>
        public static SampleCsModelessFormCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// The command name as it appears on the Rhino command line.
        /// </summary>
        public override string EnglishName
        {
            get { return "SampleCsModelessFormCommand"; }
        }

        /// <summary>
        /// Runs the command
        /// </summary>
        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {

            SampleCsModelessTextForm.setRhinoDoc(doc);
            if (null == Form)
            {
                Form = new SampleCsModelessTextForm();
                Form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(Form_FormClosed);
                Form.Show(RhinoApp.MainWindow());
            }

            return Result.Success;
        }

        /// <summary>
        /// FormClosed EventHandler
        /// </summary>
        void Form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Form.Dispose();
            Form = null;
        }
    }
}
