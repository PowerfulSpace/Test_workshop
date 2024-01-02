using MongoDataAccess.DataAccesss;
using MongoDataAccess.Models;

//string connectionString = "mongodb://127.0.0.1:27017";
//string databaseName = "simple_db";
//string collectionName = "people";

//MongoClient client = new MongoClient(connectionString);
//IMongoDatabase db = client.GetDatabase(databaseName);
//IMongoCollection<PersonModel> collection = db.GetCollection<PersonModel>(collectionName);

//var person = new PersonModel { FirstName = "Tim", LastName = "Corey" };
//await collection.InsertOneAsync(person);

////Возвращает все записи
//var results = await collection.FindAsync(_ => true);

//foreach (var result in results.ToList())
//{
//    Console.WriteLine($"{result.Id}:{result.FirstName}:{result.LastName}");
//}



ChoreDataAccess db = new ChoreDataAccess();

await db.CreateUser(new UserModel() { FirstName = "Tim", LastName = "Corey" });

var users = await db.GetAllUsers();

var chore = new ChoreModel() 
{
    AssignedTo = users.First(),
    ChoreText = "Mow the Lawn",
    FrequencyInDays = 7
};

await db.CreateChore(chore);



Console.ReadLine();

//https://www.youtube.com/watch?v=exXavNOqaVo&ab_channel=IAmTimCorey

//46 51