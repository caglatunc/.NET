namespace CleanArchitecture.Application.Services;
internal static class CommonService
{
    public static string ReplaceAllTurkishCharacters(string value)
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
            value = value.Replace(key.Key, key.Value);
        }

        return value;
    }   
}
