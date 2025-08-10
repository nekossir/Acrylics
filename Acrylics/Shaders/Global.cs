using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Acrylics.Shaders
{
    internal static class Global
    {

        private static string? _assemblyShortName;

        internal static Uri MakePackUri(string relativeFile)
        {
            string uriString = "pack://application:,,,/" + AssemblyShortName + ";component/" + relativeFile;
            return new Uri(uriString);
        }

        private static string AssemblyShortName
        {
            get
            {
                if (_assemblyShortName == null)
                {
                    Assembly a = typeof(Global).Assembly;
                    _assemblyShortName = a.ToString().Split(',')[0];
                }

                return _assemblyShortName;
            }
        }

    }
}
