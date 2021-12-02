namespace GeekHub.BoardGames.BggProvider.Domain.ValueObjects
{
    using System;

    using ValueOf;

    public class PageSize : ValueOf<int, PageSize>
    {
        private const int MaxPageSize = 100;

        private const int MinPageSize = 10;

        protected override void Validate()
        {
            if (Value is < MinPageSize or > MaxPageSize)
            {
                throw new PageSizeOutOfRangeException(Value);
            }
        }
    }

    public class PageSizeOutOfRangeException : Exception
    {
        public PageSizeOutOfRangeException(int value)
            : base($"Page size is out of range. Value is {value}.")
        {
        }
    }
}
