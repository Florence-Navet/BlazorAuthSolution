using Microsoft.AspNetCore.Mvc;

namespace BlazorAuth.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using BlazorAuth.Api.Models;

[ApiController]
[Route("api/[controller]")]
public class PhotoController : ControllerBase

{
    [HttpGet]
    public ActionResult<IEnumerable<Photo>> GetPhotos()
    {
        return Ok(new List<Photo>
        {
            new Photo { Id = 1, Url = "https://picsum.photos/200" },
            new Photo { Id = 2, Url = "https://picsum.photos/201" }
        });
    }
}
