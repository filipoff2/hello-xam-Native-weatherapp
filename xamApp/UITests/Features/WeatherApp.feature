Feature: WeatherApp

# 1. Create an app with a splash screen that navigates to a homepage that allows the user to enter the name of a city.  
# 2. When the user enters the name of a city the app should retrieve weather data using the Open Weather API http://openweathermap.org/current.
# 3. In a separate screen the user should be shown a description of the weather in their chosen city along with temperature information.
# 4. The user should be given the option of saving the name of their favourite city so that the city name field of the homepage is prepopulated.


@4
Scenario: City name has been saved
    Given London is my favorite city
    When I relaunch the app
    Then London should be in the search box

@4
Scenario: Forgetting the city
    Given London is my favorite city
    When I press the favorite button 
    And I relaunch the app
    Then search box should be empty

@4
Scenario: Saving the city name
    Given I am on the city details screen
    And Favorite button is not selected
    When I press the favorite button
    And I go back
    And I press search button
    Then favorite button should appear selected

@1 @2 @3
Scenario: Selecting city
    Given I am on the home screen
    And I have entered London into the search box
    When I press search button
    Then City details screen should appear
    And Header title should be London
    And Daily forecast should be visible

@1
Scenario: Selecting nonexisting city
    Given I am on the home screen
    And I have entered adsadsadsadsglggs into the search box
    When I press search button
    Then "Something went wrong. Try again later." message appears

