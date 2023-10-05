using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Dashboard
{
    public static class LoadingScreenManager
    {
        private static LoadingAnimation loadingAnimationForm;

        public static void ShowLoadingScreen(ThreadStart actionToPerform)
        {
            // Show the loading animation form in a separate thread
            Thread loadingThread = new Thread(() =>
            {
                loadingAnimationForm = new LoadingAnimation(); // Replace LoadingForm with your actual loading animation form class
                Application.Run(loadingAnimationForm);
            });
            loadingThread.Start();

            // Execute the action
            actionToPerform.Invoke();

            // Close the loading animation form after the action is performed
            loadingAnimationForm.Invoke(new Action(() => loadingAnimationForm.Close()));
        }
    }
}
