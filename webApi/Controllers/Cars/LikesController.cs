using Microsoft.AspNetCore.Mvc;
using CarZone.Services.Interfaces;

namespace CarZone.Controllers
{
    [Route("api/Cars/{carId:int}")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService likeService;

        public LikesController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        [HttpGet("Likes")]
        public int GetAllLikes(int carId)
         => likeService.GetCountOfLikes(carId);


        [HttpPost("Likes")]
        public int PostLike(int carId)
         => likeService.AddLike(carId);

        [HttpDelete("Unlike")]
        public int RemoveLIke(int carId)
         => likeService.RemoveLike(carId);
    }
}
