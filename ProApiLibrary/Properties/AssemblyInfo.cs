using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ProApiLibrary")]
[assembly: AssemblyDescription("C# client library for the Whitepages Pro API")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Whitepages")]
[assembly: AssemblyProduct("ProApiLibrary")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f39898c8-1aed-4265-b77e-2fdf591259ca")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.2.0.0")]
[assembly: AssemblyFileVersion("1.2.0.0")]

// the next line gives visibility to certain protected and internal members of this library
// to the Integration Tests class library
[assembly:InternalsVisibleTo("ProApiLibraryIntegrationTests")]
[assembly:InternalsVisibleTo("UnitTests")]
[assembly:InternalsVisibleTo("ProApiLibraryTests")]