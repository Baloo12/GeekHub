namespace GeekHub.BoardGames.BggProvider.Domain.Tests
{
    using GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Interfaces;

    using Xunit;

    public class BaseXmlEntityBuilderTests
    {
        [Fact]
        public void CreateNew_Build_GetNotNullEntity()
        {
            var fakeBuilder = new FakeBaseXmlEntityBuilder();
            var entity = fakeBuilder.Build();

            Assert.NotNull(entity);
        }

        [Fact]
        public void CreateNew_UpdateEntity_BuildUpdatedEntity()
        {
            var value = "somevalue";
            var fakeBuilder = new FakeBaseXmlEntityBuilder();
            var entity = fakeBuilder.WithProperty(value).Build();

            Assert.Equal(value, entity.Property);
        }

        [Fact]
        public void CreateWithCustomInitialization_Build_ReturnCustomValue()
        {
            var value = "somevalue";
            var builder = new CustomInitializationXmlEntityBuilder(value);
            var entity = builder.Build();

            Assert.Equal(value, entity.Property);
        }
    }

    public class CustomInitializationXmlEntityBuilder : BaseXmlEntityBuilder<FakeEntity>
    {
        public CustomInitializationXmlEntityBuilder(string value)
        {
            Entity.Property = value;
        }

    }

    public class FakeEntity
    {
        public string Property { get; set; }
    }

    public class FakeBaseXmlEntityBuilder : BaseXmlEntityBuilder<FakeEntity>
    {
        public IEntityBuilder<FakeEntity> WithProperty(string value)
        {
            Entity.Property = value;
            return this;
        }
    }
}
