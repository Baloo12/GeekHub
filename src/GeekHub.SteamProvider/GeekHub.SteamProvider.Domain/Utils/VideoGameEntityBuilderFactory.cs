using GeekHub.SteamProvider.Domain.Entities;

namespace GeekHub.SteamProvider.Domain.Utils
{
    public class VideoGameEntityBuilderFactory : IVideoGameEntityBuilderFactory
    {
        public IVideoGameEntityBuilder GetVideoGameEntityBuilder()
        {
            var builder = new VideoGameEntityBuilder();

            return builder;
        }

        public IVideoGameEntityBuilder GetVideoGameEntityBuilder(VideoGame game)
        {
            var builder = new VideoGameEntityBuilder(game);

            return builder;
        }
    }
}