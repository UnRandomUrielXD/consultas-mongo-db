using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/lt")]
public class LtController : Controller {
    
    
    // Enlista los registros que tengan menos de dos baños.
    [HttpGet("listar-baños")]
    public IActionResult ListarBanios(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lt(x => x.Banios, 2);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    // Dame una lista de los documentos con un dato de los metros del terreno menor a 300.
    [HttpGet("listar-metros-t-300")]
    public IActionResult ListarMetrosT300(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosTerreno, 300);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    // -Consigue los registros que contengan menos de 150 metros de construcción.

    [HttpGet("listar-metros-c-150")]
    public IActionResult ListarMetrosC150(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosConstruccion, 150);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    // Muestra un listado de los inmuebles con una cantidad de pisos menor a 2

    [HttpGet("listar-pisos-2")]
    public IActionResult ListarPisos2(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lt(x => x.Pisos, 2);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    // Muestra una lista de los registros que cuesten menos de 2 millones

    [HttpGet("listar-costo-2-millones")]
    public IActionResult ListarCosto2Millones(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lt(x => x.Costo, 2000000);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }


}