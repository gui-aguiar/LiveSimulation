using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiveSimulation
{
    public class PipelineBuilder
    {
        public Pipeline BuildPipeline(string pipelineJson)
        {
            if (String.IsNullOrWhiteSpace(pipelineJson))
            {
                if (pipelineJson == null)
                    throw new ArgumentNullException("pipelineJson null");

                throw new ArgumentException("pipelineJson");
            }

            Pipeline pipeline = JsonSerializer.Deserialize<Pipeline>(pipelineJson);
            if (!PipelinaValidator.ValidatePipeline(pipeline)) {
                throw new InvalidDataException("Pipeline doesnt fill object requirementes");
            }
            
            return pipeline;
        }
    }
}
