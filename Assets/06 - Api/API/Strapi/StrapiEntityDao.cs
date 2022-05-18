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
        Promise<Entity> promise = new Promise<Entity>();
        RequestHelper requestHelper = new RequestHelper();
        requestHelper.Uri = ApiClient.Settings.baseUrl + "/" + Uri + "/" + id;
        RestClient.Get<Entity>(requestHelper)
            .Then(entity => promise.Resolve(entity))
            .Catch(promise.Reject);
        return promise;
    }

}