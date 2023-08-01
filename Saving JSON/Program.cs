using Saving_JSON;
using System.Text.Json;

string url = "https://localhost:7137/Request/All";

var deserializerOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};

var httpClient = new HttpClient();
var uri = new Uri(url);
var response = await httpClient.GetAsync(uri);

string value = await response.Content.ReadAsStringAsync();
var questions = JsonSerializer.Deserialize<List<Question>>(value, deserializerOptions);

foreach(Question question in questions)
{
    Console.WriteLine(question.Title);
}


var serializerOptions = new JsonSerializerOptions
{
    WriteIndented = true,
};

string myJson= JsonSerializer.Serialize(questions, serializerOptions);

Console.WriteLine(myJson);

Console.WriteLine("sto caricando il testo json all'interno di un file di testo");

File.WriteAllText("questions.json", myJson);



