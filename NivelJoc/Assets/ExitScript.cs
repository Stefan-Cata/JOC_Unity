using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Canvas;

    public void OpenCanvas()
    {
        Canvas.SetActive(false);
    }
}
