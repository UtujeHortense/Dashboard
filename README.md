# **Dashboard Epitech**

## **Authors**

- utuje.hortense@epitech.eu
- ugo.oger@epitech.eu

## **Project overview**

The objective of this project is to assemble user services and widgets in one place for better observation and usage.

The project is built with :

- Front-end → Vue JS
- Back-end → Dotnet / C#
- Database → MySql / Azure Microsoft

Users can sign up and login with their own Email and Password to have a completely configurable dashboard.

## **Frontend**

The frontend (main application) is available at `https://localhost:8080` in local environment.\n
In order to run the application use :
    npm run serve in `/front-end/mydashboard/`

## **Backend**

The backend is available at `https://localhost:5001/api/[REQUEST]` in local environment.\n
In order to run the application use:
    dotnet run in `/back-end/`

All the informations about a user, is save in a Database host on Azure Microsoft server.

## **Widgets**

We implemented 4 different configurable widgets for this project, 3 of them are stand alone and 1 that depends on a service.
**All of our widget's state are maintained for the next connection.**

- Weather :
    - Display Weather information (Temperature, Location, Description of the weather).
    It is possible to configure this widget by changing the city name.

- Countdown :
    - Display a countdown for a selected end date.
    This widget is also configurable by modifying the date.

- Apod-Nasa :
    - Display Astronomy Picture of the Day from NASA.
    - Display The Title of this picture.
    - Possible to display the description of this picture.
    It is possible to configure this widget by changing the date. By Default, the date is the current day.

- Deezer Artists stat
    - This widget depends on the Deezer service described below. It displays the number of albums and number of fans per artist liked by the user.
    The user can select from a list of artists that they alreadly have in their account.

## **Services**

- Deezer Service :
    Deezer is a music platform widely used and offers developer options such as API and Plugins. For this project we used it's API.
    - The user is required to give authorization to our application through 0Auth2 method.
    - With this service we are able to display the users favorite albums and shuffle them if necessary
    - The user can also play previews of recommended tracks and well as those in their album

## **Bonus**

Database server online with Azure Microsoft