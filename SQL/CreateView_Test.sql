--CREATE TABLE TestStationData (
--    SiteID INT PRIMARY KEY,
--    SiteName NVARCHAR(255) NOT NULL,
--    StopTime INT,
--    Speed FLOAT
--);

--CREATE VIEW AverageData
--AS
--SELECT SiteID, AVG(StopTime) As Avg_StopTime
--FROM TestStationData
--Group BY SiteID;

SELECT *
FROM AverageData;