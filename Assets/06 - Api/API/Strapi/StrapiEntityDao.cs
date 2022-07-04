using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using RSG;
using UnityEngine;

public class StrapiEntityDao : IDao<Entity>
{

    public string Uri => "entities";
    public ApiClient ApiClient { get; set; }

    public Promise<Entity> Get(int id)
    {
        return ApiClient.Get<Entity>(Uri, id);
    }

}