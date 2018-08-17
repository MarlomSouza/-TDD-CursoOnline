using System;
using Xunit;

namespace CursoOnline.DominioTest._util
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        => Assert.Equal(exception.Message, message);
    }
}
