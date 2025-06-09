## .net 8 NativeAOT problem
It seems that the more commonly used MessagePack library has an issue with List<T> when publishing with NativeAOT.

I came across the Nerdbank alternative, which reportedly doesn't have this problem.

However, I noticed that publish times were significantly longer and the file sizes much larger when using Nerdbank.

While the program works fine, I’m hesitant to switch to Nerdbank for now due to these concerns.

## Test
Run powershell script `publish_and_compare.ps1` to compare the results.

## Sizes
| Project           | Version     |  File                 | Size (MB) |
|-------------------|-------------|-----------------------|-----------|
| MessagePackCSharp | 3.1.3       | MessagePackCSharp.exe | 5.17      |
| MessagePackCSharp | 3.1.3       | MessagePackCSharp.pdb | 27.46     |
| Nerdbank          | 0.6.27-beta | Nerdbank.exe          | 30.22     |
| Nerdbank          | 0.6.27-beta | Nerdbank.pdb          | 370.65    |

## Publish times
### My specs
| Component | Specification                         |
|-----------|---------------------------------------|
| CPU       | AMD Ryzen 9 5950X 16-Core Processor   |
| MEM       | 64.0 GB                               |

### Result
| Project           | Version     | Time (s) |
|-------------------|-------------|----------|
| MessagePackCSharp | 3.1.3       | 8.7      |
| Nerdbank          | 0.6.27-beta | 32.0     |

## Does the program work after publishing to NativeAOT
| Project           | Version     | Works?   |
|-------------------|-------------|----------|
| MessagePackCSharp | 3.1.3       | [ ]      |
| Nerdbank          | 0.6.27-beta | [X]      |
