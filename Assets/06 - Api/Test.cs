using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Entity strapiEntity;
    public Entity directusEntity;

    private void Start()
    {
        ApiSettings settings = ScriptableObject.CreateInstance<ApiSettings>();
        settings.baseUrl = "http://petiscos.apis.xoia.es";
        settings.username = "gonzaloiv";
        settings.password = "612345";
        ApiClient client = ApiFactory.CreateStrapiClient(settings);
        client.Login()
            .Then(() =>
            {
                client.Get<Entity>(78)
                    .Then(entity =>  
                    {
                        strapiEntity = entity;
                        GetDirectusEntity();
                    })
                    .Catch(Debug.LogException);
            })
            .Catch(Debug.LogException);
    }

    private void GetDirectusEntity()
    {
        ApiSettings settings = ScriptableObject.CreateInstance<ApiSettings>();
        settings.baseUrl = "https://directus-dev.tiivii.com/sgra";
        settings.username = "aelthalion@gmail.com";
        settings.password = "612345";
        ApiClient client = ApiFactory.CreateDirectusClient(settings);
        client.Login()
            .Then(() =>
            {
                client.For<Entity>().Get(1)
                    .Then(entity =>  
                    {
                        directusEntity = entity;
                    })
                    .Catch(Debug.LogException);
            })
            .Catch(Debug.LogException);
    }

}