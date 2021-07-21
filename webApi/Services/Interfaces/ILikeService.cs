namespace CarZone.Services.Interfaces
{
    public interface ILikeService
    {
        int AddLike(int carId);
        int GetCountOfLikes(int carId);
        int RemoveLike(int carId);
    }
}
