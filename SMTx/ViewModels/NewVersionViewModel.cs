using ReactiveUI;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Avalonia.Controls;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace SMTx.ViewModels
{
    internal class NewVersionViewModel : ViewModelBase
    {

        private string _currentVersion;
        private string _newVersion;
        private string _releaseNotes;
        private Uri _releaseUrl;
        private bool _isNewVersionAvailable;
        private HttpClient _client;
        private IReactiveCommand clickDownload { get; set; }

        public bool IsNewVersionAvailable
        {
            get => _isNewVersionAvailable;
            set => this.RaiseAndSetIfChanged(ref _isNewVersionAvailable, value);
        }

        public string CurrentVersion
        { 
            get => _currentVersion;
            set => this.RaiseAndSetIfChanged(ref _currentVersion, value); 
        }

        public string NewVersion
        {
            get => _newVersion;
            set => this.RaiseAndSetIfChanged(ref _newVersion, value);
        }

        public string ReleaseNotes
        {
            get => _releaseNotes;
            set => this.RaiseAndSetIfChanged(ref _releaseNotes, value);
        }
       
        public Uri ReleaseUrl
        {
            get => _releaseUrl;
            set => this.RaiseAndSetIfChanged(ref _releaseUrl, value);
        }

        public NewVersionViewModel(string SMTVersion)
        {
            CurrentVersion = SMTVersion;
            InitializeComponents();
        }

        public NewVersionViewModel()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _client = new HttpClient();
            var CanDownload = this.WhenAnyValue(p => p.IsNewVersionAvailable);
            clickDownload = ReactiveCommand.CreateFromTask(asyncShowSaveFileDialog, CanDownload);
        }

        public async Task<bool> asyncShowSaveFileDialog()
        {
            var dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Title = "Select Location ...";
            List<FileDialogFilter> Filters = new List<FileDialogFilter>();
            FileDialogFilter filter = new FileDialogFilter();
            List<string> extension = new List<string>();
            extension.Add("zip");
            filter.Extensions = extension;
            filter.Name = "ZIP Compressed Archive";
            Filters.Add(filter);
            dlgSaveFile.Filters = Filters;
            dlgSaveFile.DefaultExtension = "zip";
            var outFile = await dlgSaveFile.ShowAsync(App.RefMainWindow); 

            if (outFile != null)
            {
                if (File.Exists(outFile.ToString()))
                {
                    throw new FileNotFoundException("File not found.", nameof(outFile));
                }

                if (outFile.ToString() != null)
                {
                    try
                    {
                        _client.DefaultRequestHeaders.Clear();
                        _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SMT", "1.xx"));
                        byte[] fileBytes = await _client.GetByteArrayAsync(ReleaseUrl);
                        File.WriteAllBytes(outFile.ToString(), fileBytes);
                    }
                    catch(HttpRequestException ex)
                    {
                        Console.WriteLine("Error HTTP:" + ex.StatusCode.ToString());
                    }
                }
            }
            return (true);
        }

    }
}