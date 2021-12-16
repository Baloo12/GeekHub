namespace GeekHub.BoardGames.BggProvider.Domain.Tests.ValueObjects
{
    using System;

    using GeekHub.BoardGames.BggProvider.Domain.ValueObjects;

    using Xunit;

    public class PageSizeTests
    {
        [Theory]
        [InlineData(10, true)]
        [InlineData(100, true)]
        [InlineData(9, false)]
        [InlineData(101, false)]
        public void Validate(int value, bool isValid)
        {
            void CreateInstanceAction()
            {
                PageSize.From(value);
            }

            if (isValid)
            {
                CreateInstanceAction();
            }
            else
            {
                Assert.Throws<PageSizeOutOfRangeException>((Action)CreateInstanceAction);
            }
        }
    }
}
