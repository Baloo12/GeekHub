namespace GeekHub.VideoGames.Domain.Dtos
{
    public class CreateVideoGameRequestDto
    {
        public string Name { get; }

        public CreateVideoGameRequestDto(string name)
        {
            Name = name;
        }
    }
}