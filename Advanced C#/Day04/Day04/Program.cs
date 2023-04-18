using Day04;
List<Book> BookLists = new() { new("HTC", "How to code", new string[] { "MoSalah", "Ahmed" }, new DateTime(1997,6,3), 10000),
                               new("HTD", "How to debug", new string[] { "Abdulrazek", "Khaled" }, new DateTime(1999,8,3), 2000),
                               new("HTMF", "How to make friends", new string[] { "Ayman", "Tamer" }, new DateTime(1995,6,3), 5000),
};


// anonymous method to get ISBN
LibraryEngine.ProcessBooks(BookLists, delegate (Book x) { return x.ISBN; });

// lambda expression to get Publication dates 
LibraryEngine.ProcessBooks(BookLists, x => x.PublicationDate.ToString());

// user define delegate
LibraryEngine.ProcessBooks(BookLists, BookFunctions.GetTitle);
Console.WriteLine("-----------------------------------------");
LibraryEngine.ProcessBooks(BookLists, BookFunctions.GetAuthors);
Console.WriteLine("-----------------------------------------");

LibraryEngine.ProcessBooks(BookLists, BookFunctions.GetPrice);
Console.WriteLine("-----------------------------------------");
LibraryEngine.ProcessBooks(BookLists, BookFunctions.GetAuthors);