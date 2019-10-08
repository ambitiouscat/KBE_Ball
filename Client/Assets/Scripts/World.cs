using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {


    public UnityEngine.GameObject m_AvatarPrefab;
    public UnityEngine.GameObject m_AvatarMainPrefab;
    public UnityEngine.GameObject m_FoodPrefab;
	// Use this for initialization
	void Start () {

        KBEngine.Event.registerOut("onSelfAvatarEnterWorld", this, "onSelfAvatarEnterWorld");
        KBEngine.Event.registerOut("onOtherAvatarEnterWorld", this, "onOtherAvatarEnterWorld");
        KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");
        KBEngine.Event.registerOut("onMoveSpeedChanged", this, "onMoveSpeedChanged");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onSelfAvatarEnterWorld(KBEngine.Entity entity)
    {
        var avatar = Instantiate(m_AvatarMainPrefab);
        entity.renderObj = avatar;
        avatar.GetComponent<AvatarView>().m_AvatarMain = entity as Avatar;
        Debug.Log("World::onSelfAvatarEnterWorld ... id = " + entity.id);
    }

    public void onOtherAvatarEnterWorld(KBEngine.Entity entity)
    {
        Debug.Log("World::onOtherAvatarEnterWorld ... ClassName = " + entity.className + " EntityId =  " + entity.id);
        
        if (entity.className == "Avatar")
        {
            GameObject PlayerAvt = Instantiate(m_AvatarPrefab);
            if (PlayerAvt == null)
                return;
            entity.renderObj = PlayerAvt;
            PlayerAvt.GetComponent<AvatarView>().m_Avatar = entity as Avatar;
        }
        else if(entity.className == "Food")
        {
            GameObject FoodAvt = Instantiate(m_FoodPrefab);
            if (FoodAvt == null)
                return;
            entity.renderObj = FoodAvt;
            FoodAvt.transform.position = new Vector3(entity.position.x, entity.position.z, entity.position.z);
        }
    }

    public void onLeaveWorld(KBEngine.Entity entity)
    {
        Debug.Log("World::onLeaveWorld ... classname = " + entity.className + entity.id);
        Destroy(entity.renderObj as GameObject);
    }

    public void onMoveSpeedChanged(KBEngine.Entity entity)
    {
        Debug.Log("World::onMoveSpeedChanged ... classname = " + entity.className + entity.id + "Speed = " + (entity as Avatar).MoveSpeed);
        if (entity.renderObj == null)
            return;
        //(entity.renderObj as AvatarView).m_Speed = (entity as Avatar).MoveSpeed;
        //(entity.renderObj as AvatarView).m_Speed这样写会报错，因为AvatarView是entity的一个组件
        (entity.renderObj as GameObject).GetComponent<AvatarView>().m_Speed = (entity as Avatar).MoveSpeed;

    }
}
