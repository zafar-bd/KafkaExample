using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Producer";
            var config1 = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                //SecurityProtocol = SecurityProtocol.Plaintext
            };
            var employee = new
            {
                Id = 1,
                Name = "Lafiz"
            };

            string serializedEmployee = JsonConvert.SerializeObject(employee);
            using var producer = new ProducerBuilder<Null, string>(config1).Build();
            await producer.ProduceAsync("temp-topic-with-t3", new Message<Null, string> { Value = serializedEmployee });
            //producer.Flush(TimeSpan.FromSeconds(10));
            producer.Flush();
            Console.ReadKey();
        }
    }
}
