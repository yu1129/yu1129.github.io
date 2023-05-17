use Northwind
--(一)[查詢]

--0.簡單暖身
--(1)列出各產品的供應商名稱
SELECT p.ProductID, p.ProductName, s.SupplierID, s.CompanyName
FROM Products p INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID;

--(2)列出各產品的種類名稱
SELECT p.ProductID, p.ProductName, ca.CategoryID, ca.CategoryName
FROM Products p INNER JOIN Categories ca ON p.CategoryID = ca.CategoryID;

--(3)列出各訂單的顧客（公司）名字
SELECT od.OrderID, c.CompanyName
FROM [Order Details] od INNER JOIN　Orders o ON o.OrderID = od.OrderID
INNER JOIN Customers c ON c.CustomerID = o.CustomerID;

--(4)列出各訂單的物流商（公司）名字
SELECT od.OrderID, s.CompanyName
FROM [Order Details] od INNER JOIN　Orders o ON o.OrderID = od.OrderID
INNER JOIN Shippers s ON s.ShipperID = o.ShipVia;

--1.列出1998年各訂單的產品名稱
SELECT od.OrderID, p.ProductName
FROM Products p INNER JOIN [Order Details] od ON p.ProductID = od.ProductID
INNER JOIN Orders o ON  o.OrderID = od.OrderID
WHERE YEAR(o.OrderDate) = 1998;

--2.想知道 供應商們 分布在哪些國家
SELECT SupplierID, CompanyName
FROM Suppliers;

--3.各產品，UnitsInStock < UnitsOnOrder 顯示'供不應求'，否則顯示'正常'
SELECT ProductID, ProductName, (
		CASE
			WHEN UnitsInStock < UnitsOnOrder THEN '供不應求'
			ELSE '正常'
		END
		) AS Result
FROM Products;

--(二)[排序] + (前幾筆/跳過幾筆)  
--4.最新的前九筆訂單
SELECT TOP 9 OrderID, OrderDate
FROM Orders
ORDER BY OrderDate DESC;

--5.產品單價最便宜的第4~8名
SELECT ProductID, ProductName
FROM Products
ORDER BY UnitPrice ASC
OFFSET 3 ROWS
FETCH FIRST 4 ROWS ONLY;

--(三)[C U D]
--6.
--新增物流商：
--	公司名稱青杉人才，電話(02)66057606
--	公司名稱青群科技，電話(02)14055374
INSERT INTO Shippers(CompanyName, Phone)
VALUES ('青杉人才', '(02)66057606'), ('青群科技', '(02)14055374')

SELECT *
FROM Shippers;

--方才新增的兩筆資料，電話都改成(02)66057606，公司名稱結尾加'有限公司'
UPDATE Shippers
SET Phone = '(02)66057606', CompanyName = CompanyName + '有限公司'
WHERE CompanyName IN('青杉人才', '青群科技');

--刪除剛才兩筆資料
DELETE FROM Shippers
WHERE CompanyName IN('青杉人才有限公司', '青群科技有限公司');

--彙總函式
--7.找出最高單價產品 跟 產品平均單價 之間的差
SELECT ((
		SELECT TOP 1 UnitPrice
		FROM Products
		ORDER BY UnitPrice DESC
		) - AVG(UnitPrice))AS Spread
FROM Products;

--(四)[群組] (或 [子查詢]也解得了)
--例.各物流商 負責過的訂單數
--(a)群組寫法
	select 
		ShipVia , COUNT(*) as 累計訂單數
	from [Orders] 
	group by ShipVia

--(b)子查詢寫法
	select
		ShipperID , (
			select 
				Count(*)
			from Orders
			where ShipVia = ShipperID
		) as 累計訂單數
	from Shippers 


--8.被下訂次數小於9 的產品
SELECT ProductID, ProductName
FROM Products
WHERE ProductID IN(
				SELECT ProductID
				FROM [Order Details]
				GROUP BY ProductID
				HAVING COUNT(OrderID) < 9
				);

--9.各產品，歷史總銷售額大於3萬的，其最大單次銷售量
SELECT p.ProductID, p.ProductName, MAX(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS MaxSale, SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalSale
FROM Products p INNER JOIN [Order Details] od ON od.ProductID = p.ProductID
WHERE p.ProductID IN(
				SELECT ProductID
				FROM [Order Details]
				GROUP BY ProductID
				HAVING SUM(UnitPrice * Quantity * (1 - Discount)) > 30000
				)
GROUP BY p.ProductID, p.ProductName;

--(五)[子查詢]
--10.第二高單價產品 跟 第三高單價產品 之間的單價差
SELECT (UnitPrice - (
					SELECT UnitPrice
					FROM Products
					ORDER BY UnitPrice DESC
					OFFSET 2 ROWS
					FETCH FIRST 1 ROWS ONLY
					)) AS UnitPriceSpread
FROM Products
ORDER BY UnitPrice DESC
OFFSET 1 ROWS
FETCH FIRST 1 ROWS ONLY;

--例.每個員工所處理的 最新訂單
--排序，也是能［目測］出答案
	select *
	from Orders
	order by EmployeeID, OrderDate desc

--群組寫法
	SELECT 
		EmployeeID , MAX(OrderDate) --一般欄位Select不了，只能放彙總函式
	FROM Orders o
	GROUP BY EmployeeID

--子查詢寫法
	SELECT *
	FROM Orders o
	WHERE OrderDate = (
		SELECT
			MAX(OrderDate)
		FROM Orders 
		WHERE EmployeeID = o.EmployeeID 
	)
	--ORDER BY o.EmployeeID, o.OrderDate DESC

--11(a)每位顧客，最新的訂單日期
SELECT CustomerID, MAX(OrderDate) AS MaxOrderDate
FROM Orders
WHERE CustomerID IN (
					SELECT c.CustomerID
					FROM Customers c
					)
GROUP BY CustomerID
ORDER BY MAX(OrderDate) DESC;

--11(b)每位顧客，第三新的訂單日期 
SELECT CustomerID, MIN(OrderDate) AS MinOrderDate
FROM Orders
GROUP BY CustomerID
ORDER BY MIN(OrderDate) DESC;

--12.每個產品種類 列出 單價>那類產品的平均單價 的產品
SELECT p.ProductID, p.ProductName, ca.CategoryID, ca.CategoryName
FROM Products p INNER JOIN Categories ca ON p.CategoryID = ca.CategoryID
INNER JOIN (
			SELECT ca.CategoryID, AVG(UnitPrice) AS average
			FROM Products p INNER JOIN Categories ca ON p.CategoryID = ca.CategoryID
			GROUP BY ca.CategoryID
			) AS new ON new.CategoryID = ca.CategoryID
WHERE p.UnitPrice > new.average;

--13.每個供應商所供的，當前庫存量最高的產品 
SELECT CompanyName, MAX(UnitsInStock) AS MaxInStock
FROM Products p INNER JOIN Suppliers s ON s.SupplierID = p.SupplierID
GROUP BY CompanyName;

--14.客戶想改訂單：
--訂單編號11077，ProductID = 2 的訂購量 + 2
--產品表中的 UnitsInStock、UnitsOnOrder 也需調整
--用Transaction語法，同時commit ，否則rollback
SELECT *
FROM [Order Details]
WHERE OrderID = 11077 AND ProductID = 2;

SELECT *
FROM Products
WHERE ProductId = 2;

BEGIN TRANSACTION;
UPDATE [Order Details]
SET Quantity += 2
WHERE OrderID = 11077 AND ProductID = 2;

UPDATE Products
SET UnitsInStock -= 2, UnitsOnOrder += 2
WHERE ProductID = 2;
COMMIT;

--復原start
BEGIN TRANSACTION;
UPDATE [Order Details]
SET Quantity -= 2
WHERE OrderID = 11077 AND ProductID = 2;

UPDATE Products
SET UnitsInStock += 2, UnitsOnOrder -= 2
WHERE ProductID = 2;
COMMIT;
--復原end

BEGIN TRANSACTION;
BEGIN TRANSACTION;
UPDATE [Order Details]
SET Quantity += 2
WHERE OrderID = 11077 AND ProductID = 2;

UPDATE Products
SET UnitsInStock -= 2, UnitsOnOrder += 2
WHERE ProductID = 2;
COMMIT;
ROLLBACK;