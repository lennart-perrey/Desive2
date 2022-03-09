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
                OnPropertyChanged(title);
            }
        }
        private string recordText = "Hier klicken um eine Sprachnotiz aufzunehmennnn";
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
        public bool IsButtonActive { get; set; }
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

            IsButtonActive = false;
            
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

                RecordText = "Aufnahme läuft...";
                if (!Recorder.IsRecording)
                {
                    await Recorder.StartRecording();
                }
                else
                {
                    await Recorder.StopRecording();
                }

            }
            catch (Exception ex)
            {

            }               
        }

    }
}