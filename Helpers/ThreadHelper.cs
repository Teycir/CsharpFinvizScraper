#region

using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;


#endregion

namespace Helpers
{
    public static class ThreadHelper
    {
        public static string GetControlText(Control ctl)
        {
            string text;

            if (ctl.InvokeRequired)
            {
                // Delegate.
                text = (string) ctl.Invoke(new ControlToStringMethodInvoker(GetControlText),
                                           ctl);
            }
            else
            {
                // Access the control directly.
                text = ctl.Text;
            }

            return text;
        }


        /// <summary>
        /// 	Set text property of various controls
        /// </summary>
        /// <param name="form"> The calling form </param>
        /// <param name="ctrl"> The CTRL. </param>
        /// <param name="text"> The text. </param>
        public static void ListboxAddText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                ListboxAddTextCallback d = ListboxAddText;
                form.Invoke(d, new object[] {form, ctrl, text});
            }
            else
            {
                if (ctrl is ListBox)
                {
                    ListBox lbox = ctrl as ListBox;
                    lbox.Items.Add(text);
                }
            }
        }


     

        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="ctrl">The CTRL.</param>
        /// <param name="color">The color.</param>
        public static void ListboxSetFontColor(Control ctrl, Color color)
        {
        
         
                if (ctrl is ListBox)
                {
                    ListBox lbox = ctrl as ListBox;
                  
                    lbox.ForeColor = color;
                }
        }


        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="ctrl">The CTRL.</param>
        /// <param name="color">The color.</param>
        public static void LabelSetFontColor(Control ctrl, Color color)
        {
            if (ctrl is Label)
            {
                Label lbox = ctrl as Label;

                lbox.ForeColor = color;
            }
        }


        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="ctrl">The CTRL.</param>
        /// <param name="color">The color.</param>
        public static void SetTextBoxFontColor(Control ctrl, Color color)
        {
            if (ctrl is TextBox)
            {
                TextBox tbox = ctrl as TextBox;

                tbox.ForeColor = color;
            }
        }


        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="ctrl">The CTRL.</param>
        /// <param name="color">The color.</param>
        public static void SetTextBoxBackColor(Control ctrl, Color color)
        {
            if (ctrl is TextBox)
            {
                TextBox tbox = ctrl as TextBox;

                tbox.BackColor = color;
            }
        }



        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl">The CTRL.</param>
        /// <param name="color">The color.</param>
        public static void SetForecolor(Form form, Control ctrl, Color color)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetColorCallback d = SetForecolor;
                form.Invoke(d, new object[] { form, ctrl, color });
            }
            else
            {
                ctrl.ForeColor = color;
            }
        }


        /// <summary>
        /// 	Set text property of various controls
        /// </summary>
        /// <param name="form"> The calling form </param>
        /// <param name="ctrl"> </param>
        /// <param name="text"> </param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = SetText;
                form.Invoke(d, new object[] {form, ctrl, text});
            }
            else
            {
                ctrl.Text = text;
            }
        }

        /// <summary>
        /// 	Set text property of various controls
        /// </summary>
        /// <param name="form"> The calling form </param>
        /// <param name="ctrl"> The CTRL. </param>
        /// <param name="visible"> if set to <c>true</c> [visible]. </param>
        public static void SetVisibility(Form form, Control ctrl, bool visible)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetVisibilityCallback d = SetVisibility;
                form.Invoke(d, new object[] {form, ctrl, visible});
            }
            else
            {
                ctrl.Visible = visible;
            }
        }

        #region Nested type: ControlToStringMethodInvoker

        private delegate string ControlToStringMethodInvoker(Control ctl);

        #endregion

        #region Nested type: ListboxAddTextCallback

        private delegate void ListboxAddTextCallback(Form f, Control ctrl, string text);

        #endregion

        #region Nested type: SetTextCallback

        private delegate void SetTextCallback(Form f, Control ctrl,string text);
        private delegate void SetColorCallback(Form f, Control ctrl, Color color);

        #endregion

        #region Nested type: SetVisibilityCallback

        private delegate void SetVisibilityCallback(Form f, Control ctrl, bool visible);

        #endregion
    }
}