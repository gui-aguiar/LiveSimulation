namespace LiveSimulation
{
    public class Job
    {
        public string name { get; set; }
        public List<string> commands  { get; set; }
        public List<string> depends_on { get; set; }

        public Job() { }

        public Job(string name, List<string> commands, List<string> depends_on) {
            name = name ?? throw new ArgumentNullException(nameof(name));
            commands = commands ?? throw new ArgumentNullException(nameof(commands));
            depends_on = depends_on ?? new List<string>();
        }
    }
}