#region

using System.Windows.Forms;
using Helpers;
using System;

#endregion

namespace WebScrap.View
{
    public partial class FrmHelp : Form
    {
        public FrmHelp()
        {
            InitializeComponent();
           
        }


        private void linkLabelWsj_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Webpages.OpenWebpage(linkLabelWsj.Text);
        }

        private void linkLabelFinviz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Webpages.OpenWebpage(linkLabelFinviz.Text);
        }

        private void linkLabelOpenInsider_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Webpages.OpenWebpage(linkLabelOpenInsider.Text);
        }

        private void linkLabelInstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Webpages.OpenWebpage(linkLabelInstall.Text);
        }

        private void linkLabelInvesting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Webpages.OpenWebpage(linkLabelOpenInsider.Text);
        }
    }
}