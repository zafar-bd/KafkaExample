using System;
using Confluent.Kafka;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Consumer";
            var config = new ConsumerConfig
            {
                GroupId = "gid-consumers-t",
                BootstrapServers = "localhost:9092"
            };

            using var consumer = new ConsumerBuilder<Null, string>(config).Build();
            consumer.Subscribe("temp-topic-with-t3");
            while (true)
            {
                var cr = consumer.Consume();
                Console.WriteLine(cr.Message.Value);
            }
        }
    }
}
