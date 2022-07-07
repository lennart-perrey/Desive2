using Desive2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Desive2.ViewModels
{
    public class SurveyPageViewModel : ContentPage
    {
        public ICommand SurveyEntries{ get; set; }
        public List<Survey> Survey{ get; set; }
        
        public SurveyPageViewModel()
        {
            Title = "Umfrage beantworten";
            SurveyEntries = new Command(GetSurveyQuestions);
            string id = Preferences.Get("idUser", null);
            //Survey = Database.GetCurrentSurvey(id);
            Normalize();
        }

        async void GetSurveyQuestions()
        {
           
        }

        void Normalize()
        {
            return;
        }

    }
}