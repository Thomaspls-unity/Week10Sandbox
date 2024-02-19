using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CastARay : MonoBehaviour
{
    [SerializeField] private Transform eyePosition;
    [SerializeField] private float rayDistance = 5.0f;
    [SerializeField] private LayerMask colorLayer;
    [SerializeField] private LayerMask spawnLayer;

    [SerializeField] private Camera cam;

    [SerializeField] private GameObject objectToSpawn;

    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnGuy();
    }

    private void SpawnGuy()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, rayDistance, spawnLayer))
        {
            if (Input.GetKeyDown(KeyCode.E)) //INPUT
            {
                Instantiate(objectToSpawn, hit.point, Quaternion.identity);
            }
        }
    }

    private void RandomColor()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, rayDistance, colorLayer))
        {
            if (Input.GetKeyDown(KeyCode.E)) //INPUT
            {
                hit.transform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }
        }
    }

    private void SimpleRaycast()
    {
        Ray ray = new Ray(eyePosition.position, transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction, Color.green, Time.time);

        if (Physics.Raycast(ray, rayDistance, colorLayer))
        {
            Debug.Log("Raycast Active");

        }
        else
        {
            Debug.Log("Raycast Inactive");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(eyePosition.position, eyePosition.position + transform.forward * rayDistance);
    }
}
