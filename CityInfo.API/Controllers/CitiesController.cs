﻿using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{

    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {

        private readonly CitiesDataStore _citiesDataStore;

        public CitiesController( CitiesDataStore citiesDataStore )
        {
            _citiesDataStore = citiesDataStore;
        }

        [HttpGet]
        public ActionResult<List<CityDto>> GetCities()
        {
            return Ok(_citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound() ;
            }

            return Ok(cityToReturn);
        }


    }
}
