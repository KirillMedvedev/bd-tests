using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace bd.common
{
    public static class Resource
    {
        public static string ReadAsString(string resourceFileName)
        {
            var caller = new Caller();

            var possibleResourcePaths = caller.PredictPossibleResourceLocations(resourceFileName);
            var callingAssembly = caller.GetCallingAssembly();

            var manifestResourceNames = callingAssembly.GetManifestResourceNames();

            var resourcePath = possibleResourcePaths.Intersect(manifestResourceNames).FirstOrDefault();

            var resourceExistsInCallingAssembly = resourcePath != null;

            if (resourceExistsInCallingAssembly)
            {
                return ExtractString(callingAssembly, resourcePath);
            }

            var referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in referencedAssemblies)
            {
                var resources = assembly.GetManifestResourceNames();
                var resourceFullPath = resources.FirstOrDefault(r => r.EndsWith(resourceFileName));

                if (resourceFullPath != null)
                {
                    return ExtractString(assembly, resourceFullPath);
                }
            }

            throw ResourceResolveException(resourceFileName, callingAssembly, referencedAssemblies, caller);
        }

        private static string ExtractString(Assembly callingAssembly, string resourcePath)
        {
            using (var stream = callingAssembly.GetManifestResourceStream(resourcePath))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static Exception ResourceResolveException(string resourceFileName, Assembly callingAssembly, Assembly[] referencedAssemblies, Caller caller)
        {
            var referencedAssembliesNames = string.Join(", ", referencedAssemblies.Select(a => a.GetName().Name));
            var message = string.Format("Can't locate resource '{0}' in assembly '{1}' and it's referenced assemblies. Please, make sure resource file exists and is build as Embedded Resource.\r\n\r\n Resource resolution priority:\r\n1. First place where resource is supposed to be is in assembly '{1}' in '{2}' folder or in any of it's parent folders.\r\n2. Resolution proceeds in all referenced assemblies: {3}",
                                         resourceFileName, callingAssembly.GetName().Name, caller.GerNamespace(), referencedAssembliesNames);

            return new ResourceResolveException(message);
        }
    }
}
