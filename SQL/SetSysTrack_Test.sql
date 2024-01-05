-- 創建主要站點資料表
CREATE TABLE SiteData (
    SiteID INT PRIMARY KEY,
    SiteName NVARCHAR(255) NOT NULL,
    AverageStopTime INT,
    AverageSpeed FLOAT,
    ValidFrom DATETIME2(0) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    ValidTo DATETIME2(0) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
);

-- 啟用版本控制
ALTER TABLE SiteData
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.SiteDataHistory));

-- 插入初始站點資料
INSERT INTO SiteData (SiteID, SiteName, AverageStopTime, AverageSpeed)
VALUES (1, '站點A', 5, 40.5),
       (2, '站點B', 8, 35.2);

-- 更新站點資料
UPDATE SiteData
SET AverageStopTime = 6, AverageSpeed = 38.0
WHERE SiteID = 1;

-- 查詢站點A的歷史記錄
SELECT *
FROM SiteData
FOR SYSTEM_TIME ALL
WHERE SiteName = '站點A';

GO