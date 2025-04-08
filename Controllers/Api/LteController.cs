using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/lte")]
public class LteController : Controller {
    

    // Muestra la lista de los registros con 3 baños o menos.
    [HttpGet("listar-baños-3")]
    public IActionResult ListarBanios3(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lte(x => x.Banios, 3);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    // Lista todos los inmuebles con un costo de 1 millón o menor a 1 millón.
    [HttpGet("listar-costo-1-millon")]
    public IActionResult ListarCosto1Millon(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lte(x => x.Costo, 1000000);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    //Dame el listado de los documentos con 553 metros de terreno o menos.
    [HttpGet("listar-metros-t-553")]
    public IActionResult ListarMetrosT553(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosTerreno, 553);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }
   


 //Enlista los registros que tengan 1 pisos o menos.
    [HttpGet("listar-piso-1")]
    public IActionResult ListarPiso1(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lte(x => x.Pisos, 1);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }
 

 //Proporciona los inmuebles que tengan una cantidad de metros de construcción igual o menor a 322.
    [HttpGet("listar-metros-c-322")]
    public IActionResult ListarMetrosC322(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosConstruccion, 322);
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

  }