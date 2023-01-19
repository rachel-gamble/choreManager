namespace choreManager.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ChoresController : ControllerBase
{
    private readonly ChoresService _choresService;

    private readonly Auth0Provider _auth0provider;
    public ChoresController(ChoresService choresService, Auth0Provider auth0Provider)
    {
        _choresService = choresService;
        _auth0provider = auth0Provider;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Chore>> Create([FromBody] Chore choreData)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            Chore chore = _choresService.Create(choreData);
            chore.Creator = userInfo;
            return Ok(chore);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Chore>>> Get()
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            List<Chore> chores = _choresService.Get(userInfo?.Id);
            return Ok(chores);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
