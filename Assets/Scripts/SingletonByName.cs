using Fusion;
using System.Linq;
using UnityEngine;

/**
 * Implements a singleton pattern in Unity:
 * makes sure that there is exactly one GameObject with the same name of the current one.
 * 
 * @author Erel Segal-Halevi
 * @since 2020-02
 */
public class SingletonByName : NetworkBehaviour
{
    public void OnStartClient()
    {
        Destroy(gameObject);
        Debug.Log("AFIKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
        /*
        string myName = gameObject.name;
        // The following line is based on code by Isaiah Kelly: http://answers.unity.com/answers/1252385/view.html
        GameObject[] otherObjectsWithSameName = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == myName).ToArray<GameObject>();
        if (otherObjectsWithSameName.Length > 1) {
            Destroy(gameObject);
        } else {
            NetworkObject.DontDestroyOnLoad(gameObject);
        }*/
    }
}
