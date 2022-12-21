namespace ValdemoroEn1.Models
{
    public class AppLanguage
    {
        public AppLanguage(string culture, string language)
        {
            Culture = culture;
            Language = language;
        }

        public string Culture { get; set; }
        public string Language { get; set; }
    }
}
