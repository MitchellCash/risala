using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risala.OpenCollection.Reader.V1;
using SharpYaml.Serialization;

namespace Risala.OpenCollection.Tests.Reader.V1;

[TestClass]
public class OpenCollectionInfoTests
{
    private const string SampleFolderPath = "Reader/V1/Samples/OpenCollectionInfo/";

    [TestMethod]
    public void ParseBasicInfoShouldSucceed()
    {
        using var stream = Resources.GetStream(Path.Combine(SampleFolderPath, "basicInfo.yaml"));
        var yamlStream = new YamlStream();
        yamlStream.Load(new StreamReader(stream));
        var yamlNode = (YamlMappingNode)yamlStream.Documents[0].RootNode;

        // Act
        var openCollectionInfo = OpenCollectionV1Deserializer.LoadInfo(yamlNode);

        // Assert
        Assert.AreEqual(
            new OpenCollectionInfo
            {
                Name = "Basic Info",
                Summary = "Sample Summary",
                Version = "1.0.1",
            }, openCollectionInfo);
    }
}
