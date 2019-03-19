DELETE FROM survey_result
DELETE FROM weather
DELETE FROM park
DELETE FROM users

INSERT INTO users (username, password, salt, role)
VALUES ('testuser', 'password1234', 'pinkiodizedkosher', 'superhero')
DECLARE @newUsersId int = (SELECT @@IDENTITY);

INSERT INTO park (parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies)
VALUES ('DENA', 'Denali', 'AK', 4740911, 1746, 36, 232, 'Tundra', 1917, 642809, 'The snow is melting into music.', 'John Muir', 'Beautiful space.', 10, 225)
DECLARE @newParkCode varchar(15) = 'DENA';

INSERT INTO weather (parkCode, fiveDayForecastValue, low, high, forecast)
VALUES ('DENA', 1, 32, 75, 'snow')
DECLARE @newForecastValue int = 1;

INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)
VALUES ('DENA', 'jo@sloppy.com', 'OH', 'sedentary')
DECLARE @newSurveyResultId int = (SELECT @@IDENTITY);

SELECT @newUsersId AS newUsersId, @newParkCode AS parkCode, @newForecastValue AS forecastValue, @newSurveyResultId AS newSurveyResultId;