using Desive2.Models;
using Desive2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Desive2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveyPage : ContentPage
    {
        public List<Survey> Survey{ get; set; }
        public SurveyPage()
        {
            InitializeComponent();
            string id = Preferences.Get("idAppUser", null);
            Survey = Database.GetCurrentSurvey(id);
            BindingContext = new SurveyPageViewModel();
            GetElementsFromList();
            
        }

        private void GetElementsFromList()
        {
            Survey entry;
            List<string> values = new List<string>();
            foreach (Survey survey in Survey)
            {
                if (!values.Contains(survey.QuestionID))
                {
                    values.Add(survey.QuestionID);
                }
            }

            for (int i = 0; i < values.Count; i++)
            {
                foreach(Survey survey in Survey)
                {

                }
            }
        }
    }
}