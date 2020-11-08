namespace MovieQueueBackend.Models
{
    public class QueueDatabaseSettings : IQueueDatabaseSettings{
        public string QueueCollectionName {get; set;}
        public string ConnectionString {get;set;}
        public string DatabaseName {get;set;}
    }
    
    public interface IQueueDatabaseSettings {
        string QueueCollectionName {get; set;}
        string ConnectionString {get;set;}
        string DatabaseName{get;set;}
    }
}