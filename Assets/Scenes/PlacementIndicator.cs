using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class PlacementIndicator : MonoBehaviour
{

    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private Button dismissButton;

    [SerializeField]
    private Camera arCamera;

    private ARRaycastManager arRaycastManager;
    private GameObject visual;


    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        dismissButton.onClick.AddListener(Dismiss);
    }

    private void Dismiss() => welcomePanel.SetActive(false);

    void Start()
    {
        // get components
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        // hide the placement visual
        visual.SetActive(false);

    }
    void Update()
    {
        // do not capture events unless the welcome panel is hidden
        if (welcomePanel.activeSelf)
            return;

        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);


        // check if we hit the ar plane, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
    }
}
