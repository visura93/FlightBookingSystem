
# Flight API

## Endpoints

### Get Available Flights

This endpoint returns a list of available flights based on the search criteria.

-   **URL:** `/Flights/Search`
-   **Method:** `GET`
-   **Query Parameters:**
    -   `OriginAirportId` (required): The ID of the origin airport.
    -   `DestinationAirportId` (required): The ID of the destination airport.
    -   `Departure` (required): The departure date in the format of `MM/dd/yyyy`.
    -   `Arrival` (required): The arrival date in the format of `MM/dd/yyyy`.
-   **Response:** A list of available flights with the following properties:
    -   `Id`: The ID of the flight.
    -   `OriginAirportId`: The ID of the origin airport.
    -   `DestinationAirportId`: The ID of the destination airport.
    -   `DepartureTimeUtc`: The departure time in UTC format.
    -   `ArrivalTimeUtc`: The arrival time in UTC format.
    -   `AvailableSeats`: The number of available seats on the flight.

### Create Order

This endpoint creates an order for a flight.

-   **URL:** `/Order/OrderAggregate`
-   **Method:** `POST`
-   **Request Body:**
    -   {
		       "flightNo": "string",
			  "userName": "string",
			  "arrivalDate": "2023-03-14T07:56:16.391Z",
			  "orderStatus": true
        }

### Confirm Order

This endpoint confirms an existing order.

-   **URL:** `/OrderConfirm/OrderAggregateConfirm
-   **Method:** `PUT`
-   **Path Parameters:**
    {
			  "flightNo": "string",
			  "userName": "string",
			  "arrivalDate": "2023-03-14T07:56:16.391Z",
			  "orderStatus": true
			  "id" : "00000000000000000"
}
    


## How to Run

1.  Clone the repository.
2.  Open the solution in Visual Studio.
3.  Build the solution.
4.  Run the API project.
5.  Use the provided endpoints to interact with the API.
