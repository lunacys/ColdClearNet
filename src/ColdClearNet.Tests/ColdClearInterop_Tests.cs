using System;
using NUnit.Framework;

namespace ColdClearNet.Tests;

public class ColdClearInterop_Tests
{
    private IntPtr _bot;
    private Options _options;
    private Weights _weights;

    [SetUp]
    public void Setup()
    {
        _options = new Options();
        _weights = new Weights();
    }

    [TearDown]
    public void TearDown()
    {

    }

    [Test]
    public void Test_1()
    {

    }
}