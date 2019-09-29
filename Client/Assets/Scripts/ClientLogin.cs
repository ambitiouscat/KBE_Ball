using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClientLogin : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        KBEngine.Event.registerOut(KBEngine.EventOutTypes.onCreateAccountResult, this, KBEngine.EventOutTypes.onCreateAccountResult);
        KBEngine.Event.registerOut(KBEngine.EventOutTypes.onLoginFailed, this, KBEngine.EventOutTypes.onLoginFailed);
        KBEngine.Event.registerOut("onLoginSuccess", this, "onLoginSuccess");
    }

    // Update is called once per frame
    void Update () {
		
	}

    private string Login_Account;
    private string Login_Password;

    public string Account_Value
    {
        set
        {
            Login_Account = value;
            print("ClientLogin::Account = " + Login_Account);
        }
    }

    public string Password_Value
    {
        set
        {
            Login_Password = value;
            print("ClientLogin::Password = " + Login_Password);
        }
    }

    public void Login()
    {
        print("ClientLogin:: Login .....");
        KBEngine.Event.fireIn(KBEngine.EventInTypes.login,Login_Account,Login_Password, new byte[] { });
    }

    public void Register()
    {
        print("ClientLogin:: Register .....");
        KBEngine.Event.fireIn(KBEngine.EventInTypes.createAccount, Login_Account, Login_Password, new byte[] { });
    }

    public void onCreateAccountResult(UInt16 retcode, byte[] datas)
    {
        print("ClientLogin::onCreateAccountResult ..... code = " + retcode + "datas = " + KBEngine.ServerErrorDescrs.serverErrs[retcode]);
    }

    public void onLoginFailed(UInt16 retcode)
    {
        print("ClientLogin::onLoginFailed ..... code = " + retcode);
    }

    public void onLoginSuccess()
    {
        print("ClientLogin::onLoginSuccess .....");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
