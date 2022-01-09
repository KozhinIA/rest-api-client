using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ApiBook.Api;
using RestApiClient.Models;
using RestSharp;

namespace RestApiClient.Controllers
{
    public class ImportBooksController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var logs = Import();

            return View("ImportLog", logs);
        }


        private ImportLog Import()
        {
            var startTime = DateTime.Now;

            var api = new BooksApi();
            var logs = new List<ImportItemLog>();
            var page = 1;
            //while (true)
            //{
            //    try
            //    {
                    var entity = api.BooksGet(page);
                    ApplayImport(entity, logs);
            //        page++;
            //    }
            //    catch
            //    {
            //        break;
            //    }              
            //}
            

            var successCount = logs.Count(x => x.Type == ImportItemLogType.Success);
            var failedCount = logs.Count(x => x.Type == ImportItemLogType.Error);
            var finishTime = DateTime.Now;

            var result = new ImportLog()
            {
                StartImport = startTime,
                EndImport = finishTime,
                SuccessCount = successCount,
                FailedCount = failedCount,
                Logs = logs
            };

            return result;
        }

        private List<ImportItemLog> ApplayImport(ApiBook.Model.Books entity, List<ImportItemLog> logs)
        {
            var db = new LibraryContext();

            db.Books.RemoveRange(db.Books);

            foreach(var bookDto in entity.Results)
            {
                
                var book = new Book()
                {
                    Name = bookDto.Title,
                    IsArchive = false,
                    CreateAt = DateTime.Now,
                    Key = "123456Qq",
                    Languages = GetLanguages(bookDto.Languages, db),
                    Authors = GetAuthors(bookDto.Authors, db),
                    BookImage = GetBookImage(bookDto.Id.Value, db),
                    Annotation = null,
                    Cost = null,
                    Year = null,
                    Isbn = null
                };
                db.Books.Add(book);
                db.SaveChanges();
                logs.Add(new ImportItemLog() { Message = $"Add book {book.Name}", Type = ImportItemLogType.Success});
            }
            

            return logs;
        }

        private List<Language> GetLanguages(List<string> languagesDto, LibraryContext db)
        {
            var languages = new List<Language>();

            foreach(var languageDto in languagesDto)
            {
                var language = db.Languages.FirstOrDefault(x => x.Name == languageDto);
                if(language == null)
                {
                    language = new Language()
                    {
                        Name = languageDto
                    };
                    db.Languages.Add(language);
                    db.SaveChanges();
                }

                languages.Add(language);
            }

            return languages;
        }

        private List<Author> GetAuthors(List<ApiBook.Model.Person> authorsDto, LibraryContext db)
        {
            var authors = new List<Author>();

            foreach (var authorDto in authorsDto)
            {
                var author = db.Authors.FirstOrDefault(x => x.Name == authorDto.Name && x.BirthYear == authorDto.BirthYear);
                if (author == null)
                {
                    author = new Author()
                    {
                        Name = authorDto.Name,
                        BirthYear = authorDto.BirthYear
                    };
                    db.Authors.Add(author);
                    db.SaveChanges();
                }

                authors.Add(author);
            }

            return authors;
        }
        private BookImage GetBookImage(int id, LibraryContext db)
        {
            try
            {
                var url = $"https://www.gutenberg.org/cache/epub/{id}/images/cover.jpg";
                var image = new BookImage()
                {
                    ContentType = "image/jpeg",
                    DateChanged = DateTime.Now,
                    Guid = Guid.NewGuid(),
                    FileName = "image.jpg",
                    Data = GetImage(url)
                };

                return image;
            }
            catch
            {
                return null;
            }
           
        }
        private byte[] GetImage(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception("Response is not successful");

            return response.RawBytes;
        }
    }
}