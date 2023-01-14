
namespace CG.Blue.Extensions;

/// <summary>
/// This class is a test fixture for the <see cref="GuidExtensions"/>
/// class.
/// </summary>
[TestClass]
public class GuidExtensionsFixture
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.One"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_One()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.One);

        // Assert ...
        Assert.IsTrue(
            result == "AB868D4E28774F880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Two"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Two()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Two);

        // Assert ...
        Assert.IsTrue(
            result == "868D4E28774F880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Three"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Three()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Three);

        // Assert ...
        Assert.IsTrue(
            result == "8D4E28774F880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Four"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Four()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Four);

        // Assert ...
        Assert.IsTrue(
            result == "4E28774F880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Five"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Five()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Five);

        // Assert ...
        Assert.IsTrue(
            result == "28774F880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Six"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Six()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Six);

        // Assert ...
        Assert.IsTrue(
            result == "774F880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Seven"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Seven()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Seven);

        // Assert ...
        Assert.IsTrue(
            result == "4F880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Eight"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Eight()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Eight);

        // Assert ...
        Assert.IsTrue(
            result == "880FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Nine"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Nine()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Nine);

        // Assert ...
        Assert.IsTrue(
            result == "0FCFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Ten"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Ten()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Ten);

        // Assert ...
        Assert.IsTrue(
            result == "CFD04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Eleven"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Eleven()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Eleven);

        // Assert ...
        Assert.IsTrue(
            result == "D04688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Twelve"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Twelve()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Twelve);

        // Assert ...
        Assert.IsTrue(
            result == "4688EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Thirteen"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Thirteen()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Thirteen);

        // Assert ...
        Assert.IsTrue(
            result == "88EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Fourteen"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Fourteen()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Fourteen);

        // Assert ...
        Assert.IsTrue(
            result == "EC74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFileName(Guid, string, FolderLevels)"/>
    /// method generates a legal file name with a <see cref="FolderLevels.Fifteen"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFileName_Fifteen()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFileName(".txt", FolderLevels.Fifteen);

        // Assert ...
        Assert.IsTrue(
            result == "74.txt",
            "The file name was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.One"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_One()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.One);

        // Assert ...
        Assert.IsTrue(
            result == "96\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Two"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Two()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Two);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Three"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Three()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Three);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Four"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Four()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Four);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Five"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Five()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Five);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Six"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Six()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Six);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Seven"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Seven()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Seven);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Eight"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Eight()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Eight);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Nine"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Nine()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Nine);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\88\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Ten"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Ten()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Ten);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\88\\0F\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Eleven"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Eleven()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Eleven);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\88\\0F\\CF\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Twelve"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Twelve()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Twelve);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\88\\0F\\CF\\D0\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Thirteen"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Thirteen()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Thirteen);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\88\\0F\\CF\\D0\\46\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Fourteen"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Fourteen()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Fourteen);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\88\\0F\\CF\\D0\\46\\88\\",
            "The folder path was invalid!"
            );
    }

    // *******************************************************************

    /// <summary>
    /// This method ensures the <see cref="GuidExtensions.ToFolderPath(Guid, FolderLevels)"/>
    /// method generates a legal folder path with a <see cref="FolderLevels.Fifteen"/>
    /// plan.
    /// </summary>
    [TestMethod]
    public void GuidExtensions_ToFolderName_Fifteen()
    {
        // Arrange ...
        var guid = Guid.Parse("8D86AB96-284E-4F77-880F-CFD04688EC74");

        // Act ...
        var result = guid.ToFolderPath(FolderLevels.Fifteen);

        // Assert ...
        Assert.IsTrue(
            result == "96\\AB\\86\\8D\\4E\\28\\77\\4F\\88\\0F\\CF\\D0\\46\\88\\EC\\",
            "The folder path was invalid!"
            );
    }

    #endregion
}