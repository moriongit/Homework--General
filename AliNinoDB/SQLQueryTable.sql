CREATE TABLE Categories(
	ID int identity PRIMARY KEY,
	Title nvarchar(60) NOT NULL,
	ParentCategoryID int REFERENCES Categories(ID),
	IsDeleted bit
);

CREATE TABLE PublishingHouses(
	ID int identity PRIMARY KEY,
	Title nvarchar(80),
	IsDeleted bit
);

CREATE TABLE Binding(
	ID int identity PRIMARY KEY,
	Title nvarchar(60) NOT NULL,
	IsDeleted bit
);

CREATE TABLE Books(
	ID int identity PRIMARY KEY,
	Title nvarchar(60) NOT NULL,
	[Description] nvarchar(255) NOT NULL,
	ActualPrice int NOT NULL,
	DiscountPrice int,
	PublishingHouseID int REFERENCES PublishingHouses(ID),
	StockCount int NOT NULL,
	ArticleCode int,
	BindingID int REFERENCES Binding(ID),
	Pages int,
	CategoryID int REFERENCES Categories(ID),
	IsDeleted bit
);

CREATE TABLE Authors(
	ID int identity PRIMARY KEY,
	[Name] nvarchar(80),
	Surname nvarchar(80),
	IsDeleted bit
);

CREATE TABLE BooksAuthors(
	ID int identity PRIMARY KEY,
	BookID int REFERENCES Books(ID),
	AuthorID int REFERENCES Authors(ID),
	IsDeleted bit
);


CREATE TABLE Genres(
	ID int identity PRIMARY KEY,
	Title nvarchar(80),
	IsDeleted bit
)

CREATE TABLE BooksGenres(
	ID int identity PRIMARY KEY,
	BookID int REFERENCES Books(ID),
	GenreID int REFERENCES Genres(ID),
	IsDeleted bit
)

CREATE TABLE Languages(
	ID int identity PRIMARY KEY,
	Title nvarchar(80),
	IsDeleted bit
);

CREATE TABLE Comment(
	ID int identity PRIMARY KEY,
	[Description] nvarchar(255),
	BookID int REFERENCES Books(ID),
	Rating int CHECK(Rating >0 and Rating <5),
	Name nvarchar(60) NOT NULL,
	Email nvarchar(60) NOT NULL,
	ImageURL nvarchar(255),
	IsDeleted bit
);

CREATE TABLE BooksLanguages(
		ID int identity PRIMARY KEY,
		BookID int REFERENCES Books(ID),
		LanguageID int REFERENCES Languages(ID),
		IsDeleted bit
);