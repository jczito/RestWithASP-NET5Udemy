using RestWithASP_NET5Udemy.Data.Converter.Implamentations;
using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;

namespace RestWithASP_NET5Udemy.Data.Converter.Contract
{
    //IMPORTANTE LEMBRAR QUE NESTA PARTE PODEMOS ALTERAR E TRATAR OS DADOS QUE ESTAMOS INSERINDO
    //POR EXEMPLO, PODEMOS USAR UM ENUM PRA ALGUM TRUE OU FALSE, PODEMOS JUNTAR CAMPOS COMO AUTOR E TITULO
    //ESTE É O LOCAL PARA TRATAR OS VALORES ANTES DE SEREM CADASTRADOS.
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_date = origin.Launch_date,
                Price = origin.Price,
                Title = origin.Title
            };
        }
        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_date = origin.Launch_date,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
