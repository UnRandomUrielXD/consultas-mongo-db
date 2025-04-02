using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/eq")]
public class EqController : Controller {
    [HttpGet("listar-nombres-agentes")]
    public IActionResult ListarNombresAgentes(){
        // Muestra todos los registros cuyo nombre de agente sea "Juan Pérez".

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Eq(x => x.NombreAgente, "Juan Pérez");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-operaciones")]
    public IActionResult ListarOperaciones(){
        // Enlista aquellos documentos que estén en renta.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Renta");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-agencias")]
    public IActionResult ListarAgencias(){
        //Dame todos los inmuebles que estén bajo la agencia García propiedades.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Eq(x => x.Agencia, "García Propiedades");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-tipos")]
    public IActionResult ListarTipos(){
        //Muestra una lista de todos los registro de tipo Terreno

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }

    [HttpGet("listar-fechas")]
    public IActionResult ListarFechas(){
        //Lista aquellos inmuebles que contengan como fecha de publicación el 1 de Enero del 2025.

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

            var filtro = Builders<Inmueble>.Filter.Eq(x => x.FechaPublicacion, "2025-01-01");
            var lista = collection.Find(filtro).ToList();
            return Ok (lista);
    }
}
