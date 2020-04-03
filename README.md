### Introduction

Brunsli project is from Google.  This project is compiled in MSVC C and C#.

[Google brunsli](https://github.com/google/brunsli)

<p align="center"><img alt="JPEG XL Logo" src="https://jpeg.org/images/jpegxl-logo.png" width="70px"><img alt="JPEG XL Logo" src="./doc/Windows_10_Logo.png" width="80px" height="100px"></p>
<br>

Microsoft Visual Studio C++, C# 2019:<br>
Platform toolset version: v142<br>
Windows SDK version C/C++: 10.0 latest installed version<br>
C# target framework: .NET Framework 4.7.2<br>
#### Dependencies:
1.) download  [Google brunsli](https://github.com/google/brunsli)<br>
2.) you check that, the brunsli project have brotli project in .\brunsli-master\third_party\brotli\ <br>
3.) download this project.<br>
JUST SO GOOD:<br>
<p align="center"><img alt="JPEG XL Logo" src="./doc/dirList.png" width="250px"></p>
<br>

#### Build instructions:
1.) Start Visual Studio 2019<br>
2.) Open Solution (sln): ./c/brunsli.sln : <br>
<p align="center"><img alt="JPEG XL Logo" src="./doc/VSSolution.png" width="250px"></p>
<br>

3.) F7 build solution<br>
##### Result, if the success compiled: <br>
###### C:<br>
brunsli.dll : .\c\x64\Release\ <br>
brunsli.lib static : .\c\x64\Release\ <br>
brotli.lib  static :  .\c\x64\Release\ <br>
cbrunsli.exe : .\c\cbrunsli\x64\Release\ <br>
dbrunsli.exe : .\c\dbrunsli\x64\Release\ <br>
###### C#:<br>
brunsli_net_wrapper.dll : \dotNet\brunsli_net_wrapper\x64\Release\ <br>
brunsli_test.exe : \dotNet\brunsli_test\bin\Release\ <br>

<p align="center"><img alt="JPEG XL Logo" src="./doc/result.png" width="550px" height="200px"></p>
<br>
