using Individuellt_arbete.Model;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;

namespace Individuellt_arbete
{
    public static class SqlExtensions
    {
        /// <summary>
        /// Quickly open a sqlconnection and if it doesn't respond in the timeout time, throw a ConnectionError with the errorMessage
        /// </summary>
        /// <param name="conn">The sqlconnection that you are about to connect to</param>
        /// <param name="timeout">The timeout time in ms</param>
        /// <param name="errorMessage">The errormessage that the ConnectionException will have</param>
        public static void QuickOpen(this SqlConnection conn, int timeout = 5000, string errorMessage = "Timed out while trying to connect.")
        {
            // We'll use a Stopwatch here for simplicity. A comparison to a stored DateTime.Now value could also be used
            Stopwatch sw = new Stopwatch();
            bool connectSuccess = false;

            // Try to open the connection, if anything goes wrong, make sure we set connectSuccess = false
            Thread t = new Thread(delegate()
            {
                try
                {
                    sw.Start();
                    conn.Open();
                    connectSuccess = true;
                }
                catch { }
            });

            // Make sure it's marked as a background thread so it'll get cleaned up automatically
            t.IsBackground = true;
            t.Start();

            // Keep trying to join the thread until we either succeed or the timeout value has been exceeded
            while (timeout > sw.ElapsedMilliseconds)
                if (t.Join(1))
                    break;

            // If we didn't connect successfully, throw an exception
            if (!connectSuccess)
                throw new ConnectionException(errorMessage);
        }
    }
}