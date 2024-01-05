CREATE TABLE StandTimeRecord (
    ID INT PRIMARY KEY,
    StationIdx INT NOT NULL,
    StandTime FLOAT NOT NULL,
    TimeStamp Date  NOT NULL
);

CREATE TABLE SpeedRecord (
    ID INT PRIMARY KEY,
    StationIdx INT NOT NULL,
    Speed FLOAT  NOT NULL,
	RailNo INT  NOT NULL,
    TimeStamp Date  NOT NULL
);

GO