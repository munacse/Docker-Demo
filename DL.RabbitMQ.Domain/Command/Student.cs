using System;

namespace DL.RabbitMQ.Domain.Command
{
    public class Student : IRabbitCommand
    {
        public Student()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
    }
}
