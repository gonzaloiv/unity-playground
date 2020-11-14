using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class InjectAttribute : Attribute { }

}