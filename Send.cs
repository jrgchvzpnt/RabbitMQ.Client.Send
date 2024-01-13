using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    internal class Send
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection()) 
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue:"hello",durable:true, exclusive:false,autoDelete:false,arguments:null);

                    string message = "Hola Mundo desde Send";
                    var body = Encoding.UTF8.GetBytes(message); 
                    channel.BasicPublish(exchange: "",routingKey:"hello",basicProperties:null, body:body);
                    Console.WriteLine($"[x] Sent {message}");
                }
            }
            Console.WriteLine("Press Any Key to Exit....");
            Console.ReadLine(); 
        }
       
    }
}
