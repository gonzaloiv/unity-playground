using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using RSG;
using UnityEngine;

public abstract class ApiClient : Locator
{

    protected string jwt;

    public ApiSettings Settings { get; set; }
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

    public virtual void Register<T>(IDao<T> instance)
    {
        base.Register<T>(instance);
        instance.ApiClient = this;
    }

    public virtual IDao<T> For<T>()
    {
        return Get<T>() as IDao<T>;
    }

    public virtual Promise<T> Get<T>(int id)
    {
        return For<T>().Get(id);
    }
    public abstract Promise Login();

}