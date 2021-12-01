namespace GeekHub.BoardGames.BggProvider.Domain.Tests.Common.DataClasses
{
    using System.Collections;
    using System.Collections.Generic;

    //IDEA: Extract to Common project
    public class EmptyStringsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                {
                    null
                };

            yield return new object[]
                {
                    string.Empty
                };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
