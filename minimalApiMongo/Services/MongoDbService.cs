using MongoDB.Driver;

namespace minimalApiMongo.Services
{
    public class MongoDbService
    {
        /// <summary>
        /// Armazenar a configuracao da aplicacao
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Armazena uma referencia ao MongoDb
        /// </summary>
        private readonly IMongoDatabase _database;


        /// <summary>
        /// Contem a configuracao necessaria para acesso ao mongoDb
        /// </summary>
        /// <param name="configuration">Objeto contendo toda configuracao da aplicacao</param>
        public MongoDbService(IConfiguration configuration)
        {
            //Atribui a config recebida em _configuration
            _configuration = configuration;

            //Acessa a string de conexao
            _configuration.GetConnectionString("DbConnection");
            var connectionString = _configuration.GetConnectionString("DbConnection");

            //Transforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(connectionString);

            //Cria um client
            var mongoClient = new MongoClient(mongoUrl);

            //Obtem a referencia com o mongo
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Propriedade para acessar o banco de dados => retona os dados em _database
        /// </summary>
        public IMongoDatabase GetDatabase => _database;
    }
}
