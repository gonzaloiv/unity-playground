using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectusEntity
{

    public class Data
    {
        public int id;
    }

    public Data data = new Data();

}

public static class DirectusEntityExtensions
{

    public static Entity ToEntity(this DirectusEntity directusEntity)
    {
        return new Entity { id = directusEntity.data.id };
    }

    public static DirectusEntity FromEntity(this Entity entity)
    {
        DirectusEntity directusEntity = new DirectusEntity();
        directusEntity.data.id = entity.id;
        return directusEntity;
    }

}