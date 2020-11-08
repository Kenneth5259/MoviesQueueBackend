using MovieQueueBackend.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MovieQueueBackend.Services
{

    public class QueueService {
        private readonly IMongoCollection<QueueItem> _items;

        public QueueService(IQueueDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<QueueItem>(settings.QueueCollectionName);
        }

        public List<QueueItem> Get() => _items.Find(item => true).ToList();

        public QueueItem Get(string id) => _items.Find<QueueItem>(item => item.Id == id).FirstOrDefault();

        public QueueItem Create(QueueItem item) {
            _items.InsertOne(item);
            return(item);
        }

        public void Remove(string id) => _items.DeleteOne(item => item.Id == id);
    }

   
}