using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{ 
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlayedMovies { get; set; }
        public bool IsActive { get; set; } =true;
    }
}