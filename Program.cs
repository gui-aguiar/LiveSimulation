// See https://aka.ms/new-console-template for more information

using LiveSimulation;

try
{
    var filePth = args[0];
    var fileReader = new FileReader();
    var fileData = fileReader.ReadFile(filePth);

    var pipelineBuilder = new PipelineBuilder();
    var pipeline = pipelineBuilder.BuildPipeline(fileData);

    Console.WriteLine("VALID");
}
catch
{
    Console.WriteLine("INVALID");
}



