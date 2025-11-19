namespace UnitTests;

[TestClass]
public class PostfixCalculatorTests
{
    const double tolerance = 1e-9; 

    [TestMethod]
    public void Postfix1()
    {

        Assert.AreEqual(4, PostfixCalculator.Program.Evaluate("2 2 +"));
    }

    [TestMethod]
    public void Postfix2()
    {

        Assert.AreEqual(8, PostfixCalculator.Program.Evaluate("5 3 +"));
    }

    [TestMethod]
    public void Postfix3()
    {

        Assert.AreEqual(2, PostfixCalculator.Program.Evaluate("7 5 -"));
    }

    [TestMethod]
    public void Postfix4()
    {

        Assert.AreEqual(1, PostfixCalculator.Program.Evaluate("5 3 1 + -"));
    }

    [TestMethod]
    public void Postfix5()
    {
        Assert.AreEqual(5, PostfixCalculator.Program.Evaluate("15 7 1 1 + - / 3 * 2 1 1 + + -"));
    }

    [TestMethod]
    public void Postfix6()
    {
        Assert.AreEqual(45, PostfixCalculator.Program.Evaluate("15 7 1 2 + - / 3 * 2 1 1 + + *"));
    }

    [TestMethod]
    public void Postfix7()
    {
        double actual = PostfixCalculator.Program.Evaluate("16 15 - 7 1 1 + - / 3 * 2 1 1 + + -").GetValueOrDefault();
        Assert.AreEqual(-3.4, (double)actual, tolerance);
    }

    [TestMethod]
    public void Postfix8()
    {
        double actual = PostfixCalculator.Program.Evaluate("51 32 + 82 - 6 /").GetValueOrDefault();
        Assert.AreEqual(1.0 / 6.0, actual, tolerance);
    }

    [TestMethod]
    public void Postfix9()
    {
        Assert.AreEqual(2030, PostfixCalculator.Program.Evaluate("54 62 + 2 / 35 *"));
    }

    [TestMethod]
    public void Postfix10()
    {
        Assert.AreEqual(23, PostfixCalculator.Program.Evaluate("10 2 8 * + 3 -"));
    }

    [TestMethod]
    public void Postfix11()
    {
        double actual = PostfixCalculator.Program.Evaluate("10 2 8 * + 3 - 3 * 2 - 0.67 +").GetValueOrDefault();
        Assert.AreEqual(67.67, actual, tolerance);
    }

    [TestMethod]
    public void PostfixNull1()
    {
        var result = PostfixCalculator.Program.Evaluate("");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void PostfixNull2()
    {
        var result = PostfixCalculator.Program.Evaluate("   ");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void PostfixNull3()
    {
        var result = PostfixCalculator.Program.Evaluate("-");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void PostfixNull4()
    {
        var result = PostfixCalculator.Program.Evaluate("1 -");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void PostfixNull5()
    {
        var result = PostfixCalculator.Program.Evaluate("1 + + -");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void PostfixNull6()
    {
        var result = PostfixCalculator.Program.Evaluate("3 4 5 6 7 8");

        Assert.IsNull(result);
    }
}


