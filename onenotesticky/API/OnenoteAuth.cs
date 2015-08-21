using LiveConnectLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onenotesticky {

    public class OnenoteAuth {

        private static LiveConnect liveConnect;
        public static bool LoggedIn = false;
        public static string AccessToken = "";

        private static bool sessionExists() {
            return (!String.IsNullOrWhiteSpace(Properties.Settings.Default.refreshToken)) ? true : false;
        }

        private static string getRefreshToken() {
            return Properties.Settings.Default.refreshToken;
        }

        private static void setRefreshToken(string refreshToken) {
            if (Properties.Settings.Default.refreshToken == null)
                new System.Configuration.SettingsProperty("refreshToken");

            Properties.Settings.Default.refreshToken = refreshToken;
            Properties.Settings.Default.Save();
        }

        private static void Login(Action callback) {
            liveConnect = new LiveConnect(
                Properties.Resources.clientID,
                Properties.Resources.clientSecret,
                new string[] { "wl.offline_access", "office.onenote_update", "office.onenote_create" }
                );

            liveConnect.SigniningOverlay = null;

            if (sessionExists()) {
                System.Diagnostics.Debug.WriteLine("Refresh token encountered\n" + getRefreshToken());
                liveConnect.ResumeSession(getRefreshToken(), () => { onLoggedIn(callback); });
            } else {
                System.Diagnostics.Debug.WriteLine("Refresh token not found");
                liveConnect.ShowLoginDialog(() => { onLoggedIn(callback); });
            }

        }

        private static void onLoggedIn(Action callback) {
            System.Diagnostics.Debug.WriteLine("Successful login " + liveConnect.RefreshToken);
            if (!String.IsNullOrEmpty(liveConnect.RefreshToken)) {
                setRefreshToken(liveConnect.RefreshToken);
            }
            LoggedIn = true;
            AccessToken = liveConnect.AccessToken;
            callback.Invoke();
        }

        public static void whenLoggedIn(Action callback) {
            if (LoggedIn)
                callback.Invoke();
            else
                Login(callback);
        }
    }
}
