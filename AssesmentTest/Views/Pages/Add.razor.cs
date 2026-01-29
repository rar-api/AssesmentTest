using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;

namespace AssesmentTest.Views.Pages
{
    public partial class Add : ComponentBase
    {
        // IHttpClientFactory set using dependency injection 
        [Inject]
        public required IHttpClientFactory HttpClientFactory { get; set; }

        // NavigationManager set using dependency injection
        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        // Add the data model and bind the form data to it
        [SupplyParameterFromForm]
        private Products? _products { get; set; }

        protected override void OnInitialized() => _products ??= new();

        // Begin POST operation code
        private async Task Submit()
        {
            // Serialize the information to be added to the database
            var jsonContent = new StringContent(JsonSerializer.Serialize(_products),
                Encoding.UTF8,
                "application/json");

            // Create the HTTP client using the FruitAPI named factory
            var httpClient = HttpClientFactory.CreateClient("FruitAPI");

            // Execute the POST request and store the response. The response will contain the new record's ID
            using HttpResponseMessage response = await httpClient.PostAsync("/fruits", jsonContent);

            // Check if the operation was successful, and navigate to the home page if it was
            if (response.IsSuccessStatusCode)
            {
                NavigationManager?.NavigateTo("/");
            }
            else
            {
                Console.WriteLine("Failed to add fruit. Status code: {response.StatusCode}");
            }
        }
    }
}
