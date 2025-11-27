namespace SurveyApp.Models
{
    public class SurveyModel
    {
        public int Id { get; set; }
        public string Question { get; set; } = "";
        public List<string> Options { get; set; } = new();
    }

    public static class SurveyData
    {
        public static List<SurveyModel> Surveys = new List<SurveyModel>();
        public static List<SurveyResponse> Responses = new List<SurveyResponse>();
    }
}


