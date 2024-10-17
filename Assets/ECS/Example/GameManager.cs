using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private Mesh _cubeMesh; 

    private void Start()
    {
        if (_cubeMesh == null)
        {
            _cubeMesh = CreateCubeMesh(); 
        }

        ECSManager ecsManager = gameObject.AddComponent<ECSManager>();
        
        MovementSystem movementSystem = new MovementSystem();
        ecsManager.RegisterSystem(movementSystem);
        
        Entity entity_empty = Entity.NewEntity();
        Entity entity = Entity.NewEntityGameObject("Player");
        Entity entity_prefab = Entity.NewEntityPrefab(_prefab);
        
        MeshFilter meshFilter = entity.GameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = _cubeMesh; 

        MeshRenderer meshRenderer = entity.GameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard")); 
        meshRenderer.material.color = Color.red; 
        
        PositionComponent positionComponent = entity.Get<PositionComponent>();
        
        List<object> components = entity.GetComponents();
        
        if (components != null)
        {
            foreach (var component in components)
            {
                Debug.Log($"Component: {component.GetType().Name}");
            }
        }
        else
        {
            Debug.Log("No components attached to this entity.");
        }

        ecsManager.RegisterEntity(entity_empty);
        ecsManager.RegisterEntity(entity);
        ecsManager.RegisterEntity(entity_prefab);
    }

    private Mesh CreateCubeMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3( 0.5f, -0.5f, -0.5f),
            new Vector3( 0.5f,  0.5f, -0.5f),
            new Vector3(-0.5f,  0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f,  0.5f),
            new Vector3( 0.5f, -0.5f,  0.5f),
            new Vector3( 0.5f,  0.5f,  0.5f),
            new Vector3(-0.5f,  0.5f,  0.5f)
        };
        mesh.triangles = new int[]
        {
            0, 2, 1, 0, 3, 2, 
            4, 5, 6, 4, 6, 7, 
            0, 1, 5, 0, 5, 4, 
            1, 2, 6, 1, 6, 5, 
            2, 3, 7, 2, 7, 6, 
            3, 0, 4, 3, 4, 7  
        };
        
        mesh.RecalculateNormals();
        return mesh;
    }
}
