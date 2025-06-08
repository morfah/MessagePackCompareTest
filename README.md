## Native AOT problem
I want to use Nerbank.MessagePack instead of the more common MessagePack library because I need to serialize List<T> and use NativeAOT.

But I noticed that the publish times where much longer, and the filesizes huge when I used Nerdbank.

At least the program works though. But I can't really use Nerdbank version for my project until it product acceptable filesizes.

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
