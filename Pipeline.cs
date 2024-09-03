#nullable enable
using System;
using System.Collections.Generic;

namespace LiveSimulation
{
    public class Pipeline
    {
        public string name {  get; set; }
        public List<Job> jobs { get; set; }

        public Pipeline() { }

        public Pipeline(string name, List<Job> jobs)
        {
            name = name ?? throw new ArgumentNullException(nameof(name));
            jobs = jobs ?? throw new ArgumentNullException(nameof(jobs));
        }
    }
}