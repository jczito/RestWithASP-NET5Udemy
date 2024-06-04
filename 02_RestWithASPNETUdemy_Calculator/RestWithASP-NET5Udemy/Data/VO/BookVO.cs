using RestWithASP_NET5Udemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET5Udemy.Data.VO
{
   public class BookVO
   {
        // Até a versão 2.2 era assim que se ordenava [DataMember(Order = 1, Name = "ID")]
        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime Launch_date { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
     
    }
}
