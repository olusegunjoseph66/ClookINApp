using ClockINVerraki.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClockINVerraki.DbContext
{
    public class ClockinDBContext<T> where T : class
    {
            private readonly IMongoCollection<T> _collection;
            private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public ClockinDBContext(string connectionString, string databaseName, string collectionName)
            {
                try
                {
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase(databaseName);
                    _collection = database.GetCollection<T>(collectionName);
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to initialize MongoDB connection: " + ex.Message);
                }
            }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            try
            {
            return  await _collection.Find(filterBuilder.Empty).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _collection.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                //FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
                //return await _collection.Find(filter).FirstOrDefaultAsync();
                return await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching item by ID: " + ex.Message);
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                //FilterDefinition<T> filter = filterBuilder.Eq(entity => entity.Id, id);
                //return await _collection.Find(filter).FirstOrDefaultAsync();
                return await _collection.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching item by ID: " + ex.Message);
            }
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting entity: " + ex.Message);
            }
        }

        public async Task UpdateAsync(int id, T entity)
        {
            try
            {
                await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating entity: " + ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting entity: " + ex.Message);
            }
        }
    }
}
