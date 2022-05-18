using System.Collections;
using System.Collections.Generic;
using RSG;
using UnityEngine;

public interface IDao<T>
{
    ApiClient ApiClient { get; set; }
    string Uri { get; }
    Promise<T> Get(int id);
}