using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;

namespace RestWithASP_NET5Udemy.Business
{
    public interface IBooksBusiness
    {
        BookVO Create(BookVO book);

        BookVO FindByID(long id);

        List<BookVO> FindAll();

        BookVO Update(BookVO book);

        void Delete(long id);
    }
}
