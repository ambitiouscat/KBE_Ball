using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarView : MonoBehaviour {

    [Range(0, 1.0f)]
    private bool __isMouseDown = false;
    private Vector3 __lastMouseDir = Vector3.zero;
    public float m_Speed = 0.1f;
    public Avatar m_Avatar;
    public Avatar m_AvatarMain;
	// Use this for initialization
	void Start () {
        Debug.Log("AvatarView::Start ... ");
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_AvatarMain == null)
            return;
        if (m_AvatarMain.isPlayer())
        {
            //Debug.Log("AvatarView::Update ... m_IsPlayer = " + m_IsPlayer);
            KBEngine.Event.fireIn("updatePlayer", gameObject.transform.position.x, gameObject.transform.position.z,
                gameObject.transform.position.y, gameObject.transform.rotation.y);
        }
        else
            transform.position = new Vector3(m_AvatarMain.position.x, m_AvatarMain.position.z, m_AvatarMain.position.z);

    }

    void FixedUpdate()
    {
        if (m_AvatarMain == null)
            return;
        if (!m_AvatarMain.isPlayer())
            return;
        //Debug.Log("AvatarView::FixedUpdate ... m_IsPlayer = " + m_IsPlayer);
        if (Input.GetMouseButtonDown(0))
        {
            __isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            __isMouseDown = false;
        }
        if (__isMouseDown)
        {
            if (m_AvatarMain.IsRun <= 0)
                m_AvatarMain.cellEntityCall.SetRun(1);
            Vector3 Movement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            Movement.z = 0.0f;
            if (Movement.magnitude <= 1.0)
            {
                __lastMouseDir = Vector3.zero;
                return;
            }
            Movement.Normalize();
            __lastMouseDir = Movement;
        }
        else if (m_AvatarMain.IsRun > 0)
            m_AvatarMain.cellEntityCall.SetRun(0);
        transform.position += __lastMouseDir * m_Speed * 0.1f;
    }
}
