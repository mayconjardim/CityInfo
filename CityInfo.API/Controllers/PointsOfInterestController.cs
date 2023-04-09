using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {

        private readonly ILogger<PointsOfInterestController> _logger;

        private readonly IMailService _mailService;

        private readonly ICityInfoRepository _cityInfoRepository;

        private readonly IMapper _mapper;


        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService,
            ICityInfoRepository cityInfoRepository, IMapper mapper
            )
        {
            _logger = logger?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService;
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException( nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }


        [HttpGet]
        public async Task<ActionResult<List<PointOfInterestDto>>> GetPointsOfInterest(int cityId) {


            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                _logger.LogInformation($"Cidade com id {cityId} não existe!");
                return NotFound();
            }

            var pointsOfInterestForCity = await _cityInfoRepository.GetPointsOfInterestsForCityAsync(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));


        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(
          int cityId, int pointOfInterestId)
        {
            if (!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

      
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestCreationDto pointOfInterest) 
        {

            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId = cityId,
                pointOfInterestId = finalPointOfInterest.Id
            }, finalPointOfInterest);
        }
        /*
      
        [HttpPut("{pointofinterestid}")]
      public ActionResult UpdatePointOfInterest(int cityId, int pointofinterestid,
          PointOfInterestUpdateDto pointOfInterestUpdateDto  )
      {

          var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

          if (city == null)
          {
              return NotFound();
          }

          var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointofinterestid);
              if (pointOfInterestFromStore == null)
          {
              return NotFound();
          }

          pointOfInterestFromStore.Name = pointOfInterestUpdateDto.Name;
          pointOfInterestFromStore.Description = pointOfInterestUpdateDto.Description;

          return NoContent();

      }

      [HttpPatch("{pointofinterestid}")]
      public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointofinterestid,
          JsonPatchDocument<PointOfInterestUpdateDto> patchDocument)
      {
          var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

          if (city == null)
          {
              return NotFound();
          }

          var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointofinterestid);
          if (pointOfInterestFromStore == null)
          {
              return NotFound();
          }

          var pointOfInterestToPatch = new PointOfInterestUpdateDto()
          {
              Name = pointOfInterestFromStore.Name,
              Description = pointOfInterestFromStore.Description
          };

          patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

          if (!ModelState.IsValid)
          {
              return BadRequest(ModelState);
          }

          if (!TryValidateModel(pointOfInterestToPatch))
          {
              return BadRequest(ModelState);
          }

          pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
          pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;


          return NoContent();
      }


      [HttpDelete("{pointofinterestid}")]
      public ActionResult DeletePointOfInterest(int cityId, int pointofinterestid)
      {


          var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

          if (city == null)
          {
              return NotFound();
          }

          var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointofinterestid);
          if (pointOfInterestFromStore == null)
          {
              return NotFound();
          }

          string namePoint = pointOfInterestFromStore.Name;

         city.PointsOfInterest.Remove(pointOfInterestFromStore);
          _mailService.Send("Ponto de interesse deletado", $"O ponto de interesse {namePoint} foi" +
              $" deletado no dia de hoje " + DateTime.Now);
          return NoContent();


      }

      */

    }
}
