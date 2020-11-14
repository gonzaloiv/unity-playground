using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace IOC
{

    public class Container
    {

        public List<object> dependencies = new List<object>();

        public void Register(object instance)
        {
            dependencies.Add(instance);
        }

        public void Unregister(object instance)
        {
            dependencies.Remove(instance);
        }

        public object Resolve(Type type)
        {
            foreach (object dependency in dependencies)
            {
                if (type.IsAssignableFrom(dependency.GetType()))
                {
                    return dependency;
                }
            }
            throw new KeyNotFoundException("Dependecy of type " + type.ToString() + " not found!");
        }

        public void ResolveDependecies(object instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ResolveDependency(instance, property);
            }
        }

        private void ResolveDependency(object instance, PropertyInfo property)
        {
            Attribute attribute = property.GetCustomAttribute(typeof(InjectAttribute), true);
            if (attribute != null)
            {
                object dependency = Resolve(property.PropertyType);
                SetProperty(instance, property, dependency);
            }
        }

        private void SetProperty(object instance, PropertyInfo property, object value)
        {
            if (value != null)
            {
                property.SetValue(instance, value);
            }
            else
            {
                string type = property.PropertyType.ToString();
                throw new KeyNotFoundException("Dependency of type " + type + " not found!");
            }
        }

    }

}