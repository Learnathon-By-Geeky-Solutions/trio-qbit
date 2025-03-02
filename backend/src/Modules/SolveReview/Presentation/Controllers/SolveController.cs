using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.Modules.SolveReview.Application.DTOs;
using backend.src.Modules.SolveReview.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Modules.SolveReview.Presentation.Controllers
{ 
    
    [ApiController]
    [Route("api/solve")]
    public class SolveController : ControllerBase
    {
        private readonly ISolveService _SolveService;

        public SolveController(ISolveService solveService) {

            _SolveService = solveService;

        }

        // CREATE /solve/add
        [HttpPost]
        [Route("/add")] 
        public async Task<IActionResult> Add([FromBody] CreateSolveDTO createSolveDTO) {
            bool result = await _SolveService.Add(createSolveDTO);
            if(result) {
                return Ok("Successfully Added");
            }
            return BadRequest("Unsuccessfull");
        } 

    }
}