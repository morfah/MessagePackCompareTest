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
| Project           | Version     |  File                 | Size EXE (MB) | Size PDB (MB) | .NET target   |
|-------------------|-------------|-----------------------|---------------|---------------|---------------|
| MessagePackCSharp | 3.1.3       | MessagePackCSharp     | 5.17          | 27.46         | .net 8.0      |
| MessagePackCSharp | 3.1.4       | MessagePackCSharp     | 5.18          | 27.47         | .net 8.0      |
| MessagePackCSharp | 3.1.4       | MessagePackCSharp     | 4.26          | 18.6          | .net 10.0 RC1 |
| MessagePackCSharp | 3.1.4       | MessagePackCSharp     | 4.26          | 18.61         | .net 10.0 RC2 |
| Nerdbank          | 0.6.27-beta | Nerdbank              | 30.22         | 370.65        | .net 8.0      |
| Nerdbank          | 0.7.1-beta  | Nerdbank              | 7.12          | 42.64         | .net 8.0      |
| Nerdbank          | 0.8.1-rc    | Nerdbank              | 7.12          | 42.65         | .net 8.0      |
| Nerdbank          | 0.8.30-rc   | Nerdbank              | 7.16          | 42.66         | .net 8.0      |
| Nerdbank          | 0.9.12-rc   | Nerdbank              | 7.3           | 44.71         | .net 8.0      |
| Nerdbank          | 0.10.2-rc   | Nerdbank              | 7.29          | 44.71         | .net 8.0      |
| Nerdbank          | 0.10.42-rc  | Nerdbank              | 7.29          | 44.15         | .net 8.0      |
| Nerdbank          | 0.10.42-rc  | Nerdbank              | 6.13          | 31.55         | .net 10.0 RC1 |
| Nerdbank          | 0.11.8-rc   | Nerdbank              | 6.35          | 32.44         | .net 10.0 RC2 |

## Does the program work after publishing to NativeAOT
| Project           | Version     | Works? |
|-------------------|-------------|--------|
| MessagePackCSharp | 3.1.3       | ❌     |
| MessagePackCSharp | 3.1.4       | ❌     |
| Nerdbank          | 0.6.27-beta | ✅     |
| Nerdbank          | 0.7.1-beta  | ✅     |
| Nerdbank          | 0.8.1-rc    | ✅     |
| Nerdbank          | 0.8.30-rc   | ✅     |
| Nerdbank          | 0.9.12-rc   | ✅     |
| Nerdbank          | 0.10.2-rc   | ✅     |
| Nerdbank          | 0.10.42-rc  | ✅     |
| Nerdbank          | 0.11.8-rc   | ✅     |