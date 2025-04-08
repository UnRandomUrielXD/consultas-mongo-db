using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/ne")]
public class NeController : Controller {
    
//Quiero una lista con los inmuebles que no sean casas.
    [HttpGet("listar-no-casas")]
    public IActionResult ListarNoCasas(){

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Tipo, "Casa");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }


//Proporcionar los inmuebles que no sean de la agencia García Propiedades.
    [HttpGet("listar-no-garcia-propiedades")]
    public IActionResult ListarNoGarciaPropiedades(){

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Agencia, "García Propiedades");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }


//Dame lista de aquellos inmuebles que no sean de dos pisos
     [HttpGet("listar-no-piso-2")]
    public IActionResult ListarNoPiso2(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Pisos, 2);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }


//Aquellas propiedades que no estén a cargo del agente Juan Perez.
    [HttpGet("listar-no-juan-perez")]
    public IActionResult ListarNoJuanPerez(){

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Ne(x => x.NombreAgente, "Juan Perez");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

//No quiero inmobiliarios que cuenten con patio.
    [HttpGet("listar-no-tiene-patio")]
    public IActionResult ListarNoTienePatio(){

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Ne(x => x.TienePatio, true);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }


}
