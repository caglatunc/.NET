namespace CleanArchitecture.Application.Utilities;
public static class ExtensionMethods
{
    public static string ReplaceAllTurkishCharacters(this string text)
    {
        Dictionary<string, string> keys = new()
        {
            {"ı", "i"},
            {"İ", "I"},
            {"ç", "c"},
            {"Ç", "C"},
            {"ş", "s"},
            {"Ş", "S"},
            {"ğ", "g"},
            {"Ğ", "G"},
            {"ü", "u"},
            {"Ü", "U"},
            {"ö", "o"},
            {"Ö", "O"}
        };
        foreach (var key in keys)
        {
            text = text.Replace(key.Key, key.Value);
        }

        return text;
    }   
}
