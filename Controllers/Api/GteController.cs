using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gte")]
public class GteController : Controller {

    
    [HttpGet("listar-baños")]
    public IActionResult ListarBanios(){
        // Dame aquellos inmuebles que cuenten con 1 o más baños.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gte(x => x.Banios, 1);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-500-metros")]
    public IActionResult ListarMetros(){
        //Quiero un listado de los documentos que tengan 500 metros de construcción o más.
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gte(x => x.MetrosConstruccion, 500);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-pisos")]
    public IActionResult ListarPisos(){
        //Proporciona los inmuebles que cuenten con 2 o más pisos
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gte(x => x.Pisos, 2);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-900-metros-terreno")]
    public IActionResult ListarMetrosTerrenos(){
        //Haz una lista de aquellos documentos que tengan 900 metros de terreno o una cantidad mayor a esa.
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gte(x => x.MetrosTerreno, 900);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

        [HttpGet("listar-costos")]
    public IActionResult ListarCostos(){
        //Se necesitan aquellos documentos de los inmuebles que cuesten 3 millones o mas
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Gte(x => x.Costo, 3000000);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }


}    