using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPathfinding : MonoBehaviour
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int height;
    [SerializeField]
    private int mapNumber;
    Pathfinding pathfinding;
    // Start is called before the first frame update
    void Start()
    {
        pathfinding = new Pathfinding(width, height);
        if (mapNumber == 1) {
            setNonWalkableMap01();
        } else if (mapNumber == 2) {
            setNonWalkableMap02();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // For tests purposes
        // if (Input.GetMouseButtonDown(0)) {
        //     Vector3 mousePosition = getMouseWorldPosition();
        //     pathfinding.getGrid().getXY(mousePosition, out int x, out int y);

        //     // List<PathNode> path = pathfinding.findPath(0, 0, x, y);
        //     List<Vector3> path = pathfinding.findPath(Vector3.zero, mousePosition);

        //     if (path != null) {
        //         for(int i = 0;  i < path.Count - 1; i++) {
        //             Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 1f + Vector3.one * .5f, new Vector3(path[i+1].x, path[i+1].y) * 1f + Vector3.one * .5f, Color.green, 100f);
        //         }
        //     }
        // }
        // // For tests purposes
        // if (Input.GetMouseButtonDown(1)) {
        //     Vector3 mousePosition = getMouseWorldPosition();
        //     pathfinding.getGrid().getXY(mousePosition, out int x, out int y);
        //     PathNode pathNode = pathfinding.getNode(x, y);
        //     pathNode.setIsWalkable(!pathNode.isWalkable);
        // }
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

    private void setNonWalkableMap01() {
        pathfinding.getGrid().getValue(2,7).setIsWalkable(false);
        pathfinding.getGrid().getValue(6,7).setIsWalkable(false);
        pathfinding.getGrid().getValue(19,7).setIsWalkable(false);
    }

    private void setNonWalkableMap02() {
        pathfinding.getGrid().getValue(8,1).setIsWalkable(false);
        pathfinding.getGrid().getValue(8,2).setIsWalkable(false);
        pathfinding.getGrid().getValue(8,3).setIsWalkable(false);
        pathfinding.getGrid().getValue(8,4).setIsWalkable(false);
        pathfinding.getGrid().getValue(8,5).setIsWalkable(false);
        pathfinding.getGrid().getValue(8,6).setIsWalkable(false);

        pathfinding.getGrid().getValue(9,1).setIsWalkable(false);
        pathfinding.getGrid().getValue(9,2).setIsWalkable(false);
        pathfinding.getGrid().getValue(9,3).setIsWalkable(false);
        pathfinding.getGrid().getValue(9,4).setIsWalkable(false);
        pathfinding.getGrid().getValue(9,5).setIsWalkable(false);
        pathfinding.getGrid().getValue(9,6).setIsWalkable(false);

        pathfinding.getGrid().getValue(10,1).setIsWalkable(false);
        pathfinding.getGrid().getValue(10,2).setIsWalkable(false);
        pathfinding.getGrid().getValue(10,3).setIsWalkable(false);
        pathfinding.getGrid().getValue(10,4).setIsWalkable(false);
        pathfinding.getGrid().getValue(10,5).setIsWalkable(false);
        pathfinding.getGrid().getValue(10,6).setIsWalkable(false);

        pathfinding.getGrid().getValue(11,1).setIsWalkable(false);
        pathfinding.getGrid().getValue(11,2).setIsWalkable(false);
        pathfinding.getGrid().getValue(11,3).setIsWalkable(false);
        pathfinding.getGrid().getValue(11,4).setIsWalkable(false);
        pathfinding.getGrid().getValue(11,5).setIsWalkable(false);
        pathfinding.getGrid().getValue(11,6).setIsWalkable(false);
    }

    public Pathfinding getPathfinding() {
        return pathfinding;
    }
}
