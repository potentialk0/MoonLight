using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPositionNavMesh : MonoBehaviour
{
    
    NavMeshAgent agent;
    Vector3 dest;
    float stopDist;

    public GameObject obj;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		stopDist = agent.stoppingDistance;
	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Ground")
                {
                    dest = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    agent.SetDestination(dest);
                }
            }
        }

    }

    public bool HasArrived()
	{
        if (Vector3.Distance(dest, transform.position) <= stopDist) return true;
        return false;
	}

    float PathLength(NavMeshPath path)
    {
        if (path.corners.Length < 2)
            return 0;

        Vector3 previousCorner = path.corners[0];
        float lengthSoFar = 0.0F;
        int i = 1;
        while (i < path.corners.Length)
        {
            Vector3 currentCorner = path.corners[i];
            lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
            previousCorner = currentCorner;
            i++;
        }
        return lengthSoFar;
    }
}
