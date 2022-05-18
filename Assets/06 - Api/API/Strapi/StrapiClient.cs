using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Proyecto26;
using RSG;
using UnityEngine;

public class StrapiClient : ApiClient
{

    #region Login 

    public override Promise Login()
    {
        JWT = string.Empty; // Always resets the token because Strapi has no logout method
        Promise promise = new Promise();
        WWWForm form = new WWWForm();
        form.AddField("identifier", Settings.username);
        form.AddField("password", Settings.password);
        RestClient.Post(new RequestHelper { Uri = Settings.baseUrl + "/auth/local", FormData = form })
            .Then((response) =>
            {
                JWT = JToken.Parse(response.Text) ["jwt"].ToString();
                promise.Resolve();
            })
            .Catch(error => promise.Reject(error));
        return promise;
    }

    #endregion

}