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

}    