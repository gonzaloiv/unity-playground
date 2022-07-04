using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Proyecto26;
using RSG;
using UnityEngine;

public class DirectusClient : ApiClient
{

    public DirectusClient(ApiSettings settings) : base(settings) { }

    public override Promise Login()
    {
        JWT = string.Empty;
        Promise promise = new Promise();
        WWWForm form = new WWWForm();
        form.AddField("Content-Type", "application/json");
        form.AddField("email", Settings.username);
        form.AddField("password", Settings.password);
        RequestHelper requestHelper = new RequestHelper { Uri = Settings.baseUrl + "/auth/authenticate", FormData = form };
        RestClient.Post(requestHelper)
            .Then(response =>
            {
                JWT = JToken.Parse(response.Text)["data"]["token"].ToString();
                promise.Resolve();
            })
            .Catch(error => promise.Reject(error));
        return promise;
    }

    

}