﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Live;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel;

namespace onenotesticky {
    class LiveConnect {

        private const string ClientID = "000000004C15996C";
        public LiveAuthForm authForm;
        private LiveAuthClient liveAuthClient;
        public LiveConnectClient liveConnectClient;
        private RefreshTokenInfo refreshTokenInfo;

        public LiveAuthClient AuthClient {
            get {
                if (this.liveAuthClient == null) {
                    this.AuthClient = new LiveAuthClient(ClientID);
                }

                return this.liveAuthClient;
            }

            set {
                if (this.liveAuthClient != null) {
                    this.liveAuthClient.PropertyChanged -= this.liveAuthClient_PropertyChanged;
                }

                this.liveAuthClient = value;
                if (this.liveAuthClient != null) {
                    this.liveAuthClient.PropertyChanged += this.liveAuthClient_PropertyChanged;
                }

                this.liveConnectClient = null;
            }
        }

        private LiveConnectSession AuthSession {
            get {
                return this.AuthClient.Session;
            }
        }

        private void liveAuthClient_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "Session") {
                //this.UpdateUIElements();
            }
        } 

       /*private void UpdateUIElements()
        {
            LiveConnectSession session = this.AuthSession;
            bool isSignedIn = session != null;
            this.signOutButton.Enabled = isSignedIn;
            this.connectGroupBox.Enabled = isSignedIn;
            this.currentScopeTextBox.Text = isSignedIn ? string.Join(" ", session.Scopes) : string.Empty;
            if (!isSignedIn)
            {
                this.meNameLabel.Text = string.Empty;
                this.mePictureBox.Image = null;
            }
        }*/

        public string[] GetAuthScopes()
        {
            string[] scopes = {"office.onenote_create","wl.offline_access","wl.signin"};
            return scopes;
        }
/*
        void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CleanupAuthForm();
        }

        private void CleanupAuthForm()
        {
            if (this.authForm != null)
            {
                this.authForm.Dispose();
                this.authForm = null;
            }
        }*/

        public void LogOutput(string text)
        {

            System.Windows.Forms.MessageBox.Show(text);
        }

        public async void OnAuthCompleted(AuthResult result)
        {
            //this.CleanupAuthForm();
            if (result.AuthorizeCode != null)
            {
                try
                {
                    LiveConnectSession session = await this.AuthClient.ExchangeAuthCodeAsync(result.AuthorizeCode);
                    this.liveConnectClient = new LiveConnectClient(session);
                    LiveOperationResult meRs = await this.liveConnectClient.GetAsync("me");
                    dynamic meData = meRs.Result;
                    System.Windows.Forms.MessageBox.Show(meData.name);

                }
                catch (LiveAuthException aex)
                {
                    this.LogOutput("Failed to retrieve access token. Error: " + aex.Message);
                }
                catch (LiveConnectException cex)
                {
                    this.LogOutput("Failed to retrieve the user's data. Error: " + cex.Message);
                }
            }
            else
            {
                this.LogOutput(string.Format("Error received. Error: {0} Detail: {1}", result.ErrorCode, result.ErrorDescription));
            }
        }
        /*
        private void SignOutButton_Click(object sender, EventArgs e)
        {
            this.signOutWebBrowser.Navigate(this.AuthClient.GetLogoutUrl());
            this.AuthClient = null;
            this.UpdateUIElements();
        }

        private void ClearOutputButton_Click(object sender, EventArgs e)
        {
            this.outputTextBox.Text = string.Empty;
        }

        private void ScopeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.signinButton.Enabled = this.scopeListBox.SelectedItems.Count > 0;
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.pathTextBox.Text))
            {
                this.LogOutput("Path cannot be empty.");
                return;
            }

            try
            {
                LiveOperationResult result = null;
                switch (this.methodComboBox.Text)
                {
                    case "GET":
                        result = await this.liveConnectClient.GetAsync(this.pathTextBox.Text);
                        break;
                    case "PUT":
                        result = await this.liveConnectClient.PutAsync(this.pathTextBox.Text, this.requestBodyTextBox.Text);
                        break;
                    case "POST":
                        result = await this.liveConnectClient.PostAsync(this.pathTextBox.Text, this.requestBodyTextBox.Text);
                        break;
                    case "DELETE":
                        result = await this.liveConnectClient.DeleteAsync(this.pathTextBox.Text);
                        break;
                    case "MOVE":
                        result = await this.liveConnectClient.MoveAsync(this.pathTextBox.Text, this.destPathTextBox.Text);
                        break;
                    case "COPY":
                        result = await this.liveConnectClient.CopyAsync(this.pathTextBox.Text, this.destPathTextBox.Text);
                        break;
                    case "UPLOAD":
                        result = await this.UploadFile(this.pathTextBox.Text);
                        break;
                    case "DOWNLOAD":
                        await this.DownloadFile(this.pathTextBox.Text);
                        this.LogOutput("The download operation is completed.");
                        break;
                }

                if (result != null)
                {
                    this.LogOutput(this.methodComboBox.Text + "\t" + this.pathTextBox.Text);
                    this.LogOutput(JsonHelper.FormatJson(result.RawResult));
                    this.LogOutput(string.Empty);
                }
            }
            catch (Exception ex)
            {
                this.LogOutput("Received an error. " + ex.Message);
            }
        }

        private async Task<LiveOperationResult> UploadFile(string path)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            Stream stream = null;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                throw new InvalidOperationException("No file is picked to upload.");
            }
            try
            {
                if ((stream = dialog.OpenFile()) == null)
                {
                    throw new Exception("Unable to open the file selected to upload.");
                }

                using (stream)
                {
                    return await this.liveConnectClient.UploadAsync(path, dialog.SafeFileName, stream, OverwriteOption.DoNotOverwrite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task DownloadFile(string path)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            Stream stream = null;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                throw new InvalidOperationException("No file is picked to upload.");
            }
            try
            {
                if ((stream = dialog.OpenFile()) == null)
                {
                    throw new Exception("Unable to open the file selected to upload.");
                }

                using (stream)
                {
                    LiveDownloadOperationResult result = await this.liveConnectClient.DownloadAsync(path);
                    if (result.Stream != null)
                    {
                        using (result.Stream)
                        {
                            await result.Stream.CopyToAsync(stream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        private async void MainForm_Load(object sender, EventArgs e)
        {
            //this.methodComboBox.SelectedIndex = 0;
            //this.scopeListBox.SelectedIndex = 0;


        }

       /* Task IRefreshTokenHandler.SaveRefreshTokenAsync(RefreshTokenInfo tokenInfo)
        {
            // Note: 
            // 1) In order to receive refresh token, wl.offline_access scope is needed.
            // 2) Alternatively, we can persist the refresh token.
            return Task.Factory.StartNew(() =>
            {
                this.refreshTokenInfo = tokenInfo;
            });
        }

        Task<RefreshTokenInfo> IRefreshTokenHandler.RetrieveRefreshTokenAsync()
        {
            return Task.Factory.StartNew<RefreshTokenInfo>(() =>
            {
                return this.refreshTokenInfo;
            });
        }*/
    }
}
