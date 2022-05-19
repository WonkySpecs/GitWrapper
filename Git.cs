using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GitWrapper
{
    public class Git
    {
        private readonly string _repoDir;

        public Git(string repoDir)
        {
            _repoDir = repoDir;
        }

        public string Status() => Run("status");

        public string HeadRef(bool shortHash=true) =>
            Run("rev-parse", shortHash ? "--short" : "", "HEAD");

        public string Branch() => Run("rev-parse", "--abbrev-ref", "HEAD");

        public string Exec(string command) => Run(command);

        private string Run(params string[] args)
        {
            var command = string.Join(
                    " ",
                    new List<string>
                    {
                        $"--git-dir=\"{Path.Join(_repoDir, ".git")}\"",
                        $"--work-tree=\"{_repoDir}\"",
                    }.Concat(args));

            var p = new Process()
            {
                StartInfo = new ProcessStartInfo("git")
                {
                    Arguments = command,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                }
            };
            p.Start();
            var res = p.StandardOutput.ReadToEnd();
            p.Close();
            return res.Trim();
        }
    }
}
