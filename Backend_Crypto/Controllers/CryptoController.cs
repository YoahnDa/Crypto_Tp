using Microsoft.AspNetCore.Mvc;
using Backend_Crypto.Models;
using AutoMapper;
using Backend_Crypto.Dto;
using Backend_Crypto.Interfaces;
using Backend_Crypto.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Crypto.Controllers
{
    [Route("api/crypto")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly IMapper _mapper;

        public CryptoController(ICryptoRepository cryptoRepository, IMapper mapper)
        {
            _cryptoRepository = cryptoRepository;
            _mapper = mapper;
        }

        // GET: api/<Crypto>
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<CryptoDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllCrypto()
        {
            var cryptos = _mapper.Map<List<CryptoDto>>(_cryptoRepository.GetCrypto());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(cryptos);
        }

        // GET api/<Crypto>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CryptoDto))]
        [ProducesResponseType(404)]
        public IActionResult GetOneCrypto(int id)
        {
            if (!_cryptoRepository.CryptoExist(id))
                return NotFound();

            var crypto = _mapper.Map<CryptoDto>(_cryptoRepository.GetCrypto(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(crypto);
        }

        // POST api/<Crypto>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCrypto([FromBody] CryptoCreateData value)
        {
            if(value == null)
                return BadRequest(ModelState);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_cryptoRepository.findByName(value.name) != null || _cryptoRepository.findBySymbole(value.symbole) != null)
            {
                ModelState.AddModelError("error", "Le symbole ou le nom existe déjà");
                return StatusCode(422, ModelState);
            }

            if(!_cryptoRepository.CreateCrypto(value))
            {
                ModelState.AddModelError("error", "Erreur lors du sauvegarde");
                return StatusCode(500, ModelState);
            }

            return Ok("Nouveau crypto créer.");
        }

        
        [HttpPut]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateCrypto([FromBody] CryptoUpdateDto value)
        {
            if(value==null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_cryptoRepository.CryptoExist(value.IdCrypto))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var cryptoMap = _mapper.Map<Crypto>(value);

            if (!_cryptoRepository.updateCrypto(cryptoMap))
            {
                ModelState.AddModelError("error", "Erreur lors du sauvegarde");
                return StatusCode(500, ModelState);
            }

            return Ok("Update du crypto fini.");
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult deleteCrypto(int id)
        {
            if(!_cryptoRepository.CryptoExist(id))
                return NotFound();

            var cryptoDelete = _cryptoRepository.GetCrypto(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_cryptoRepository.removeCrypto(cryptoDelete))
            {
                ModelState.AddModelError("error", "Erreur lors du sauvegarde");
                return StatusCode(500, ModelState);
            }
            return Ok("Suppression effectué.");
        } 
    }
}
