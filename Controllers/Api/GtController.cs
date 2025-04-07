using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gt")]
public class GtController : Controller {

    
    [HttpGet("listar-baños")]
    public IActionResult ListarBanios(){
        // Enlista los registros que tengan más de dos baños.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gt(x => x.Banios, 2);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-mas-de-2millones")]
    public IActionResult Costo(){
        // Dame los inmuebles que cuesten más de dos millones.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gt(x => x.Costo, 2000000);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-mas-300-metros-terreno")]
    public IActionResult MetrosTerrenos(){
        // Quiero una lista de los documentos que tengan más de 300 metros de terreno.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gt(x => x.MetrosTerreno, 300);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-mas-1piso")]
    public IActionResult Pisos(){
        // Dame los inmuebles que tengan una cantidad de pisos mayor a 1.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gt(x => x.Pisos, 1);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-mas-400-metros-construccion")]
    public IActionResult MetrosConstruccion(){
        // Haz una lista de aquellos registros que tengan una cantidad de metros de construcción mayor a 400.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gt(x => x.MetrosConstruccion, 400);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

}
