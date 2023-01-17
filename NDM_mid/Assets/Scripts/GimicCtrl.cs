using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicCtrl : MonoBehaviour
{
    public Camera cam;
    public GameObject newWall;
    public PlayerCtrl player1;

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            AddCube();
            RemoveCube();
        }
    }

    void AddCube()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f))
        {
            if(hit.collider.gameObject.tag == "GROUND" && player1.coin >= 7)            // add block
            {
                player1.coin = player1.coin - 7;
                StartCoroutine(Creat(newWall, hit));
            }
        }
    }

    void RemoveCube()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f))
        {
            if(hit.collider.gameObject.tag == "WALL" && player1.coin >= 5)
            {
                player1.coin = player1.coin - 5;
                StartCoroutine(Dest(hit));
            }
        }
    }

    IEnumerator Creat(GameObject obj, RaycastHit hit)
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 newPos = hit.transform.position;
        GameObject newBlock = Instantiate(newWall);
        newBlock.transform.position = newPos;
        newBlock.transform.Translate(hit.normal* 1f);

        yield return new WaitForSeconds(2.0f);
        Destroy(newBlock);
    }

    IEnumerator Dest(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.1f);
        hit.collider.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        hit.collider.gameObject.SetActive(true);
        Color customColor = new Color(0.651f, 0.651f, 0.651f, 1.0f);
        hit.collider.gameObject.GetComponentInChildren<Renderer>().material.color = customColor;
    }
}
