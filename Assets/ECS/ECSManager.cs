using System.Collections.Generic;
using UnityEngine;

public class ECSManager : MonoBehaviour
{
    private List<Entity> _entities;
    private List<ECSSystem> _systems;

    public static ECSManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _entities = new List<Entity>();
        _systems = new List<ECSSystem>();
        
        foreach (var system in _systems)
        {
            system.Init();
        }
    }

    private void Update()
    {
        foreach (var system in _systems)
        {
            system.Update();
        }
    }

    private void OnDestroy()
    {
        foreach (var system in _systems)
        {
            system.Destroy();
        }
    }

    public void RegisterSystem(ECSSystem system)
    {
        _systems.Add(system);
    }

    public void RegisterEntity(Entity entity)
    {
        _entities.Add(entity);
    }

    public IEnumerable<Entity> GetEntities()
    {
        return _entities;
    }
}