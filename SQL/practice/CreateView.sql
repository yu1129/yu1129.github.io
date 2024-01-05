CREATE VIEW StopStatisticsData AS
SELECT s.StationIdx, s.AvgStandTime, r.AvgSpeed, r.MaxSpeed
FROM (
		SELECT StationIdx, AVG(StandTime) AS AvgStandTime
		FROM StandTimeRecord
		GROUP BY StationIdx
		) AS s
		JOIN (
		SELECT StationIdx, AVG(Speed) AS AvgSpeed, MAX(Speed) AS MaxSpeed
		FROM SpeedRecord
		GROUP BY StationIdx
		) AS r
		ON s.StationIdx = r.StationIdx;

--CREATE VIEW UnitRailStatisticsData AS
--SELECT RailNo, AVG(Speed) AS AvgSpeed, MAX(Speed) AS MaxSpeed
--FROM SpeedRecord
--GROUP BY RailNo;