using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/in")]
public class InController : Controller {
    
    
    //Lista todos los inmuebles que estén bajo las agencias "Inmobiliaria Pérez" y "Fernández Inmuebles".
    [HttpGet("listar-agencias-perez-fernandez")]
    public IActionResult ListarAgenciasPerezFernandez(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<string> agenciasIn = new List<string>();
        agenciasIn.Add("Fernández Inmuebles");
        agenciasIn.Add("Inmobiliaria Pérez");

        var filtro = Builders<Inmueble>.Filter.In(x => x.Agencia, agenciasIn);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    //Quiero los inmuebles que estén a cargo de las agentes "Ana Torres" y "María López".
    [HttpGet("listar-agentes-ana-maria")]
    public IActionResult ListarAgentesAnaMaria(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<string> agentesIn = new List<string>();
        agentesIn.Add("Ana Torres");
        agentesIn.Add("María López");

        var filtro = Builders<Inmueble>.Filter.In(x => x.NombreAgente, agentesIn);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    //Dame el registro de los inmuebles que cuenten con 1 y 2 baños.
    [HttpGet("listar-banios")]
    public IActionResult ListarBanios(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<int> baniosIn = new List<int>();
        baniosIn.Add(1);
        baniosIn.Add(2);

        var filtro = Builders<Inmueble>.Filter.In(x => x.Banios, baniosIn);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    //Proporciona propiedades que tengan 2 y 3 pisos.
    [HttpGet("listar-pisos")]
    public IActionResult ListarPisos(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<int> pisosIn = new List<int>();
        pisosIn.Add(2);
        pisosIn.Add(3);

        var filtro = Builders<Inmueble>.Filter.In(x => x.Pisos, pisosIn);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    //Se necesitan aquellos documentos que contengan la fecha del 1 de febrero de 2025 y la del 1 de marzo del 2025
    [HttpGet("listar-fechas")]
    public IActionResult ListarFechas(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<string> fechasIn = new List<string>();
        fechasIn.Add("2025-02-01");
        fechasIn.Add("2025-03-01");

        var filtro = Builders<Inmueble>.Filter.In(x => x.FechaPublicacion, fechasIn);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }
}