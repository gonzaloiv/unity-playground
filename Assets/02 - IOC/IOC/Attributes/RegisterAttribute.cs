using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class RegisterAttribute : Attribute { }

}