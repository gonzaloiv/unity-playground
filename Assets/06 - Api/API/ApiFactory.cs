using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class ApiFactory
{

    public static ApiClient CreateStrapiClient(ApiSettings settings)
    {
        ApiClient client = new StrapiClient();
        client.Settings = settings;
        client.Register<Entity>(new StrapiEntityDao());
        return client;
    }

    public static ApiClient CreateDirectusClient(ApiSettings settings)
    {
        ApiClient client = new DirectusClient();
        client.Settings = settings;
        client.Register<Entity>(new DirectusEntityDao());
        return client;
    }

}