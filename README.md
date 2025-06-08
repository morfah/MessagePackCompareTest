## Native AOT problem
It seems that the more commonly used MessagePack library has a problem with List<T> and publishing with NativeAOT.

I found the Nerdbank alternative, which supposedly does not have this issue.

However, I noticed that publish times were significantly longer, and the file sizes were much larger when using Nerdbank.

While the program works, I can't use the Nerdbank version for my project until it produces acceptable file sizes.

## Sizes
| Project           | File                  | Size (MB) |
|-------------------|-----------------------|-----------|
| MessagePackCSharp | MessagePackCSharp.exe | 5.17      |
| MessagePackCSharp | MessagePackCSharp.pdb | 27.46     |
| Nerdbank          | Nerdbank.exe          | 30.22     |
| Nerdbank          | Nerdbank.pdb          | 370.65    |

## Publish times
| Project           | Time (s) |
|-------------------|----------|
| MessagePackCSharp | 8.7      |
| Nerdbank          | 32.0     |
