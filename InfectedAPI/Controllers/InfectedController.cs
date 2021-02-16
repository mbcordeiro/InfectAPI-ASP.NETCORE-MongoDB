using InfectedAPI.Data.Collections;
using InfectedAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfectedAPI.Controllers
{
    [Route("api/[infected]")]
    [ApiController]
    public class InfectedController : ControllerBase 
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedsCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedsCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SaveInfected([FromBody] InfectedDto dto)
        {
            var infected = new Infected(dto.DateBirth, dto.Gender, dto.Latitude, dto.Longitude);

            _infectedsCollection.InsertOne(infected);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult GetInfected()
        {
            var infecteds = _infectedsCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infecteds);
        }
    }
}
