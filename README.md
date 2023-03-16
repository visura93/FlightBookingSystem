
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

## Sucess Respond
### With Single Search
![1](https://user-images.githubusercontent.com/60961883/224935344-63d9245b-62b9-4a71-8b75-d1daf2c23726.JPG)
### With All Search (Empty the query parameters)
![1](https://user-images.githubusercontent.com/60961883/225351382-d74e463d-0fd8-4d60-b405-4c3e673de344.JPG)

## Bad Request Respond
![2](https://user-images.githubusercontent.com/60961883/224935797-19f2d656-3606-48d8-afb4-43315aec10eb.JPG)

### Create Order

This endpoint creates an order for a flight.

-   **URL:** `/Order/OrderAggregate`
-   **Method:** `POST`
-   **Request Body:**
    -   {
	  "flightNo": "b6f3c39b-8551-400a-8fa5-d15b3ea72d1f",
	  "userName": "test User",
	  "arrivalDate": "2023-03-15T15:04:22.461Z",
	  "noOfSeats": 7		  
        }
	
![image](https://user-images.githubusercontent.com/60961883/225352652-7b9a2e32-3332-4ddd-8472-6f3468328a4b.png)
#### Record in Database 
![2](https://user-images.githubusercontent.com/60961883/225353075-662f6587-c561-4e05-9fac-d6c0809f6e61.JPG)

#### Please note that in Flights table Id column is the foriegn key of Flight No in Orders table

### Confirm Order

This endpoint confirms an existing order.

-   **URL:** `/OrderConfirm/OrderAggregateConfirm
-   **Method:** `PUT`
-   **Path Parameters:**
    {	
	  "orderStatus": true,
	  "id": "3226d215-b22c-4845-9b35-45aa462753de"
   }
    
![image](https://user-images.githubusercontent.com/60961883/225354210-928711a9-0606-40ab-934a-3e31c65490d3.png)

#### If we confirm the order the available count will reduce in Flights table
#### Earlier thr number of available seats were 100 and after the confirmation of 7 seats reservation, the available seats updated to 93
![3](https://user-images.githubusercontent.com/60961883/225355160-504df8bd-733a-41b5-80c2-fecab0eee7b3.JPG)

### for initialize the Database first drop all tables and in package manager console run the command "update-database"

## How to Run

1.  Clone the repository.
2.  Open the solution in Visual Studio.
3.  Build the solution.
4.  Run the API project.
5.  Use the provided endpoints to interact with the API.
