using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPathfinding : MonoBehaviour
{
    Pathfinding pathfinding;
    // Start is called before the first frame update
    void Start()
    {
        pathfinding = new Pathfinding(3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // For tests purposes
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = getMouseWorldPosition();
            pathfinding.getGrid().getXY(mousePosition, out int x, out int y);

            List<PathNode> path = pathfinding.findPath(0, 0, x, y);

            if (path != null) {
                for(int i = 0;  i < path.Count - 1; i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 1f + Vector3.one * .5f, new Vector3(path[i+1].x, path[i+1].y) * 1f + Vector3.one * .5f, Color.green, 100f);
                }
            }
        }
    }

    private Vector3 getMouseWorldPosition() {
        Vector3 position = getMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        position.z = 0f;
        return position;
    }

    private Vector3 getMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
