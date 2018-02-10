using System.ComponentModel.DataAnnotations;

namespace DL.Consumer.Model
{
    public class StudentInfo
    {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public int Age { get; set; }
    }
}
