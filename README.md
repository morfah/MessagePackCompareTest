## .net 8 NativeAOT problem
It seems that the more commonly used MessagePack library has an issue with List<T> when publishing with NativeAOT.

I came across the Nerdbank alternative, which reportedly doesn't have this problem.

However, I noticed that publish times were significantly longer and the file sizes much larger when using Nerdbank.

While the program works fine, I’m hesitant to switch to Nerdbank for now due to these concerns.

## Test
Run powershell script `publish_and_compare.ps1` to compare the results.

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
