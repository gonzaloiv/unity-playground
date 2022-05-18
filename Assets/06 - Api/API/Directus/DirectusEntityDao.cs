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
        RequestHelper requestHelper = new RequestHelper();
        requestHelper.Uri = ApiClient.Settings.baseUrl + "/" + Uri + "/" + id;
        RestClient.Get(requestHelper)
            .Then(response =>
            {
                DirectusEntity directusEntity = JsonConvert.DeserializeObject<DirectusEntity>(response.Text);
                promise.Resolve(directusEntity.ToEntity());
            })
            .Catch(promise.Reject);
        return promise;
    }

}