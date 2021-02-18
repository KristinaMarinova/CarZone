using System.Linq;
using WebCarsProject.Data;
using WebCarsProject.Services.Interfaces;

namespace WebCarsProject.Services
{
    public class LikeService : ILikeService
    {
        private readonly AppDbContext _context;
        private readonly UserContext _userContext;
        public LikeService(AppDbContext context, UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }
        public int AddLike(int carId)
        {
            var userId = _userContext.UserId;

            var car = _context.Cars.Where(x => x.Id == carId).SingleOrDefault();

            var liked = _context.Likes.SingleOrDefault(x => x.CarId == carId && x.UserId == userId);

            if (liked == null)
            {
                _context.Likes.Add(new Like
                {
                    CarId = carId,
                    UserId = userId
                });
                car.LikesCount++;
            }
            else
            {
                _context.Likes.Remove(liked);
                car.LikesCount--;
            }

            _context.SaveChanges();
            return car.LikesCount;
        }

        public int GetCountOfLikes(int carId)
        {
            return _context.Likes.Where(x => x.CarId == carId).Count();
        }

        public int RemoveLike(int carId)
        {
            var likeToRemove = _context.Likes.Where(x => x.CarId == carId && x.UserId == _userContext.UserId).SingleOrDefault();
            _context.Likes.Remove(likeToRemove);

            var car = _context.Cars.Where(x => x.Id == carId).SingleOrDefault();
            car.LikesCount--;

            _context.SaveChanges();

            return car.LikesCount;
        }
    }
}