using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Entity strapiEntity;
    public Entity directusEntity;

    private void Start()
    {
        GetStrapiEntity();
        GetDirectusEntity();
        GetStrapiEntityWithContainer();
    }

    private void GetStrapiEntity()
    {
        ApiSettings settings = ScriptableObject.CreateInstance<ApiSettings>();
        settings.baseUrl = "http://petiscos.apis.xoia.es";
        settings.username = "gonzaloiv";
        settings.password = "612345";
        ApiClient client = new StrapiClient(settings);
        client.Login()
            .Then(() =>
            {
                IDao<Entity> dao = new StrapiEntityDao();
                dao.ApiClient = client;
                dao.Get(78)
                    .Then(entity =>
                    {
                        strapiEntity = entity;
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
        ApiClient client = new DirectusClient(settings);
        client.Login()
            .Then(() =>
            {
                IDao<Entity> dao = new DirectusEntityDao();
                dao.Get(1)
                    .Then(entity =>
                    {
                        directusEntity = entity;
                    })
                    .Catch(Debug.LogException);
            })
            .Catch(Debug.LogException);
    }

    private void GetStrapiEntityWithContainer()
    {
        ApiSettings settings = ScriptableObject.CreateInstance<ApiSettings>();
        settings.baseUrl = "http://petiscos.apis.xoia.es";
        settings.username = "gonzaloiv";
        settings.password = "612345";
        ApiContainer container = ApiFactory.CreateStrapiContainer(settings);
        container.Login()
            .Then(() =>
            {
                container.Get<Entity>(78)
                    .Then(entity =>
                    {
                        strapiEntity = entity;
                    })
                    .Catch(Debug.LogException);
            })
            .Catch(Debug.LogException);
    }

}