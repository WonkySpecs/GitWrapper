# Git Wrapper

Instantiate a `Git` instance with the path to the repository root to run git commands on the repo.

```csharp
var repo = new Git("/path/to/repo");
Console.WriteLine(repo.Branch());
// Writes ie. 'master'
```
