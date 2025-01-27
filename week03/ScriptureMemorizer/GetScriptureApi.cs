namespace ScriptureMemorizer;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class GetScriptureApi
{
    public static async Task<string> GetScripture(string book, string chapter, string verse, string endVerse)
    {
        var client = new HttpClient();
        
        var response = await client.GetAsync($"https://api.nephi.org/scriptures/?q={book}+{chapter}%3A{verse}-{endVerse}");
        response.EnsureSuccessStatusCode();
        
        string json = await response.Content.ReadAsStringAsync();
        var data = JsonDocument.Parse(json);
        var scriptures = data.RootElement.GetProperty("scriptures");
        if (scriptures.GetArrayLength() > 0)
        {
            if (endVerse != "")
            {
                string fullText = "";
                for (int i = 0; i < scriptures.GetArrayLength(); i++)
                {
                    fullText += $"{scriptures[i].GetProperty("text").ToString()} ";
                }
            
                return fullText;
            }
            else
            {
                return scriptures[0].GetProperty("text").ToString();
            }
        }
        else
        {
            return "";
        }
    }
}