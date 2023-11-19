The API controller (in Controller/EventStatusController.cs) has one Get endpoint.

The Get endpoint excepts a single parameter email and makes call to an external API.

The external API sends random response i.e. it can status code 200 with list of event details or
other error status codes. If the API response is 200, then I process the response object by deserializing it into an object (for which class has been defined in EventAPIResponse.cs) and filter the events with the status "Busy" and "OutOfOffice".

If anything other that status code 200, is received then the C# API controller sends that error code and the related message.