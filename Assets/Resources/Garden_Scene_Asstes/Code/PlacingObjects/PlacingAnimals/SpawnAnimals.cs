using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    //Class stroing all points corresponding to its soil tile 
    public class AnimalCreator
    {
        string mySoilID;
        List<SpawnPoint> mySpawnPoints;

        //Constructors for AnimalCreator 
        public AnimalCreator() { }
        public AnimalCreator(string mySoilID, GameObject soil) {
            this.mySoilID = mySoilID;
            Point[] points = soil.transform.Find("Grid/ObjectPlacers").GetComponentsInChildren<Point>();

            mySpawnPoints = new List<SpawnPoint>();

            if (points.Length > 0)
            {
                foreach (Point point in points)
                {
                    mySpawnPoints.Add(new SpawnPoint(point.haveAnimal, point.myTransform, point.pointObject, point.soilID, point.pointID, point.pointEnvironment, point.pointAnimalSize));
                }

            }

        }

        // mySpawnPoints size getter
        public int GetNumberOfPoints()
        {
            return mySpawnPoints.Count;
        }

        //Generating Cubes: Red - Point occupied | Green - Point available
        public void ShowAvailability(AnimalAttributes animal)
        {
            List<SpawnPoint> sameTypePoints = new List<SpawnPoint>();

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foreach (SpawnPoint point in mySpawnPoints)
            {
                if (point.GetEnvironment() == animal.animalEnvironment && point.GetAnimalSize() == animal.animalSize)
                {
                    if (!point.GetHaveAnimal())
                    {
                        GameObject pointStatus = Instantiate(cube, point.GetTransform());
                        pointStatus.transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
                        pointStatus.GetComponent<Renderer>().material.color = Color.green;
                        pointStatus.tag = "Avaliability";
                        pointStatus.name = "SpawnPoint";
                    }
                    else
                    {
                        GameObject pointStatus = Instantiate(cube, point.GetTransform());
                        pointStatus.transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
                        pointStatus.GetComponent<Renderer>().material.color = Color.red;
                        pointStatus.tag = "Avaliability";
                        pointStatus.name = "SpawnPoint";

                    }

                    sameTypePoints.Add(point);
                }

            }

            mySpawnPoints = sameTypePoints;
            Destroy(cube);

        }

        //Destroying Cubes which show point status
        public void HideAvaliability()
        {
            GameObject[] pointStatus = GameObject.FindGameObjectsWithTag("Avaliability");

            foreach (GameObject cube in pointStatus)
            {
                Destroy(cube);
            }
        }

        //Extracting available points to separate list
        public List<SpawnPoint> FindAvaliablePoints()
        {
            List<SpawnPoint> avaliablePoints = new List<SpawnPoint>();

            foreach (SpawnPoint point in mySpawnPoints)
            {
                if (!point.GetHaveAnimal())
                {
                    avaliablePoints.Add(point);
                }
            }
            return avaliablePoints;
        }

    }

    //Class stroing all information about a single point
    public class SpawnPoint
    {
        bool haveAnimal;
        Transform myTransform;
        GameObject pointObject;
        string soilID;
        environment pointEnvironment;
        animalSize pointAnimalSize;
        int pointID;

        //Object constructors
        public SpawnPoint() { }
        public SpawnPoint(bool haveAnimal, Transform transform, GameObject pointObject, string soilID, int pointID, environment environment, animalSize animalSize)
        {
            this.haveAnimal = haveAnimal;
            myTransform = transform;
            this.pointObject = pointObject;
            this.soilID = soilID;
            pointEnvironment = environment;
            pointAnimalSize = animalSize;
            this.pointID = pointID;
        }

        //Getters
        public bool GetHaveAnimal()
        {
            return haveAnimal;
        }
        public Transform GetTransform()
        {
            return myTransform;
        }
        public GameObject GetPointObject()
        {
            return pointObject;
        }
        public environment GetEnvironment()
        {
            return pointEnvironment;
        }
        public animalSize GetAnimalSize()
        {
            return pointAnimalSize;
        }
        public string GetDecorationID()
        {
            return soilID;
        }
        public int GetPointID()
        {
            return pointID;
        }

        //Updating availability atatus of a point
        public void PointAvailable(bool availabilityStatus)
        {
            haveAnimal = !availabilityStatus;
            pointObject.GetComponent<Point>().haveAnimal = !availabilityStatus;
        }

    }

    public GameObject shopMenu, controlButtons, returnButton;
    private Dictionary<string, GameObject> animals; //Dictionary with all animal prefabs
    private List<SpawnPoint> avaliablePoints;
    private string animalID;
    private GameObject newAnimal, oldAnimal, soilObject;
    private AnimalCreator animalCreator;
    private int pointIndex = 0;

    [SerializeField]
    public List<AnimalInfo> placedAnimals;

    [SerializeField]
    SoilTiles soilTiles;

    [SerializeField]
    SaveSystem saveSystem;

    // Start is called before the first frame update
    void Start()
    {
        animals = FindObjectOfType<AnimalsHolder>().allAnimals;
        controlButtons.SetActive(false);
    }

    //Geting animal id from button
    public void SetAnimalId(string animalID)
    {
        this.animalID = animalID;
    }

    //Creating AnimalCreator and Searching for not occupied points then saving them into list, Instantiating first animal prefab
    public void FindAvaliablePoints()
    {
        //To do: check if animal price <= money balance
        
        soilObject = GameObject.FindGameObjectWithTag("MovedSoil");

        animalCreator = new AnimalCreator(soilObject.GetComponent<ObjectCharacteristics>().uniqueId, soilObject);

        animalCreator.ShowAvailability(animals[animalID].GetComponent<AnimalAttributes>());

        if (animalCreator.GetNumberOfPoints() > 0)
        {
            avaliablePoints = animalCreator.FindAvaliablePoints();
            if (avaliablePoints.Count <= 0)
            {
                shopMenu.SetActive(false);
            }
            else {
                shopMenu.SetActive(false);
                controlButtons.SetActive(true);
                PlaceAnimal(animalID, pointIndex);
            }
            
        }
        else {
            shopMenu.SetActive(false);
        }
    }

    //Instantiating new animal prefab object in world space
    private void PlaceAnimal(string animalId, int pointIndex)
    {
        newAnimal = Instantiate(animals[animalId], avaliablePoints[pointIndex].GetTransform().position, Quaternion.identity, avaliablePoints[pointIndex].GetTransform());
        newAnimal.transform.localScale = animals[animalId].GetComponent<AnimalAttributes>().myLocalScale;
        newAnimal.transform.localPosition = animals[animalId].GetComponent<AnimalAttributes>().myLocalPosition;
        oldAnimal = newAnimal.gameObject;
    }

    //Instantiating new animal prefab object in world space from Save
    private void PlaceAnimal(string animalId, int pointIndex, Point[] decorationPoints)
    {
        foreach (Point point in decorationPoints)
        {
            if (point.pointID == pointIndex)
            {
                newAnimal = Instantiate(animals[animalId], point.transform.position, Quaternion.identity, point.transform);
                newAnimal.transform.localScale = animals[animalId].GetComponent<AnimalAttributes>().myLocalScale;
                newAnimal.transform.localPosition = animals[animalId].GetComponent<AnimalAttributes>().myLocalPosition;

                point.haveAnimal = true;
            }
        }


    }

    //Instantiating new animal prefab object in in next available point, destroying old animal object
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

        PlaceAnimal(animalID, pointIndex);
    }

    //Instantiating new animal prefab object in in previous available point, destroying old animal object
    public void PlaceInPreviousPoint() 
    {
        if ((pointIndex - 1) < 0)
        {
            pointIndex = (avaliablePoints.Count - 1);
        }
        else
        {
            pointIndex--;
        }

        Destroy(oldAnimal);

        PlaceAnimal(animalID,pointIndex);
    }

    //Confirming animal object
    public void ConfirmNewAnimal()
    {
        avaliablePoints[pointIndex].PointAvailable(false);
        oldAnimal = null;
        animalCreator.HideAvaliability();
        pointIndex = 0;
        controlButtons.SetActive(false);

        AnimalInfo placedAnimal = new AnimalInfo(soilObject.GetComponent<ObjectCharacteristics>().uniqueId, avaliablePoints[pointIndex].GetDecorationID(), animalID, avaliablePoints[pointIndex].GetPointID());

        placedAnimals.Add(placedAnimal);

        returnButton.SetActive(true);

        saveSystem.SaveGroundAnimals();
    }

    //Rejecting animal object
    public void RejectAnimal()
    {
        Destroy(oldAnimal.gameObject);
        oldAnimal = null;
        pointIndex = 0;
        animalCreator.HideAvaliability();
        controlButtons.SetActive(false);
        returnButton.SetActive(true);
    }

    //Loading Animals From Save
    public void LoadAnimals(List<AnimalInfo> animalsToLoad)
    {

        if(animalsToLoad.Count > 0)
        {
            foreach (AnimalInfo animalInfo in animalsToLoad)
            {
                Point[] points =  soilTiles.allSoilTiles[animalInfo.soiTileID].GetComponent<MyObjectHolders>().myObjectHolders[animalInfo.decorationHolderID].GetComponentsInChildren<Point>();

                PlaceAnimal(animalInfo.animalID, animalInfo.pointID, points);
            }
        }

        placedAnimals = animalsToLoad;
    }

}

[System.Serializable]
public class AnimalInfo
{
    [SerializeField]
    public string soiTileID;
    [SerializeField]
    public string decorationHolderID; 
    [SerializeField]
    public string animalID; 
    [SerializeField]
    public int pointID; 

    public AnimalInfo(string soiTileID, string decorationHolderID, string animalID, int pointID)
    {
        this.soiTileID = soiTileID;

        this.decorationHolderID = decorationHolderID;

        this.animalID = animalID;

        this.pointID = pointID;
    }
    
    
}