using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.Utils
{
    public interface IVideoGameEntityBuilderFactory
    {
        IVideoGameEntityBuilder GetVideoGameEntityBuilder();
        
        IVideoGameEntityBuilder GetVideoGameEntityBuilder(VideoGame game);
    }
}