using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/nin")]
public class NinController : Controller {
    
    
    //No quiero propiedades de las que estén encargados Juan Perez ni Ana Torres".
    [HttpGet("listar-agentes-perez-torres")]
    public IActionResult ListarAgenciasPerezFernandez(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<string> nombre_agenteNin = new List<string>();
        nombre_agenteNin.Add("Juan Pérez");
        nombre_agenteNin.Add("Ana Torres");

        var filtro = Builders<Inmueble>.Filter.Nin(x => x.NombreAgente, nombre_agenteNin);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }


 //Opciones de inmuebles que no sean de las agencias Garcia Propiedades ni Inmobiliaria Perez
    [HttpGet("listar-no-agencias")]
    public IActionResult ListarNoAgencias(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<string> agenciasNin = new List<string>();
        agenciasNin.Add("Fernández Inmuebles");
        agenciasNin.Add("Inmobiliaria Pérez");

        var filtro = Builders<Inmueble>.Filter.Nin(x => x.Agencia, agenciasNin);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    //Quiero propiedades que no cuenten con 2 o 3 pisos.
    [HttpGet("listar-no-2-o-3-pisos")]
    public IActionResult ListarNo2O3Pisos(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<int> pisosNin = new List<int>();
        pisosNin.Add(2);
        pisosNin.Add(3);

        var filtro = Builders<Inmueble>.Filter.Nin(x => x.Pisos, pisosNin);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }


    // No quiero propiedades que cuesten 1331777 ni 33421
    [HttpGet("listar-no-costos")]
    public IActionResult ListarNoCostos(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<int> costoNin = new List<int>();
        costoNin.Add(21331777);
        costoNin.Add(33421);

        var filtro = Builders<Inmueble>.Filter.Nin(x => x.Costo, costoNin);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }


    // Mostrar inmuebles que no tengan construidos 0 metros ni 526 metros
    [HttpGet("listar-no-metros-c")]
    public IActionResult ListarNoMetrosC(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        List<int> metros_construccionNin = new List<int>();
        metros_construccionNin.Add(0);
        metros_construccionNin.Add(526);

        var filtro = Builders<Inmueble>.Filter.Nin(x => x.MetrosConstruccion, metros_construccionNin);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }


}
