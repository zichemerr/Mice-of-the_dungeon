using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaterials : MonoBehaviour
{
    private DoorController _doorPrefab;
    private ImporterController _importer;
    private Queue<Wall> _walls;
    private Queue<Box> _boxes;
    private Queue<PointSpawner> _pointsSpawner;
    
    private List<Box> _boxesList = new List<Box>();
    private List<Wall> _wallsList = new List<Wall>();
    private List<PointSpawner> _pointList = new List<PointSpawner>();
    
    public void Init()
    {
        _doorPrefab = Instantiate(D.Prefabs.Door.Exit);
        _importer = Instantiate(D.Prefabs.Door.Importer);
        
        _walls = new Queue<Wall>();
        _boxes = new Queue<Box>();
        _pointsSpawner = new Queue<PointSpawner>();

        for (int i = 0; i < 10; i++)
        {
            _walls.Enqueue(Instantiate(D.Prefabs.LevelObjects.Wall));
            _boxes.Enqueue(Instantiate(D.Prefabs.Box));
            _pointsSpawner.Enqueue(Instantiate(D.Prefabs.SpanwerPoint.PointSpawner));
        }
    }

    public DoorController GetDoor(Vector2 position, Quaternion rotation)
    {
        _doorPrefab.transform.position = position;
        _doorPrefab.transform.rotation = rotation;
        _doorPrefab.gameObject.SetActive(true);
        
        return _doorPrefab;
    }

    public ImporterController GetImporter(Vector2 position, Quaternion rotation)
    {
        _importer.transform.position = position;
        _importer.transform.rotation = rotation;
        _importer.gameObject.SetActive(true);
        
        return _importer;
    }

    public Wall GetWall(Vector2 position, Quaternion rotation, float width, float height)
    {
        if (_walls.Count <= 0)
            throw new NullReferenceException("No walls available");
            
        Wall wall = _walls.Dequeue();
        _wallsList.Add(wall);

        wall.SpriteRenderer.size = new Vector2(width, height);
        wall.transform.position = position;
        wall.transform.rotation = rotation;
        wall.gameObject.SetActive(true);
        
        return wall;
    }

    public Box GetBox(Vector2 position, Quaternion rotation)
    {
        if (_boxes.Count <= 0)
            throw new NullReferenceException("No walls available");

        Box box = _boxes.Dequeue();
        _boxesList.Add(box);

        box.transform.position = position;
        box.transform.rotation = rotation;
        box.gameObject.SetActive(true);
        
        return box;
    }

    public PointSpawner GetPointSpawner(Vector2 position, Quaternion rotation)
    {
        if (_pointsSpawner.Count <= 0)
            throw new NullReferenceException("No walls available");
        
        PointSpawner pointSpawner = _pointsSpawner.Dequeue();
        _pointList.Add(pointSpawner);
        
        pointSpawner.transform.position = position;
        pointSpawner.transform.rotation = rotation;
        pointSpawner.gameObject.SetActive(true);
        
        return pointSpawner;
    }

    
    public void ClearLevel()
    {
        for (int i = 0; i < _boxesList.Count; i++)
        {
            _boxesList[i].gameObject.SetActive(false);
            _boxes.Enqueue(_boxesList[i]);
        }

        for (int i = 0; i < _pointList.Count; i++)
        {
            _pointList[i].gameObject.SetActive(false);
            _pointsSpawner.Enqueue(_pointList[i]);
        }

        for (int i = 0; i < _wallsList.Count; i++)
        {
            _wallsList[i].gameObject.SetActive(false);
            _walls.Enqueue(_wallsList[i]);
        }
        
        _doorPrefab.gameObject.SetActive(false);
        _importer.gameObject.SetActive(false);
    }
}