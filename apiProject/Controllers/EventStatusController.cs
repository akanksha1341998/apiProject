using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static apiProject.eventObject;

namespace apiProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventStatusController : ControllerBase
    {
        HttpClient client = new HttpClient();

        [HttpGet(Name = "GetEventStatus")]
        public async Task<IActionResult> Get(string email)
        {
            try
            {
                string apiUrl = $"https://1uf1fhi7yk.execute-api.eu-west-2.amazonaws.com/default/events?email={Uri.EscapeDataString(email)}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                string responseData = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var responseObject = JsonConvert.DeserializeObject<EventApiResponse>(responseData);

                    //list of events which are Busy of Out of office
                    var requiredEvents = responseObject != null ? responseObject.events.Where(eventObject=>eventObject.status == "Busy" || eventObject.status =="OutOfOffice") : null;
                    return Ok(requiredEvents);

                }
                else
                {
                    return StatusCode((int)response.StatusCode, responseData);  
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}"); ;
            }

        }

    }
}
