-- �ЫإD�n���I��ƪ�
CREATE TABLE SiteData (
    SiteID INT PRIMARY KEY,
    SiteName NVARCHAR(255) NOT NULL,
    AverageStopTime INT,
    AverageSpeed FLOAT,
    ValidFrom DATETIME2(0) GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
    ValidTo DATETIME2(0) GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
);

-- �ҥΪ�������
ALTER TABLE SiteData
SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.SiteDataHistory));

-- ���J��l���I���
INSERT INTO SiteData (SiteID, SiteName, AverageStopTime, AverageSpeed)
VALUES (1, '���IA', 5, 40.5),
       (2, '���IB', 8, 35.2);

-- ��s���I���
UPDATE SiteData
SET AverageStopTime = 6, AverageSpeed = 38.0
WHERE SiteID = 1;

-- �d�߯��IA�����v�O��
SELECT *
FROM SiteData
FOR SYSTEM_TIME ALL
WHERE SiteName = '���IA';

GO