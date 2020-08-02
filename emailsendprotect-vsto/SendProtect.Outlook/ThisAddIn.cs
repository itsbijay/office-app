using SendProtect.Library;
using Microsoft.Office.Interop.Outlook;
using System;

namespace SendProtect.Outlook
{
    /// <summary>
    /// ThisAddIn
    /// </summary>
    /// <seealso cref="Microsoft.Office.Tools.Outlook.OutlookAddInBase" />
    public partial class ThisAddIn
    {
        /// <summary>
        /// Handles the Shutdown event of the ThisAddIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Handles the Startup event of the ThisAddIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            Application.ItemSend += new ApplicationEvents_11_ItemSendEventHandler(AppItemSend.OnSend);
        }

        /// <summary>
        /// Internals the startup.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += ThisAddIn_Startup;
            this.Shutdown += ThisAddIn_Shutdown;
        }
    }
}