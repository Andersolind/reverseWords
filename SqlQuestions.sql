CREATE FUNCTION [dbo].[fn_ReverseWords] (
@ip VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
BEGIN
DECLARE @op VARCHAR(MAX)
SET @op = ''
DECLARE @Lenght INT
WHILE LEN(@ip) > 0
BEGIN
IF CHARINDEX(' ', @ip) > 0
BEGIN
SET @op = SUBSTRING(@ip,0,CHARINDEX(' ', @ip)) + ' ' + @op
SET @ip = LTRIM(RTRIM(SUBSTRING(@ip,CHARINDEX(' ', @ip) + 1,LEN(@ip))))
END
ELSE
BEGIN
SET @op = @ip + ' ' + @op
SET @ip = ''
END
END
RETURN @op
END

Go
---
create PROCEDURE dbo.FindPrimeNumbers
(
	@PrimeNumbers INTEGER
)
AS
BEGIN

DECLARE @ints TABLE (
    i    int NOT NULL,
    PRIMARY KEY CLUSTERED (i)
);

--- Populate work table with a series of integers..
WITH cte (i)
AS (    -- .. starting at 2
    SELECT 2 AS i UNION ALL
    SELECT i+1 FROM cte WHERE i<@PrimeNumbers)

INSERT INTO @ints (i)
SELECT i FROM cte
--- ... and we're already excluding some "obvious" primes,
--- by removing values that are divisible with 2, 3, 5, 7
--- and 11. This keeps the table size down and improves
--- performance.
WHERE (i=2 OR i%2!=0) AND
    (i=3 OR i%3!=0) AND
    (i=5 OR i%5!=0) AND
    (i=7 OR i%7!=0) AND
    (i=11 OR i%11!=0)
OPTION (MAXRECURSION 0)

DECLARE @p int, @i_count int
SELECT @p=1, @i_count=MAX(i) FROM @ints
end

go