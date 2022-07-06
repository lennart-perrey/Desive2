using Desive2.Models;
using System.IO;
using Plugin.AudioRecorder;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Desive2.ViewModels
{
    public class VoiceMailViewModel : BindableObject
    {
        public Task<string> Audiofile { get; set; }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        private string listeningText = "Sprachnotiz anhören";
        public string ListeningText
        {
            get
            {
                return listeningText;
            }
            set
            {
                listeningText = value;
                OnPropertyChanged();
            }
        }

        private bool isListeningVisible = false;
        public bool IsListeningVisible
        {
            get
            {
                return isListeningVisible;
            }
            set
            {
                isListeningVisible = value;
                OnPropertyChanged();
            }
        }

        private string recordText = "Hier klicken um eine Sprachnotiz aufzunehmen";
        public string RecordText
        {
            get => recordText;
            set
            {
                if (value == recordText)
                    return;

                recordText = value;
                OnPropertyChanged();
            }
        }

        private string uploadText = "Sprachnotiz hochladen";
        public string UploadText
        {
            get => uploadText;
            set
            {
                if (value == uploadText)
                    return;

                uploadText = value;
                OnPropertyChanged();
            }
        }

        private string stopText = "Stop";
        public string StopText
        {
            get => stopText;
            set
            {
                stopText = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartRecording { get; set; }
        public ICommand UploadAudio { get; set; }
        public ICommand StopRecording { get; set; }
        public ICommand PlayAudio { get; set; }

        private bool isRecordingVisible = true;
        public bool IsRecordingVisible
        {
            get => isRecordingVisible;
            set
            {
                isRecordingVisible = value;
                OnPropertyChanged();
            }
        }

        private bool isStopVisible = false;
        public bool IsStopVisible
        {
            get => isStopVisible;
            set
            {
                isStopVisible = value; ;
                OnPropertyChanged();
            }
        }

        private bool isUploadVisible = false;
        public bool IsUploadVisible
        {
            get => isUploadVisible;
            set
            {
                isUploadVisible = value; ;
                OnPropertyChanged();
            }
        }
        public AudioRecorderService Recorder { get; private set; }
        public VoiceMailViewModel()
        {
            Title = "Sprachnotiz aufnehmen";
            UploadAudio = new Command(AudioUploadCommand);
            StopRecording = new Command(StopRecordingCommand);
            StartRecording = new Command(StartRecordingCommand);
            PlayAudio = new Command(PlayAudioCommand);
            Recorder = new AudioRecorderService
            {
                StopRecordingOnSilence = true,
                StopRecordingAfterTimeout = true,
                TotalAudioTimeout = TimeSpan.FromSeconds(15)
            };
        }

        private async void AudioUploadCommand()
        {
            AudioPlayer player = new AudioPlayer();
            var filePath = Recorder.GetAudioFilePath();
            byte[] bytes = File.ReadAllBytes(filePath);
            string file = Convert.ToBase64String(bytes);
            string id = Preferences.Get("userId", null);
            Database.UploadVoicemail(id, file);
        }




        private async void StartRecordingCommand()
        {
            IsRecordingVisible = false;
            IsStopVisible = true;
            try
            {
                if (!Recorder.IsRecording)
                {
                    StopText = "Aufnahme Stoppen";
                    await Recorder.StartRecording();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void StopRecordingCommand()
        {
            if (Recorder.IsRecording)
            {
                IsStopVisible = false;
                IsListeningVisible = true;
                IsUploadVisible = true;
                IsRecordingVisible = true; ;
                RecordText = "Neue Sprachnotiz aufnehmen";
                await Recorder.StopRecording();
            }
        }
        private async void PlayAudioCommand()
        {

            AudioPlayer player = new AudioPlayer();
            var filePath = Recorder.GetAudioFilePath();
            player.Play(filePath);
        }

        
    }
}