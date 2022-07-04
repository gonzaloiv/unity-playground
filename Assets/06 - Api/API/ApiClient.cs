using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using RSG;
using UnityEngine;

public abstract class ApiClient
{

    protected string jwt;

    public ApiSettings Settings { get; private set; }
    public string JWT
    {
        get => jwt;
        set
        {
            // In case you pass an empty string it gets empty, otherwise, it formats the token
            RestClient.DefaultRequestHeaders["Authorization"] = string.IsNullOrEmpty(value) ? string.Empty : "Bearer " + value;
            jwt = value;
        }
    }
    public bool IsLogged { get { return !string.IsNullOrEmpty(jwt); } }

    public ApiClient(ApiSettings settings)
    {
        this.Settings = settings;
    }

    public abstract Promise Login();

    public virtual Promise<T> Get<T>(string uri, int id)
    {
        Promise<T> promise = new Promise<T>();
        RequestHelper requestHelper = new RequestHelper();
        requestHelper.Uri = Settings.baseUrl + "/" + uri + "/" + id;
        RestClient.Get<T>(requestHelper)
            .Then(result => promise.Resolve(result))
            .Catch(promise.Reject);
        return promise;
    }

}