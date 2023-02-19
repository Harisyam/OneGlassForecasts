# OneGlass Forecasts

OneGlass Forecasts is a web application that helps store managers to make informed decisions about their business by providing weather and sales forecasts for a given location and date range. The application uses data from the Visual Crossing Weather API and a custom forecast database.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- PostgreSQL
- Newtonsoft.Json
- RestSharp

## Getting Started

To run this application locally, follow these steps:

1. Clone this repository: `git clone https://github.com/Harisyam/OneGlassForecasts.git`
2. Open the solution file (`OneGlassMVP.sln`) in Visual Studio
3. Update the appsettings.json file with your Visual Crossing Weather API key and your PostgreSQL database connection string
4. Create the database by running the following command in the Package Manager Console: `Update-Database`
5. Run the application by pressing F5 in Visual Studio

## Usage

When you open the application, you will see a page with sales and weather forecasts for the next 14 days for Hamburg. You can use the form to select a different location and date range to get forecasts for that location.

To get alerts for any consecutive 3 days, you can click the "Get Alerts" button. The application will show the possible dates to close the shop.
