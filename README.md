## .net 8 NativeAOT problem
It seems that the more commonly used MessagePack library has an issue with List<T> when publishing with NativeAOT.

I came across the Nerdbank alternative, which reportedly doesn't have this problem.

However, I noticed that publish times were significantly longer and the file sizes much larger when using Nerdbank.

While the program works fine, I’m hesitant to switch to Nerdbank for now due to these concerns.

**UPDATE:** The sizes are smalled and publish times are shorter, since **0.7.1-beta**. But I still would like it to be better.
I will try to keep up and test newer versions as they come.

**UPDATE 2:** In my real project I decided to create simpler dto models of my classes.
The dtos use arrays instead of lists and int instead of enum flags.

My domain models creates and can be created by the dto model. So MessagePack seems to work fine in my real project.

## Issue to track
https://github.com/AArnott/Nerdbank.MessagePack/issues/445

## Test
Run powershell script `publish_and_compare.ps1` to compare the results.

## Sizes
| Project           | Version     |  File                 | Size (MB) |
|-------------------|-------------|-----------------------|-----------|
| MessagePackCSharp | 3.1.3       | MessagePackCSharp.exe | 5.17      |
| MessagePackCSharp | 3.1.3       | MessagePackCSharp.pdb | 27.46     |
| MessagePackCSharp | 3.1.4       | MessagePackCSharp.exe | 5.18      |
| MessagePackCSharp | 3.1.4       | MessagePackCSharp.pdb | 27.47     |
| Nerdbank          | 0.6.27-beta | Nerdbank.exe          | 30.22     |
| Nerdbank          | 0.6.27-beta | Nerdbank.pdb          | 370.65    |
| Nerdbank          | 0.7.1-beta  | Nerdbank.exe          | 7.12      |
| Nerdbank          | 0.7.1-beta  | Nerdbank.pdb          | 42.64     |
| Nerdbank          | 0.8.1-rc    | Nerdbank.exe          | 7.12      |
| Nerdbank          | 0.8.1-rc    | Nerdbank.pdb          | 42.65     |
| Nerdbank          | 0.8.30-rc   | Nerdbank.exe          | 7.16      |
| Nerdbank          | 0.8.30-rc   | Nerdbank.pdb          | 42.66     |

## Does the program work after publishing to NativeAOT
| Project           | Version     | Works?   |
|-------------------|-------------|----------|
| MessagePackCSharp | 3.1.3       | ❌       |
| MessagePackCSharp | 3.1.4       | ❌       |
| Nerdbank          | 0.6.27-beta | ✅      |
| Nerdbank          | 0.7.1-beta  | ✅      |
| Nerdbank          | 0.8.1-rc    | ✅      |
| Nerdbank          | 0.8.30-rc   | ✅      |

## Publish times
Takes these numbers with a grain of salt, they vary every day.
### My specs
| Component | Specification                         |
|-----------|---------------------------------------|
| CPU       | AMD Ryzen 9 5950X 16-Core Processor   |
| MEM       | 64.0 GB                               |

### Result
| Project           | Version     | Time (s) |
|-------------------|-------------|----------|
| MessagePackCSharp | 3.1.3       | 8.7      |
| MessagePackCSharp | 3.1.4       | 11.5     |
| Nerdbank          | 0.6.27-beta | 32.0     |
| Nerdbank          | 0.7.1-beta  | 10.4     |
| Nerdbank          | 0.8.1-rc    | 10.6     |
| Nerdbank          | 0.8.30-rc   | 11.9     |
