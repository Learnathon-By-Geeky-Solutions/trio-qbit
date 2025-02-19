using backend.src.Modules.SolveReview.Domain.DTOs;
using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Application.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.src.Modules.SolveReview.Presentation.Controllers
{
        [ApiController]
        [Route("api/solve-review")]
        public class SolveReviewController : ControllerBase
        {
            private readonly ISolveRepository _solveReviewUseCase;

            public SolveReviewController(ISolveRepository solveReviewUseCase)
            {
                _solveReviewUseCase = solveReviewUseCase;
            }

            [HttpPost]
            [Route("create")]
            public async Task<IActionResult> CreateSolveReview([FromBody] CreateSolveRequestDto request)
            {               
                var solveDto = request.ToSolveDtoFromCreateSolveRequest();
                var response = await _solveReviewUseCase.CreateAsync(solveDto);
                return Ok(response.ToSolveDto());
            }

            [HttpGet]
            [Route("get/{id:guid}")]
            public async Task<IActionResult> GetSolveReview(Guid id)
            {
                var response = await _solveReviewUseCase.GetByIdAsync(id);
                if(response == null)
                {
                    return NotFound();
                }
                return Ok(response.ToSolveResponseDto());
            }

            [HttpGet]
            [Route("get-user-solve/{userId:guid}")]
            public async Task<IActionResult> GetSolvesByUserId(Guid userId)
            {
                var response = await _solveReviewUseCase.GetByUserIdAsync(userId);
                if(response == null)
                {
                    return NotFound();
                }
                return Ok(response.Select(solve => solve.ToSolveResponseDto()));
            }

            [HttpPut]
            [Route("update/{id:guid}")]
            public async Task<IActionResult> UpdateSolveReview([FromBody] UpdateSolveRequestDto request, [FromRoute] Guid id)
            {
                var solveDto = request.ToSolveDtoFromUpdateSolveRequest();
                var response = await _solveReviewUseCase.UpdateAsync(solveDto, id);
                if(response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            [HttpDelete]
            [Route("delete/{id:guid}")]
            public async Task<IActionResult> DeleteSolveReview(Guid id)
            {
                var response = await _solveReviewUseCase.DeleteAsync(id);
                if(response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
    }
}