using RestWithASP_NET5Udemy.Data.Converter.Contract;
using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Repository;
using RestWithASP_NET5Udemy.Data.VO;


namespace RestWithASP_NET5Udemy.Business.Implementations
{
    public class BookBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BookVO Create(BookVO Book)
        {
            var bookEntity = _converter.Parse(Book);
            bookEntity =_repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO Book)
        {
            var bookEntity = _converter.Parse(Book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
