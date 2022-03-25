using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Object_button : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    [SerializeField] private Material highlightMaterial;
    public GameObject canvas;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
        color = this.gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                canvas.SetActive(true);
                unityEvent.Invoke();
                Debug.Log("APASAT");
            }
        }
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            if (hit.collider.gameObject.GetComponent<Renderer>())
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
            gameObject.GetComponent<Renderer>().material.color = color;
    }
}
