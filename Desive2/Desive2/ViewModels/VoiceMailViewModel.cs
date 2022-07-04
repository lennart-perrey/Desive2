using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Desive2.ViewModels
{
    public class VoiceMailViewModel : BindableObject
    {
        public Task<String> Audiofile{ get; set; }
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
        private string recordText = "Hier klicken um eine Sprachnotiz aufzunehmen";
        public string RecordText
        {
            get => recordText;
            set
            {
                if(value==recordText)
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
                stopText= value;
                OnPropertyChanged();
            }
        }

        public ICommand Audio { get; set; }
        public ICommand UploadAudio { get; set; }
        public ICommand StopRecording { get; set; }

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
        

            Audio = new Command(() => AudioRecorder());
            UploadAudio = new Command(() => AudioUpload());
            StopRecording = new Command(() => StopRecordingCommand());
            
            
            Recorder = new AudioRecorderService
            {
                StopRecordingOnSilence = true,
                StopRecordingAfterTimeout = true,
                TotalAudioTimeout = TimeSpan.FromSeconds(15)
            };
        }

        private async void AudioUpload()
        {
            var recordTask = await Recorder.StartRecording();

            var audioFile = await recordTask;

            if (audioFile != null)
            {

            }

        }

        async void AudioRecorder()
        {
            await RecordAudio();
        }

        private async Task RecordAudio()
        {
            try
            {

                IsRecordingVisible = false;
                IsStopVisible = true;
                StopText = "Aufnahme Stoppen";

               

                    var recordTask = await Recorder.StartRecording();

                    var audiofile = await recordTask;

                    if(audiofile != null)
                    {

                    }

                

                   


            }
            catch (Exception ex)
            {

            }               
        }

        private async Task StopRecordingCommand()
        {
            IsUploadVisible = true;
            await Recorder.StopRecording();
        }

    }
}