using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSG;

public class ApiContainer : Locator
{

    private ApiClient client;

    public ApiContainer(ApiClient client)
    {
        this.client = client;
    }

    public virtual void Register<T>(IDao<T> dao)
    {
        base.Register<T>(dao);
        dao.ApiClient = client;
    }

    public virtual Promise Login()
    {
        return client.Login();
    }

    protected virtual IDao<T> For<T>()
    {
        return Get<T>() as IDao<T>;
    }

    public virtual Promise<T> Get<T>(int id)
    {
        return For<T>().Get(id);
    }

}