using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;

namespace RestWithASP_NET5Udemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO FindByID(long id);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        void Delete(long id);

    }
}
