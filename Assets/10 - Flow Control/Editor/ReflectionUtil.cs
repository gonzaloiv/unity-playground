using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

namespace FlowControl
{

    public static class ReflectionUtil
    {

        public static List<Type> GetTypes<T>()
        {
            List<Type> result = new List<Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                IEnumerable<Type> types = assembly.GetTypes()
                   .Where(type => type != typeof(T) && typeof(T).IsAssignableFrom(type));
                result.AddRange(types);
            }
            return result;
        }

    }

}

