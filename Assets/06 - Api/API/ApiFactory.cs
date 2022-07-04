using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class ApiFactory
{

    public static ApiContainer CreateStrapiContainer(ApiSettings settings)
    {
        ApiClient client = new StrapiClient(settings);
        ApiContainer container = new ApiContainer(client);
        container.Register<Entity>(new StrapiEntityDao());
        return container;
    }

    public static ApiContainer CreateDirectusContainer(ApiSettings settings)
    {
        ApiClient client = new DirectusClient(settings);
        ApiContainer container = new ApiContainer(client);
        container.Register<Entity>(new DirectusEntityDao());
        return container;
    }

}