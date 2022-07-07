using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desive2.Models
{
    public class Survey
    {
        [JsonProperty("SurveyID")]
        public string SurveyID { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        
        [JsonProperty("QuestionID")]
        public string QuestionID { get; set; }


        [JsonProperty("QuestionText")]
        public string QuestionText { get; set; }

        [JsonProperty("QuestionTypeID")]
        public string Type { get; set; }

        [JsonProperty("Answer_Text")]
        public string Answer { get; set; }

        public Survey(string questionText, string type, string answers)
        {
            this.QuestionText = questionText;
            this.Type = type;
            this.Answer = answers;
        }

        public void Normalize()
        {

        }
    }
}
