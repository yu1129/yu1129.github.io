-- (1) 找出和最貴的產品同類別的所有產品
SELECT ProductName
FROM Products p
WHERE (
	SELECT TOP 1 WITH TIES CategoryID
	FROM Products
	ORDER BY UnitPrice DESC) = p.CategoryID;

-- (2) 找出和最貴的產品同類別最便宜的產品
SELECT TOP 1 WITH TIES ProductName
FROM Products p
WHERE (
	SELECT TOP 1 WITH TIES CategoryID
	FROM Products
	ORDER BY UnitPrice DESC) = p.CategoryID
ORDER BY UnitPrice ASC;

-- (3) 計算出上面類別最貴和最便宜的兩個產品的價差
SELECT MAX(UnitPrice) - MIN(UnitPrice) AS Spread
FROM Products p
WHERE (
	SELECT TOP 1 WITH TIES CategoryID
	FROM Products
	ORDER BY UnitPrice DESC) = p.CategoryID;

-- (4) 找出沒有訂過任何商品的客戶所在的城市的所有客戶
SELECT s.CompanyName
FROM Customers s
WHERE s.City IN(
	SELECT c.City
	FROM Customers c Left OUTER JOIN Orders o ON c.CustomerID = o.CustomerID
	WHERE o.CustomerID IS NULL);

-- (5) 找出第 5 貴跟第 8 便宜的產品的產品類別
SELECT DISTINCT c.CategoryName
FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
INNER JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE od.ProductID IN (
	(SELECT ProductID
	FROM Products
	ORDER BY UnitPrice DESC
	OFFSET 4 ROWS
	FETCH NEXT 1 ROWS ONLY),
	(SELECT ProductID
	FROM Products
	ORDER BY UnitPrice DESC
	OFFSET 7 ROWS
	FETCH NEXT 1 ROWS ONLY)
);

-- (6) 找出誰買過第 5 貴跟第 8 便宜的產品
SELECT DISTINCT c.CompanyName
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
WHERE od.ProductID IN (
	(SELECT ProductID
	FROM Products
	ORDER BY UnitPrice DESC
	OFFSET 4 ROWS
	FETCH NEXT 1 ROWS ONLY),
	(SELECT ProductID
	FROM Products
	ORDER BY UnitPrice DESC
	OFFSET 7 ROWS
	FETCH NEXT 1 ROWS ONLY)
);

-- (7) 找出誰賣過第 5 貴跟第 8 便宜的產品
SELECT DISTINCT e.FirstName
FROM Orders o INNER JOIN Employees e ON e.EmployeeID = o.EmployeeID
INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
WHERE od.ProductID IN (
	(SELECT ProductID
	FROM Products
	ORDER BY UnitPrice DESC
	OFFSET 4 ROWS
	FETCH NEXT 1 ROWS ONLY),
	(SELECT ProductID
	FROM Products
	ORDER BY UnitPrice DESC
	OFFSET 7 ROWS
	FETCH NEXT 1 ROWS ONLY)
);

-- (8) 找出 13 號星期五的訂單 (惡魔的訂單)
SELECT OrderID, OrderDate
FROM Orders
WHERE DAY(OrderDate) = 13 AND DATEPART(weekday, OrderDate) = 6;

-- (9) 找出誰訂了惡魔的訂單
SELECT c.CompanyName
FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE DAY(o.OrderDate) = 13 AND DATEPART(weekday, OrderDate) = 6;

-- (10) 找出惡魔的訂單裡有什麼產品
SELECT DISTINCT p.ProductName
FROM Orders o INNER JOIN Customers c ON o.CustomerID = c.CustomerID
INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID
WHERE DAY(o.OrderDate) = 13 AND DATEPART(weekday, o.OrderDate) = 6;

-- (11) 列出從來沒有打折 (Discount) 出售的產品
SELECT DISTINCT p.*
FROM [Order Details] od INNER JOIN Products p ON od.ProductID = p.ProductID
WHERE od.Discount = 0;
--OK

-- (12) 列出購買非本國的產品的客戶
SELECT DISTINCT c.CompanyName
FROM Suppliers s INNER JOIN Products p ON s.SupplierID = p.SupplierID
INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
INNER JOIN Orders o ON od.OrderID = o.OrderID
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE s.Country NOT LIKE N'Taiwan';

-- (13) 列出所有在每個月月底的訂單
SELECT OrderID
FROM Orders
WHERE DATEPART(DAY, DATEADD(DAY, 1, OrderDate)) = 1;

-- (14) 列出每個月月底售出的產品
SELECT DISTINCT ProductName
FROM (
	SELECT OrderID
	FROM Orders
	WHERE DATEPART(DAY, DATEADD(DAY, 1, OrderDate)) = 1
	) as n
INNER JOIN [Order Details] od ON n.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID;

-- (15) 列出在同個城市中有公司員工可以服務的客戶
SELECT DISTINCT c.CompanyName
FROM Employees e INNER JOIN Orders o ON e.EmployeeID = o.EmployeeID
INNER JOIN Customers c ON c.CustomerID = o.CustomerID
WHERE e.City = c.City;

-- (16) 找出銷售金額最高的前三個產品
SELECT DISTINCT TOP 3 WITH TIES ps.ProductName, SUM(n.CountTotal)
FROM (
	SELECT SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS CountTotal, p.ProductID
	FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
	GROUP BY p.ProductID
	) AS n
	INNER JOIN Products ps ON ps.ProductID = n.ProductID
GROUP BY ps.ProductName, n.CountTotal
ORDER BY SUM(n.CountTotal) DESC;

-- (17) 找出銷售金額最高的前三個產品類別
SELECT DISTINCT TOP 3 WITH TIES c.CategoryName, SUM(n.CountTotal)
FROM (
	SELECT SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS CountTotal, p.CategoryID, p.ProductID
	FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
	GROUP BY p.ProductID, p.CategoryID
	) AS n
	INNER JOIN Categories c ON n.CategoryID = c.CategoryID
GROUP BY c.CategoryName
ORDER BY SUM(n.CountTotal) DESC;

-- (18) 找出最敗家的前三個客戶
SELECT DISTINCT TOP 3 WITH TIES c.CompanyName, od.UnitPrice * od.Quantity * (1 - od.Discount) AS Total
FROM [Order Details] od INNER JOIN Orders o ON od.OrderID = o.OrderID
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
ORDER BY od.UnitPrice * od.Quantity * (1 - od.Discount) DESC;

-- (19) 找出有敗過最貴的三個產品中的任何一個的前三個大客戶
SELECT c.CompanyName, new.Total
FROM (
	SELECT DISTINCT TOP 3 WITH TIES n.ProductName, n.ProductID, n.UnitPrice, od.UnitPrice * od.Quantity * (1 - od.Discount) AS Total, OrderID
	FROM (
		SELECT DISTINCT TOP 3 WITH TIES ProductName, ProductID, UnitPrice
		FROM Products
		ORDER BY UnitPrice DESC
		) AS n
	INNER JOIN [Order Details] od ON n.ProductID = od.ProductID
	ORDER BY od.UnitPrice * od.Quantity * (1 - od.Discount) DESC) AS new
INNER JOIN Orders o ON new.OrderID = o.OrderID
INNER JOIN Customers c ON c.CustomerID = o.CustomerID;

-- (20) 找出有敗過銷售金額前三高個產品的前三個大客戶
SELECT TOP 3 c.CompanyName, SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS COST
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
INNER JOIN Products p ON p.ProductID = od.ProductID
WHERE p.ProductID IN(
					SELECT TOP 3 p.ProductID
					FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
					GROUP BY p.ProductID, p.ProductName
					ORDER BY SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) DESC
					)
GROUP BY c.CompanyName
ORDER BY SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) DESC;

-- (21) 找出有敗過銷售金額前三高個產品所屬類別的前三個大客戶
SELECT DISTINCT TOP 3 WITH TIES cu.CompanyName, SUM(n.Total)
FROM (
	SELECT DISTINCT TOP 3 WITH TIES od.ProductID, SUM(od.UnitPrice * Quantity * (1 - Discount)) AS Total
	FROM [Order Details] od INNER JOIN Products p ON od.ProductID = p.ProductID
	GROUP BY od.ProductID
	ORDER BY SUM(od.UnitPrice * Quantity * (1 - Discount)) DESC
	) AS n
INNER JOIN Products p ON p.ProductID = n.ProductID
INNER JOIN Categories c ON c.CategoryID = p.CategoryID
INNER JOIN [Order Details] od ON od.ProductID = p.ProductID
INNER JOIN orders o ON o.OrderID = od.OrderID
INNER JOIN Customers cu ON cu.CustomerID = o.CustomerID
GROUP BY cu.CompanyName
ORDER BY SUM(n.Total) DESC;


-- (22) 列出消費總金額高於所有客戶平均消費總金額的客戶的名字，以及客戶的消費總金額
SELECT c.CompanyName, SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS Total
FROM Customers c INNER JOIN Orders o ON o.CustomerID = c.CustomerID
INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
INNER JOIN (
	SELECT SUM(UnitPrice * Quantity * (1 - Discount)) AS Total, OrderID
	FROM [Order Details]
	GROUP BY OrderID
	) AS n 
	ON n.OrderID = o.OrderID
GROUP BY c.CompanyName
HAVING SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) > AVG(n.Total);

-- (23) 列出最熱銷的產品，以及被購買的總金額
SELECT TOP 1 WITH TIES p.ProductName AS ProductName, SUM(Quantity * od.UnitPrice * (1 - od.Discount)) AS Total
FROM [Order Details] od INNER JOIN Products p ON od.ProductID = p.ProductID
GROUP BY od.ProductID, p.ProductName
ORDER BY SUM(Quantity) DESC;

-- (24) 列出最少人買的產品
SELECT p.ProductName
FROM (SELECT TOP 1 WITH TIES ProductID
	FROM [Order Details]
	GROUP BY ProductID
	ORDER BY SUM(Quantity) ASC) AS n
INNER JOIN Products p ON n.ProductID = p.ProductID;

-- (25) 列出最沒人要買的產品類別 (Categories)
SELECT c.CategoryName
FROM (SELECT TOP 1 WITH TIES ProductID
	FROM [Order Details]
	GROUP BY ProductID
	ORDER BY SUM(Quantity) ASC) AS n
INNER JOIN Products p ON n.ProductID = p.ProductID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID;

-- (26) 列出跟銷售最好的供應商買最多金額的客戶與購買金額 (含購買其它供應商的產品)
WITH T1 AS (
        SELECT o.CustomerID, p.SupplierID, SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS Total
        FROM [Order Details] od
        INNER JOIN Orders o ON od.OrderID = o.OrderID
        INNER JOIN Products p ON od.ProductID = p.ProductID
        GROUP BY o.CustomerID, p.SupplierID
		)

SELECT TOP 1 CustomerID, (
						SELECT SUM(Total)
						FROM T1
						WHERE CustomerID = CustomerID
						) AS Total
FROM T1
WHERE SupplierID = (
				SELECT TOP 1 SupplierID
				FROM t1
				GROUP BY SupplierID
				ORDER BY SUM(Total) DESC
				)
GROUP BY CustomerID
ORDER BY SUM(Total) DESC;



-- (27) 列出跟銷售最好的供應商買最多金額的客戶與購買金額 (不含購買其它供應商的產品)
WITH T1 AS (
		SELECT o.CustomerID, p.SupplierID, SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS Total
        FROM [Order Details] od
        INNER JOIN Orders o ON od.OrderID = o.OrderID
        INNER JOIN Products p ON od.ProductID = p.ProductID
        GROUP BY o.CustomerID, p.SupplierID
		)
SELECT TOP 1 CustomerID, SUM(Total) AS Total
FROM T1
WHERE SupplierID = (
				SELECT TOP 1 SupplierID
				FROM t1
				GROUP BY SupplierID
				ORDER BY SUM(Total) DESC
				)
GROUP BY CustomerID
ORDER BY SUM(Total) DESC;

-- (28) 列出那些產品沒有人買過
SELECT ProductID
FROM Products
EXCEPT
SELECT ProductID
FROM [Order Details];

-- (29) 列出沒有傳真 (Fax) 的客戶和它的消費總金額
SELECT n.CompanyName , SUM(od.Quantity * od.UnitPrice * (1 - od.Discount))
FROM (
	SELECT CustomerID, CompanyName
	FROM Customers
	WHERE Fax IS NULL
	) as n
	INNER JOIN Orders o ON o.CustomerID = n.CustomerID
	INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY n.CompanyName;

-- (30) 列出每一個城市消費的產品種類數量
SELECT n.City, c.CategoryName, Count(c.CategoryName)
FROM (
	SELECT CustomerID, City
	FROM Customers
	) AS n
	INNER JOIN Orders o ON n.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
	INNER JOIN Products p ON p.ProductID = od.ProductID
	INNER JOIN Categories c ON c.CategoryID = p.CategoryID
GROUP BY n.City, c.CategoryName;

-- (31) 列出目前沒有庫存的產品在過去總共被訂購的數量
SELECT n.ProductName, SUM(od.Quantity)
FROM (
	SELECT ProductID, ProductName
	FROM Products
	WHERE UnitsInStock = 0
	) AS n
INNER JOIN [Order Details] od ON n.ProductID = od.ProductID
GROUP BY n.ProductID, n.ProductName;

-- (32) 列出目前沒有庫存的產品在過去曾經被那些客戶訂購過
SELECT n.ProductID, n.ProductName, c.CompanyName
FROM (
	SELECT ProductID, ProductName
	FROM Products
	WHERE UnitsInStock = 0
	) AS n
INNER JOIN [Order Details] od ON n.ProductID = od.ProductID
INNER JOIN Orders o ON od.OrderID = o.OrderID
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY n.ProductID, n.ProductName, c.CompanyName;

-- (33) 列出每位員工的下屬的業績總金額
SELECT boss.EmployeeID AS BossID, (
								SELECT SUM(od.Quantity * od.UnitPrice * (1 - od.Discount))
								FROM Employees e INNER JOIN Orders o ON o.EmployeeID = e.EmployeeID
								INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
								WHERE e.ReportsTo IN (boss.EmployeeID)
								) AS TotalSale
FROM Employees boss INNER JOIN Employees e ON e.ReportsTo = boss.EmployeeID
GROUP BY boss.EmployeeID;

-- (34) 列出每家貨運公司運送最多的那一種產品類別與總數量
WITH T1 AS (
		SELECT o.ShipVia  AS ShipperID, p.CategoryID, SUM(od.Quantity) AS TotalQty
		FROM Orders o
		INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
		INNER JOIN Products p ON od.ProductID = p.ProductID
		GROUP BY o.ShipVia, p.CategoryID
		)

SELECT s.*, s2.CategoryID, s2.TotalQty
FROM T1 s2
INNER JOIN Shippers s ON s.ShipperID = s2.ShipperID
WHERE TotalQty = (
				SELECT MAX(TotalQty)
				FROM T1
				WHERE ShipperID = s2.ShipperID
				)

-- (35) 列出每一個客戶買最多的產品類別與金額
SELECT new.CustomerID, ca.CategoryName, MAX(TotalQuantity) AS MaxTotalQuantity, MAX(new.TotalCost) AS MaxTotalCost
FROM (
	SELECT o.CustomerID, p.ProductName, SUM(Quantity) AS TotalQuantity, SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalCost
	FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
	INNER JOIN Products p  ON p.ProductID = od.ProductID
	GROUP BY o.CustomerID, p.ProductName
	) AS new
INNER JOIN Products p ON p.ProductName = new.ProductName
INNEr JOIN Categories ca ON ca.CategoryID = p.CategoryID
GROUP BY new.CustomerID, ca.CategoryName;

-- (36) 列出每一個客戶買最多的那一個產品與購買數量
SELECT new.CustomerID, new.ProductName, MAX(TotalQuantity) AS MaxTotalQuantity
FROM (
	SELECT o.CustomerID, p.ProductName, SUM(Quantity) AS TotalQuantity
	FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
	INNER JOIN Products p  ON p.ProductID = od.ProductID
	GROUP BY o.CustomerID, p.ProductName
	) AS new
GROUP BY new.CustomerID, new.ProductName;

-- (37) 按照城市分類，找出每一個城市最近一筆訂單的送貨時間
SELECT c.City, MAX(o.OrderDate)
FROM Orders o INNER JOIN　Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.City
ORDER BY MAX(o.OrderDate) DESC;

-- (38) 建立 PIVOT 表，統計銷售金額如下：
-- City, [Beverages], [Condiments], [Seafood]
SELECT *
FROM (
	SELECT c.City, ca.CategoryName, SUM(od.Quantity * od.UnitPrice * (1 - od.Discount)) AS TotalSale
	FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
	INNER JOIN Products p ON p.ProductID = od.ProductID
	INNER JOIN Categories ca ON ca.CategoryID = p.CategoryID
	GROUP BY c.City, ca.CategoryName
	) n
PIVOT(
	MAX(TotalSale)
	FOR CategoryName IN([Beverages], [Condiments], [Seafood])
	) p;

-- (39) 寫一個 TVF 可以帶入上一題所要過濾的價格差 @diff_price，
-- 傳回與前一筆價格相差 @diff_price 的產品
IF OBJECT_ID (N'diffprice', N'IF') IS NOT NULL  
    DROP FUNCTION diffprice;  
GO
CREATE FUNCTION diffprice (@diff_price int=1)
RETURNS TABLE
AS
RETURN
	(
		SELECT (SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) - (
												SELECT SUM(od.UnitPrice * od.Quantity * (1 - od.Discount))
												FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
												INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
												GROUP BY c.CustomerID
												ORDER BY SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) DESC
												OFFSET (@diff_price - 1) ROWS
												FETCH FIRST 1 ROWS ONLY
												)) AS Spread
		FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
		INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
		GROUP BY c.CustomerID
		ORDER BY SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) DESC
		OFFSET (@diff_price - 2) ROWS
		FETCH FIRST 1 ROWS ONLY
	)
;

SELECT * FROM diffprice(4);


-- (40) 列出購買金額第五名與第十名的客戶，以及兩個客戶的金額差距
SELECT c.CustomerID AS '第五名', (
								SELECT c.CustomerID
								FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
								INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
								GROUP BY c.CustomerID
								ORDER BY SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) DESC
								OFFSET 9 ROWS
								FETCH FIRST 1 ROWS ONLY) AS '第十名', (SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) - (
											SELECT SUM(od.UnitPrice * od.Quantity * (1 - od.Discount))
											FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
											INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
											GROUP BY c.CustomerID
											ORDER BY SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) DESC
											OFFSET 9 ROWS
											FETCH FIRST 1 ROWS ONLY
											)) AS Spread
FROM Customers c INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.CustomerID
ORDER BY SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) DESC
OFFSET 4 ROWS
FETCH FIRST 1 ROWS ONLY;
