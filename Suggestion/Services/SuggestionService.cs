using RestSharp;
using Newtonsoft.Json;
using Ludotheque.Suggestion.Models;


namespace Ludotheque.Suggestion.Services
{

    public class SuggestionService : ISuggestionService
    {

        private RestClient client;
        private const string ressourcePath = "suggestion/";

        public EvenementService(IConfiguration configuration)
        {
            client = new RestClient(configuration["Api:EvenementLocation"]);
        }

        public async Task<List<Evenement?>> GetEvenement(string eventid)
        {
            RestRequest request = new RestRequest($"{ressourcePath}/{eventid}");
            var results = await client.GetAsync<List<Evenement>>(request);
            return results != null ? results : new List<Evenement>();
        }

        public async Task<Evenement> AddEvenement(Evenement evenement)
        {
            RestRequest request = new RestRequest(ressourcePath);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(evenement);
            var response = await client.PostAsync(request);
            if (!response.IsSuccessful)
            {
                throw new EvenementLocationException(response.StatusCode, response.ErrorMessage);
            }
            return JsonConvert.DeserializeObject<Evenement>(response.Content);
        }
    }


}