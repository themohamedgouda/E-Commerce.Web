using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Factories
{
    public static class ApiResponseFactory
    {
      public static IActionResult GenerateApiValidationErrorResponse(ActionContext Context)
        {
            var ValidationErrors = Context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new Shared.ErrorMoldels.ValidationError
                {
                    Field = x.Key,
                    Errors = x.Value.Errors.Select(e => e.ErrorMessage)
                })
                .ToList();
            var ValidationToReturn = new Shared.ErrorMoldels.ValidationToReturn
            {
                StatusCode = (int)System.Net.HttpStatusCode.BadRequest,
                Message = "Validation Errors",
                ValidationErrors = ValidationErrors
            };
            return new BadRequestObjectResult(ValidationToReturn);

        }

    }
}
