using AssesmentTest.Views.Pages;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace AssesmentTest.Views.Home
{
    public partial class Home
    {
        // IHttpClientFactory set using dependency injection 
        [Inject]
        public required IHttpClientFactory HttpClientFactory { get; set; }

        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        /* Add the data model, an array is expected as a response */
        private IEnumerable<Products>? _products;

        // Begin GET operation when the component is initialized
        protected override async Task OnInitializedAsync()
        {
            // Create the HTTP client using the FruitAPI named factory
            var httpClient = HttpClientFactory.CreateClient("FruitAPI");

            // Perform the GET request and store the response. The parameter
            // in GetAsync specifies the endpoint in the API 
            using HttpResponseMessage response = await httpClient.GetAsync("/fruits");

            // If the request is successful deserialize the results into the data model
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                _products = await JsonSerializer.DeserializeAsync<IEnumerable<Products>>(contentStream);
            }
            else
            {
                // If the request is unsuccessful, log the error message
                Console.WriteLine($"Failed to load fruit list. Status code: {response.StatusCode}");
            }
        }
    }
}
