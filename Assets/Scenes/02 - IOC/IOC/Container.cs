using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace IOC
{

    public class Container
    {

        public List<object> dependecies = new List<object>();

        public void Register(object instance)
        {
            dependecies.Add(instance);
        }

        public void Unregister(object instance)
        {
            dependecies.Remove(instance);
        }

        public object Resolve(Type type)
        {
            foreach (object dependency in dependecies)
            {
                if (type.IsAssignableFrom(dependency.GetType()))
                {
                    return dependency;
                }
            }
            throw new KeyNotFoundException("Dependecy with type " + type.ToString() + " not found!");
        }

        public void FixDependecies(object instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object[] attributes = property.GetCustomAttributes(typeof(InjectAttribute), true);
                foreach (object attribute in attributes)
                {
                    Type type = property.PropertyType;
                    object value = Resolve(type);
                    if (value != null)
                    {
                        property.SetValue(instance, value);
                    }
                    else
                    {
                        throw new KeyNotFoundException("Dependecy with type " + type.ToString() + " not found!");
                    }
                }
            }
        }

        public void RegisterIfNeeded(object instance)
        {
            object[] attributes = instance.GetType().GetCustomAttributes(typeof(RegisterAttribute), true);
            if (attributes != null && attributes.Length == 1)
                Register(instance);
        }

    }

}