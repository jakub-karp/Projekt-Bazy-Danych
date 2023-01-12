using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManager.Modele;
using MongoDB.Driver;

namespace GymManager.Komunikacja
{
    public class KomunikacjaZMongo
    {

        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabaseName = "db_silownia";
        private const string GymCardCollection = "RodzajKarnetu";
        private const string EmpCollection = "Pracownicy";
        private const string UserCollection = "Klienci";

        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        #region READ CLASS 
        public async Task<List<Klient>> GetAllUsers()
        {
            var usersCollection = ConnectToMongo<Klient>(UserCollection);
            var results = await usersCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<Pracownik>> GetAlLEmp()
        {
            var empCollection = ConnectToMongo<Pracownik>(EmpCollection);
            var results = await empCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<Karnet>> GetAllCards()
        {
            var gymCardCollection = ConnectToMongo<Karnet>(GymCardCollection);
            var results = await gymCardCollection.FindAsync(_ => true);
            return results.ToList();
        }


        #endregion


        #region CREATE CLASS 
        public Task CreateUser(Klient user)
        {
            var usersCollection = ConnectToMongo<Klient>(UserCollection);
            return usersCollection.InsertOneAsync(user);
        }

        public Task CreateCard(Karnet card)
        {
            var gymCardCollection = ConnectToMongo<Karnet>(GymCardCollection);
            return gymCardCollection.InsertOneAsync(card);
        }

        public Task CreateEmp(Pracownik emp)
        {
            var empCollection = ConnectToMongo<Pracownik>(EmpCollection);
            return empCollection.InsertOneAsync(emp);
        }

        #endregion


        #region UPDATE CLASS 
        public Task UpdateUser(Klient user)
        {
            var usersCollection = ConnectToMongo<Klient>(UserCollection);
            var filter = Builders<Klient>.Filter.Eq("Id", user.Id);
            return usersCollection.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }

        public Task UpdateCard(Karnet card)
        {
            var gymCardCollection = ConnectToMongo<Karnet>(GymCardCollection);
            var filter = Builders<Karnet>.Filter.Eq("Id", card.Id);
            return gymCardCollection.ReplaceOneAsync(filter, card, new ReplaceOptions { IsUpsert = true });
        }

        public Task UpdateEmp(Pracownik emp)
        {
            var empCollection = ConnectToMongo<Pracownik>(GymCardCollection);
            var filter = Builders<Pracownik>.Filter.Eq("Id", emp.Id);
            return empCollection.ReplaceOneAsync(filter, emp, new ReplaceOptions { IsUpsert = true });
        }

        #endregion


        #region DELETE CLASS 
        public Task DeleteUser(Klient user)
        {
            var usersCollection = ConnectToMongo<Klient>(UserCollection);
            return usersCollection.DeleteOneAsync(c => c.Id == user.Id);
        }

        public Task DeleteCard(Karnet card)
        {
            var gymCardCollection = ConnectToMongo<Karnet>(GymCardCollection);
            return gymCardCollection.DeleteOneAsync(c => c.Id == card.Id);
        }

        public Task DeleteEmp(Pracownik emp)
        {
            var empCollection = ConnectToMongo<Karnet>(GymCardCollection);
            return empCollection.DeleteOneAsync(c => c.Id == emp.Id);
        }

        #endregion
        public Task GetUser(Klient user)
        {
            var usersCollection = ConnectToMongo<Klient>(UserCollection);
            return usersCollection.FindAsync(c => c.Nazwisko == user.Id);
        }



     

    }
}
