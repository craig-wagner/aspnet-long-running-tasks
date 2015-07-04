using System;
using System.Web.UI;

namespace LongRunningTask
{
    public partial class WebForm1 : Page
    {
        private LengthyTask task = null;
        protected void Page_Load( object sender, EventArgs e )
        {
            task = Cache["LengthyTask"] as LengthyTask;
            if( task == null )
            {
                task = new LengthyTask();
                Cache["LengthyTask"] = task;
            }

            if( task.Running )
            {
                SetupPageWithTaskRunning();
            }
            else
            {
                SetupPageWithTaskNotRunning();
            }
        }

        private void SetupPageWithTaskRunning()
        {
            Button1.Enabled = false;
            Label1.Text = "The task is running now.<br>" +
                "It started at " + task.LastStartTime.ToString() + "<br>" +
                (DateTime.Now - task.LastStartTime).Seconds + " seconds have elapsed";
            // Register the script to refresh the page every 3 seconds.
            ClientScript.RegisterStartupScript( this.GetType(), "key",
                "window.setTimeout('document.location.replace(document.location.href); ',3000);",
                true );
        }

        private void SetupPageWithTaskNotRunning()
        {
            Label1.Text = "The task is not running.";
            if( task.FirstRunComplete )
            {
                Label1.Text += "<br>Last time it started at " + task.LastStartTime.ToString() + "<br>" +
                    "and finished at " + task.LastFinishTime.ToString() + "<br>";
                if( task.LastTaskSuccess )
                {
                    Label1.Text += "Task succeeded.";
                }
                else
                {
                    Label1.Text += "Task failed.";
                    if( task.ExceptionOccured != null )
                    {
                        Label1.Text += "<br>The exception was: " + task.ExceptionOccured.ToString();
                    }
                }
            }
        }

        protected void Button1_Click( object sender, System.EventArgs e )
        {
            if( !task.Running )
            {
                task.RunTask();
                SetupPageWithTaskRunning();
            }
        }
    }
}