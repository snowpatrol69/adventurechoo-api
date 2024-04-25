using chooapi.Models;
using chooapi.Models.Data;
using chooapi.Utilities;
using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace chooapi.Repository
{
    public class PersonRepository:IPersonRepository
    {
        private readonly DapperDBContext context;

        public PersonRepository(DapperDBContext context)
        {
            this.context = context;
        }

        public async Task<List<Person>> GetAll()
        {
          
            using (var connection = this.context.CreateConnection())
            {
                var personlist = await connection.QueryAsync<Person>(StoredProcedures.SP_Get100Person, commandType: CommandType.StoredProcedure);
                return personlist.ToList();
            }
        }
    }
}
