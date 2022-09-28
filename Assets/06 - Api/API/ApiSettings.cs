using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;

[CreateAssetMenu(fileName = "ApiSettings", menuName = "ApiClient/ApiSettings")]
public class ApiSettings : ScriptableObject
{
    public string baseUrl;
    public string username;
    public string password;
}