using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class SqlData : MonoBehaviour
{
    private string urlConn = "http://localhost/projeto_mindchest/cadastro_mindchest/gamelogin.php";
    public InputField inpLogin;
    public InputField inpSenha;
    private string txtLogin;
    private string txtSenha;
    public Text status;

    public void BTNLogin()
    {
        StartCoroutine(Login());
    }
    
    
    IEnumerator Login()
    {
        txtLogin = inpLogin.text;
        txtSenha = inpSenha.text;

        if (inpSenha.text.Trim() != "" && inpLogin.text.Trim() != "")
        {
            WWWForm form = new WWWForm();
            form.AddField("usuario", txtLogin);
            form.AddField("senha", txtLogin);

            UnityWebRequest www = UnityWebRequest.Post(urlConn, form);
            print("Dados Enviados");
            yield return www.SendWebRequest();

            if (www.downloadHandler.text == "Falha")
            { 
                status.text = "Falha";
            }
            else
            {
                status.text = "Sucesso";

            }
            print(www.downloadHandler.text);
            
            www.Dispose();
        }
    }
}
