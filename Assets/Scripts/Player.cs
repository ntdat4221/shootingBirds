using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject crossHair;
    bool m_isShooted;

    GameObject m_crossHairClone;

    private void Start()
    {
        Cursor.visible = false;
        if (crossHair)
           m_crossHairClone = Instantiate(crossHair, Vector3.zero, Quaternion.identity);

    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
           m_isShooted = true;
        }
        if (m_crossHairClone)
            m_crossHairClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }
   
}




