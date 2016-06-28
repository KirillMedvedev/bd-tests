using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace bd.common
{
    internal class Caller
    {
        public Caller() : this(2)
        {
        }

        public Caller(int distance)
        {
            var stackFrame = new StackFrame(distance+1);
            var callingMethod = stackFrame.GetMethod();

            @namespace = callingMethod.DeclaringType.Namespace;
            callingAssembly = callingMethod.DeclaringType.Assembly;
        }

        public Assembly GetCallingAssembly()
        {
            return callingAssembly;
        }

        public string GerNamespace()
        {
            return @namespace;
        }

        public List<string> PredictPossibleResourceLocations(string resourceFileName)
        {
            var namespaceParts = @namespace.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var possibleResourcePaths = new List<string> { resourceFileName };

            var currentPrefix = namespaceParts.First();

            possibleResourcePaths.Add(currentPrefix + "." + resourceFileName);

            for (int index = 1; index < namespaceParts.Count; index++)
            {
                var namespacePart = namespaceParts[index];
                currentPrefix += "." + namespacePart;
                possibleResourcePaths.Add(currentPrefix + "." + resourceFileName);
            }

            possibleResourcePaths.Reverse();

            return possibleResourcePaths;
        }

        private Assembly callingAssembly;
        private string @namespace;
    }
}