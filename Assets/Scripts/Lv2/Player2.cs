using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float Reload;
    float m_curReLoad;

    public GameObject crossHair;
    bool m_isShooted;

    GameObject m_crossHairClone;

    private void Awake()
    {
        m_curReLoad = Reload;
    }

    private void Start()
    {
        Cursor.visible = false;
        if (crossHair)
            m_crossHairClone = Instantiate(crossHair, Vector3.zero, Quaternion.identity);

    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !m_isShooted)
        {
            Shoot(mousePos);
        }
        // da ban
        if (m_isShooted)
        {
            m_curReLoad -= Time.deltaTime;

            if (m_curReLoad <= 0)
            {
                m_isShooted = false;
                m_curReLoad = Reload;
            }

            GameGUIManager2.Ins.UpdateReload(m_curReLoad / Reload);
        }
        if (m_crossHairClone)
            m_crossHairClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }
    void Shoot(Vector3 mousePos)
    {
        m_isShooted = true;

        Vector3 shootDir = Camera.main.transform.position - mousePos;

        shootDir.Normalize();

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, shootDir);
        if (hits != null && hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                if (hit.collider && (Vector3.Distance((Vector2)hit.collider.transform.position, (Vector2)mousePos) <= 0.4f))
                {
                    Debug.Log(hit.collider.name);
                    Bird2 bird = hit.collider.GetComponent<Bird2>();

                    if (bird)
                    {
                        bird.Die();
                    }

                }
            }
        }
        CineController.Ins.ShakeTrigger();
        Audio.Ins.PlaySound(Audio.Ins.shooting);
    }



}
