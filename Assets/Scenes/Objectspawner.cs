using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject welcomePanel;

    public GameObject objectToSpawn;
    public AudioSource audioSource;
    private PlacementIndicator placementIndicator;

    public static List<GameObject> virusList;
    // Start is called before the first frame update
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        virusList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!welcomePanel.activeSelf && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            audioSource.Play();
            virusList.Add(obj);
            obj.tag = "virus";
            /*
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
            {
                Destroy(o);
            }
            */
        }
    }
}
