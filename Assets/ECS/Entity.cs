using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private static int _nextId = 0;
    private readonly int _id;
    private readonly Dictionary<Type, Component> _components;
    private GameObject _gameObject;

    public int Id => _id;
    public GameObject GameObject => _gameObject;

    private Entity()
    {
        _id = _nextId++;
        _components = new Dictionary<Type, Component>();
    }

    public static Entity NewEntity()
    {
        return new Entity();
    }

    public static Entity NewEntityGameObject(string name, params Type[] componentTypes)
    {
        Entity entity = NewEntity(); 
        
        entity._gameObject = new GameObject(name);
        entity._gameObject.AddComponent<EntityBehaviour>().Initialize(entity);
        
        foreach (var componentType in componentTypes)
        {
            entity._gameObject.AddComponent(componentType);
        }

        return entity;
    }
    
    public static Entity NewEntityPrefab(GameObject prefab)
    {
        Entity entity = new Entity();
        
        GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
        entity._gameObject = gameObject; 
        gameObject.name = "EntityPrefab_" + prefab.name;

        return entity;
    }

    public T Get<T>() where T : Component, new()
    {
        var type = typeof(T);
        
        if (!_components.TryGetValue(type, out var component))
        {
            component = new T();
            _components[type] = component;
        }

        return (T)component; 
    }
    
    public List<object> GetComponents()
    {
        if (_components.Count == 0)
        {
            return null; 
        }
        
        List<object> componentList = new List<object>(_components.Values);
        return componentList; 
    }
    
    public bool Has<T>() where T : Component
    {
        return _components.ContainsKey(typeof(T)); 
    }
}