using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDapper
{
    public class Example
    {
        public Task<IEnumerable<Book>> GetBooks() => PostgreSqlDapperExecutor.QueryAsync<Book>("CONNECTION_STRING", new GetBooks());
    }

    public class GetBooks : PostgresSqlOperation
    {
        public override string Text => @"

            select * from public.books;
        ";
    }

    public class GetBookById : PostgresSqlOperation
    {
        public GetBookById(int id)
        {
            Parameters = new
            {
                id
            };
        }
        public override string Text => @"
            select * from public.books where id = @Id;
        ";
    }

    public record Book
    {
        public int Id { get; set; }
        public string Name { get; set; }    
    }
}
