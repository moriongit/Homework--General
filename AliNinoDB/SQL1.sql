CREATE PROCEDURE InsertData
    @TableName NVARCHAR(128),
  
    @Title NVARCHAR(80) = NULL,
    @Description NVARCHAR(255) = NULL,
    @ActualPrice INT = NULL,
    @DiscountPrice INT = NULL,
    @PublishingHouseID INT = NULL,
    @StockCount INT = NULL,
    @ArticleCode INT = NULL,
    @BindingID INT = NULL,
    @Pages INT = NULL,
    @CategoryID INT = NULL,
    @IsDeleted BIT = NULL,
   
    @AuthorName NVARCHAR(80) = NULL,
    @AuthorSurname NVARCHAR(80) = NULL,
    @GenreTitle NVARCHAR(80) = NULL,
    @LanguageTitle NVARCHAR(80) = NULL,
    @Rating INT = NULL,
    @CommentDescription NVARCHAR(255) = NULL,
    @CommentName NVARCHAR(60) = NULL,
    @CommentEmail NVARCHAR(60) = NULL,
    @CommentImageURL NVARCHAR(255) = NULL
AS
BEGIN
    IF @TableName = 'Categories'
    BEGIN
        INSERT INTO Categories (Title, ParentCategoryID, IsDeleted)
        VALUES (@Title, @CategoryID, @IsDeleted);
    END
    ELSE IF @TableName = 'PublishingHouses'
    BEGIN
        INSERT INTO PublishingHouses (Title, IsDeleted)
        VALUES (@Title, @IsDeleted);
    END
    ELSE IF @TableName = 'Binding'
    BEGIN
        INSERT INTO Binding (Title, IsDeleted)
        VALUES (@Title, @IsDeleted);
    END
    ELSE IF @TableName = 'Books'
    BEGIN
        INSERT INTO Books (Title, [Description], ActualPrice, DiscountPrice, PublishingHouseID, StockCount, ArticleCode, BindingID, Pages, CategoryID, IsDeleted)
        VALUES (@Title, @Description, @ActualPrice, @DiscountPrice, @PublishingHouseID, @StockCount, @ArticleCode, @BindingID, @Pages, @CategoryID, @IsDeleted);
    END
    ELSE IF @TableName = 'Authors'
    BEGIN
        INSERT INTO Authors ([Name], Surname, IsDeleted)
        VALUES (@AuthorName, @AuthorSurname, @IsDeleted);
    END
    ELSE IF @TableName = 'BooksAuthors'
    BEGIN
       
        INSERT INTO BooksAuthors (BookID, AuthorID, IsDeleted)
        VALUES (@Title, @AuthorName, @IsDeleted);
    END
    ELSE IF @TableName = 'Genres'
    BEGIN
        INSERT INTO Genres (Title, IsDeleted)
        VALUES (@GenreTitle, @IsDeleted);
    END
    ELSE IF @TableName = 'BooksGenres'
    BEGIN
       
        INSERT INTO BooksGenres (BookID, GenreID, IsDeleted)
        VALUES (@Title, @GenreTitle, @IsDeleted);
    END
    ELSE IF @TableName = 'Languages'
    BEGIN
        INSERT INTO Languages (Title, IsDeleted)
        VALUES (@LanguageTitle, @IsDeleted);
    END
    ELSE IF @TableName = 'Comment'
    BEGIN
        INSERT INTO Comment ([Description], BookID, Rating, Name, Email, ImageURL, IsDeleted)
        VALUES (@CommentDescription, @Title, @Rating, @CommentName, @CommentEmail, @CommentImageURL, @IsDeleted);
    END
    ELSE IF @TableName = 'BooksLanguages'
    BEGIN
       
        INSERT INTO BooksLanguages (BookID, LanguageID, IsDeleted)
        VALUES (@Title, @LanguageTitle, @IsDeleted);
    END
    ELSE
    BEGIN
        
        PRINT 'Invalid table name';
    END
END;

InsertData
    @TableName = 'Genres',
    @GenreTitle = 'Science Fiction',
    @IsDeleted = 0;