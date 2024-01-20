USE [$DatabaseName$]
GO

-- Ensure the full-text catalog exists (if not, create it)
IF NOT EXISTS (SELECT * FROM sys.fulltext_catalogs WHERE name = 'ftCatalog')
BEGIN
    CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;
END

-- Create full-text index on BookInfo column in the Book table
CREATE FULLTEXT INDEX ON Book(BookInfo) 
    KEY INDEX PK_Book
    ON ftCatalog;


