CREATE TRIGGER ChangeIsDeletedAuthors
ON Authors
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE Authors
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END

CREATE TRIGGER ChangeIsDeletedBinding
ON Binding
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE Binding
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END


CREATE TRIGGER ChangeIsDeletedBooks
ON Books
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE Books
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END


CREATE TRIGGER ChangeIsDeletedCategories
ON Categories
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE Categories
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END


CREATE TRIGGER ChangeIsDeletedComment
ON Comment
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE Comment
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END

CREATE TRIGGER ChangeIsDeletedGenres
ON Genres
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE Genres
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END

CREATE TRIGGER ChangeIsDeletedLanguages
ON Languages
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE Languages
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END
CREATE TRIGGER ChangeIsDeletedPublishingHouses
ON PublishingHouses
INSTEAD OF Delete
AS
BEGIN 
	 UPDATE PublishingHouses
     SET IsDeleted = 1
     WHERE Id in (SELECT Id FROM Deleted)
END
