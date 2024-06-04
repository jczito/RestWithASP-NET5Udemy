using RestWithASP_NET5Udemy.Data.Converter.Implamentations;
using RestWithASP_NET5Udemy.Data.Converter.Contract;
using RestWithASP_NET5Udemy.Data.VO;
using RestWithASP_NET5Udemy.Model;

namespace RestWithASP_NET5Udemy.Data.Converter.Contract
{
    //IMPORTANTE LEMBRAR QUE NESTA PARTE PODEMOS ALTERAR E TRATAR OS DADOS QUE ESTAMOS INSERINDO
    //POR EXEMPLO, PODEMOS USAR UM ENUM PRA ALGUM TRUE OU FALSE, PODEMOS JUNTAR CAMPOS COMO AUTOR E TITULO
    //ESTE É O LOCAL PARA TRATAR OS VALORES ANTES DE SEREM CADASTRADOS.
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };

        }

        public PersonVO Parse(Person origin)
        {

            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };

        }
        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
