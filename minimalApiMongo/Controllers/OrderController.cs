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
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<Client> _client;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {

                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();
                
                foreach (var order in orders)
                {
                    if (order.ProductId != null)
                    {
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductId);

                        order.Products = await _product.Find(filter).ToListAsync();
                    }

                    if(order.ClientId != null)
                    {
                        order.Client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                    }
                }
                return Ok(orders);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> post(Order order)
        {
            
            try
            {
                Order orderNew = new Order();

                orderNew.Id = order.Id;
                orderNew.Date = order.Date;
                orderNew.Status = order.Status;
                orderNew.ProductId = order.ProductId;
                orderNew.ClientId = order.ClientId;
                

                var client = await _client.Find(x => x.Id == orderNew.ClientId).FirstOrDefaultAsync();
                if (client == null)
                {
                    return NotFound();
                }
                orderNew.Client = client;
                await _order!.InsertOneAsync(orderNew);
                return Ok(orderNew);


            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                //Buscar por id (filtro)
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
                if (filter != null)
                {
                    await _order.DeleteOneAsync(filter);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            try
            {
                //Buscar por id (filtro)
                var filter = Builders<Order>.Filter.Eq(x => x.Id, order.Id);
                if (filter != null)
                {
                    //Substituindo o objeto buscado pelo novo objeto
                    await _order.ReplaceOneAsync(filter, order);

                    return Ok();
                }
                return NotFound();


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
