using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    private GridScheme grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GridScheme(3, 2, 2f, new Vector3(-5, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            grid.setValue(0, 0, 28);
        }

        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Value read: " + grid.getValue(0, 0));
        }
    }
}
