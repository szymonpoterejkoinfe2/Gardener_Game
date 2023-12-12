using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public class Spawner
    {
        public List<Point> spawnPoints;


        public Spawner() { }
        public Spawner(List<Point> tileSpawnPoints) { spawnPoints = tileSpawnPoints; }


        public void AddToList(Point point)
        {
            spawnPoints.Add(point);
        }

        public void ShowAvaliability(int pointType)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foreach (Point point in spawnPoints)
            {
                if (!point.haveAnimal && point.type == pointType)
                {
                    GameObject pointStatus = Instantiate(cube,point.transform);
                    //pointStatus.transform.position = point.transform.position;
                    pointStatus.transform.localScale = new Vector3(0.1f,0.2f,0.1f);
                    pointStatus.GetComponent<Renderer>().material.color = Color.green;
                    pointStatus.tag = "Avaliability";
                    pointStatus.name = "SpawnPoint";
                }
            }
            Destroy(cube);
        }

        public List<Point> FindAvaliablePoints(int pointType)
        {
            List<Point> avaliablePoints = new List<Point>();

            foreach (Point point in spawnPoints)
            {
                if (!point.haveAnimal && point.type == pointType)
                {
                    avaliablePoints.Add(point);
                }
            }
            return avaliablePoints;
        }

        public void HideAvaliability()
        {
            GameObject[] pointStatus = GameObject.FindGameObjectsWithTag("Avaliability");

            foreach (GameObject cube in pointStatus)
            {
                Destroy(cube);
            }
        }
    }

    public class Point
    {
        public int id;
        public bool haveAnimal;
        public Transform transform;
        public int type;
        public GameObject pointObject;

        public Point() { }
        public Point(int index, bool haveAnimal, Transform transform, int type, GameObject gameObject)
        {
            id = index;
            this.haveAnimal = haveAnimal;
            this.transform = transform;
            this.type = type;
            pointObject = gameObject;
        }

    }

    private SpawnPoint[] transforms;
    private List<GameObject> animals; //list with all animal prefabs
    private List<Point> avaliablePoints;
    private int animalID;
    private int pointIndex;
    private GameObject newAnimal, oldAnimal;

    public Spawner spawner;
    public List<Point> pointsList = new List<Point>();


    AnimalSpawner()
    {
        spawner = new Spawner(pointsList);
    }


    // Start is called before the first frame update
    void Start()
    {
        animals = FindObjectOfType<AnimalsHolder>().allAnimlas;
    }


    public void CreateObjects()
    {
        spawner.spawnPoints.Clear();

        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        int index = 0;
        foreach (GameObject spawnPointObject in spawnPointObjects)
        {
                SpawnPoint spawnPoint = spawnPointObject.GetComponent<SpawnPoint>();
                Point point = new Point(index, spawnPoint.haveObject, spawnPoint.position, spawnPoint.type,spawnPoint.iObject);
                spawner.AddToList(point);
                index++; 
        }

        Debug.Log($"spawn points found:  { spawner.spawnPoints.Count} ");
    }

    public void SetAnimalId(int animalID)
    {
        this.animalID = animalID;
    }

    public void FindAvaliablePoints(int animalType)
    {
        //To do: check if animal price <= money balance;

        spawner.ShowAvaliability(animalType);

        avaliablePoints = spawner.FindAvaliablePoints(animalType);

        if (avaliablePoints.Count == 0)
        {
            Debug.LogError("No empty points of this type");
        }
        else
        {
            pointIndex = 0;

            PlaceAnimal();
        }
        //To do: Close shop not allowing to place animal
    }

    public void PlaceInNextPoint()
    {
        if ((pointIndex + 1) > (avaliablePoints.Count - 1))
        {
            pointIndex = 0;
        }
        else
        {
            pointIndex++;
        }

        Destroy(oldAnimal);

        PlaceAnimal();
    }

    public void PlaceInPreviousPoint()
    {
        if ((pointIndex - 1) < (avaliablePoints.Count - 1))
        {
            pointIndex = (avaliablePoints.Count - 1);
        }
        else
        {
            pointIndex--;
        }

        Destroy(oldAnimal);

        PlaceAnimal();
    }

    private void PlaceAnimal()
    {
        newAnimal = Instantiate(animals[animalID], avaliablePoints[pointIndex].transform.position, Quaternion.identity, avaliablePoints[pointIndex].pointObject.GetComponentInParent<ObjectCharacteristics>().transform);

        oldAnimal = newAnimal.gameObject;
    }

    public void ConfirmNewAnimal()
    {
        oldAnimal = null;
        spawner.HideAvaliability();
    }

    public void QuitAnimal()
    {
        //Destroy(newAnimal.gameObject);
        Destroy(oldAnimal.gameObject);
        oldAnimal = null;
        spawner.HideAvaliability();
    }

}

