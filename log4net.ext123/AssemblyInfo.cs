using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyDescription("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("log4net.ext123")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("01c99ed0-2f73-457c-b5b9-5214f8f01129")]
[assembly: AssemblyVersion("1.4.3.0")]

#if NET_3_5
[assembly: AssemblyTitle("log4net.ext123 for .NET Framework 3.5")]
#elif NET_4_0
[assembly: AssemblyTitle("log4net.ext123 for .NET Framework 4.0")]
#elif NET_4_5
[assembly: AssemblyTitle("log4net.ext123 for .NET Framework 4.5")]
#else
#error "one of symbols must be defined: NET_3_5 or NET_4_0 or NET_4_5"
#endif

#if Debug
[assembly: AssemblyConfiguration("Debug")]
#elif Release
[assembly: AssemblyConfiguration("Release")]
#else
#error "one of symbols must be defined: Debug or Release"
#endif