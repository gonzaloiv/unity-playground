using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace IOC
{

    public static class Extensions
    {

        public static bool HasAttributeOfType(this object instance, Type type, bool inherit = true)
        {
            object[] attributes = instance.GetType().GetCustomAttributes(type, inherit);
            return attributes != null && attributes.Length > 0;
        }

    }

}