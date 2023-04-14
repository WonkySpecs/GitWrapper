# Git Wrapper

A minimal wrapper API for `git`, useful for getting git information in .NET programs.

**Requires the `git` executable to be on your PATH.**

## How to use

Instantiate a `Git` instance with the path to the repository root to run git commands on that repo.

```csharp
var repo = new Git("/path/to/repo");
Console.WriteLine(repo.Branch());
// Writes ie. 'master'
```

### Commands

 - Git.Status - get the full `git status` output
 - Git.HeadRef - get the SHA for the current HEAD. By default, gives the shortened hash, use `shortHash=false` to get the full hash.
 - Git.Branch - get the currently active branch name.
 - Git.Exec - run an arbitrary git command, given as a string.
