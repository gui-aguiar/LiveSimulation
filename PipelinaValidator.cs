
namespace LiveSimulation
{
    public class PipelinaValidator
    {
        public static bool ValidatePipeline(Pipeline pipeline)
        {
            validateProperties(pipeline);  // preciso de try catch ou melhor nem colocar ?
            
            if (HasJobDependingOnNotExistingJob(pipeline.jobs))
                return false;
            
            if(findCycle(pipeline.jobs))
                return false;

            return true;
        }

        private static bool findCycle(List<Job> jobs)
        {
            if (HasJobDependingOnItSelf(jobs)) 
                return true;

            if(jobs.Count == 1) 
                return false;

            var jobMap = jobs.ToDictionary(j => j.name);
            var visited = new HashSet<string>();
            var stack = new HashSet<string>();

            foreach (var job in jobs)
            {
                if (!visited.Contains(job.name))
                {
                    if (HasCycle(job.name, jobMap, visited, stack))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool HasCycle(string jobName, Dictionary<string, Job> jobMap, HashSet<string> visited, HashSet<string> stack)
        {
            if (stack.Contains(jobName))
            {
                return true;  // Cycle detected
            }

            if (visited.Contains(jobName))
            {
                return false; // Node has been fully processed
            }

            visited.Add(jobName);
            stack.Add(jobName);

            if (jobMap.TryGetValue(jobName, out var job))
            {
                foreach (var dependency in job.depends_on)
                {
                    if (HasCycle(dependency, jobMap, visited, stack))
                    {
                        return true;
                    }
                }
            }

            stack.Remove(jobName);  // Remove from stack after processing
            return false;
        }

        private static bool HasJobDependingOnItSelf(List<Job> jobs)
        {
            foreach (Job job in jobs)                
                if (job.depends_on != null && job.depends_on.Contains(job.name)) 
                    return true;
            
            return false;
        }

        private static bool HasJobDependingOnNotExistingJob(List<Job> jobs)
        {        
            foreach (Job job in jobs)
                if (job.depends_on != null)
                    foreach (string jobDependency in job.depends_on)
                        if (!jobs.Any(x => x.name == jobDependency))
                            return true;

            return false;
        }

        private static void validateProperties(Pipeline pipeline)
        {
            // validate if name is null or jobs conunt is null
            if (pipeline == null) throw new ArgumentNullException(nameof(pipeline));

            if (pipeline.name == null || string.IsNullOrEmpty(pipeline.name))
                throw new ArgumentNullException(nameof(pipeline.name));

            if (pipeline.jobs == null || pipeline.jobs.Count == 0)
                throw new ArgumentNullException(nameof(pipeline.jobs));
        }
    }
}
