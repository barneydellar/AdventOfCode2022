using FluentAssertions;
using Lib;

namespace Tests;

public class LineBreakerTests
{
    [Test]
    public void BreaksLines()
    {
        LineBreaker.Break(Test.Input).Length.Should().Be(24);
    }
}