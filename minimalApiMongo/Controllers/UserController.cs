using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalApiMongo.Domains;
using minimalApiMongo.Services;
using MongoDB.Driver;

namespace minimalApiMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabase.GetCollection<User>("user");
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                var users = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(users);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> post(User user)
        {
            try
            {
                await _user.InsertOneAsync(user);
                return Ok(user);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(User user)
        {
            try
            {
                //Buscar por id (filtro)
                var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id);
                if (filter != null)
                {
                    //Substituindo o objeto buscado pelo novo objeto
                    await _user.ReplaceOneAsync(filter, user);

                    return Ok();
                }
                return NotFound();


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                //Buscar por id (filtro)
                var filter = Builders<User>.Filter.Eq(x => x.Id, id);
                if (filter != null)
                {
                    await _user.DeleteOneAsync(filter);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            try
            {
                var user = await _user.Find((x => x.Id == id)).FirstOrDefaultAsync();

                return user is not null ? Ok(user) : NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
