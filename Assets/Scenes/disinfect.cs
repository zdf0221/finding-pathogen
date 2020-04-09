using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disinfect : MonoBehaviour
{
    [SerializeField]
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(destroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destroy()
    {
        Debug.Log("Clicked!");
        GameObject[] virus = GameObject.FindGameObjectsWithTag("virus");

        foreach (GameObject o in virus)
        {
            Destroy(o);
        }
        
    }
}
