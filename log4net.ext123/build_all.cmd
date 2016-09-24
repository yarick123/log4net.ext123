set msbuild="%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe"
set nuget="C:\Documents and Settings\All Users\chocolatey\bin\NuGet.exe"

%msbuild% log4net.ext123.csproj /t:Build /p:Configuration="net20"
%msbuild% log4net.ext123.csproj /t:Build /p:Configuration="net30"
%msbuild% log4net.ext123.csproj /t:Build /p:Configuration="net40"
%msbuild% log4net.ext123.csproj /t:Build /p:Configuration="net45"

%nuget% pack log4net.ext123.nuspec