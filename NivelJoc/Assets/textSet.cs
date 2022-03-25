using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textSet : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update

    // Update is called once per frame
    public void OpenText()
    {
        if (text != null)
        {
            text.SetActive(true);
        }
    }
}
