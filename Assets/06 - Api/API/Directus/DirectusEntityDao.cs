using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Proyecto26;
using RSG;
using UnityEngine;

public class DirectusEntityDao : IDao<Entity>
{

    public string Uri => "items/entity";
    public ApiClient ApiClient { get; set; }

    public Promise<Entity> Get(int id)
    {
        Promise<Entity> promise = new Promise<Entity>();
        ApiClient.Get<DirectusEntity>(Uri, id)
            .Then(directusEntity => { promise.Resolve(directusEntity.ToEntity()); })
            .Catch(promise.Reject);
        return promise;
    }

}