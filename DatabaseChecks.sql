USE ElectronicsStore;
GO
-- Только чтение: контроль количества строк и внешних ключей.
SELECT name FROM sys.tables ORDER BY name;
SELECT COUNT(*) AS ForeignKeys FROM sys.foreign_keys;
DBCC CHECKCONSTRAINTS WITH ALL_CONSTRAINTS;
SELECT o.order_id,o.total_amount,SUM(i.line_total) AS calculated
FROM Orders o JOIN OrderItems i ON i.order_id=o.order_id
GROUP BY o.order_id,o.total_amount HAVING o.total_amount<>SUM(i.line_total);
-- Последний запрос должен вернуть 0 строк.
SELECT * FROM Products WHERE stock_quantity<0;
GO
