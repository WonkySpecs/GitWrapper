﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace gitdotnet
{
    public class Git
    {
        private readonly string _gitDir;

        public Git(string repoDir)
        {
            _gitDir = Path.Join(repoDir, ".git");
        }

        public string Status() => Run("status");

        public string HeadRef(bool shortHash=true) =>
            Run("rev-parse", shortHash ? "--short" : "", "HEAD");

        public string Branch() => Run("rev-parse", "--abbrev-ref", "HEAD");

        private string Run(params string[] args)
        {
            var command = string.Join(
                    " ",
                    new List<string> { $"--git-dir=\"{_gitDir}\"" }.Concat(args));
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
            return res;
        }
    }
}
