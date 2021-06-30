using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace bLua
{
    public class ExampleList : MonoBehaviour
    {
        private List<string> sceneList = new List<string>()
        {
            "TowerScene",
            "ExampleScene",
            "WarScene",
            "UIScene",
        };

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }

        private void OnGUI()
        {
            for(int i = 0;  i <  sceneList.Count; ++i)
            {
                if (GUI.Button(new Rect(10, 10 + i * 32, 100, 28),  sceneList[i]))
                {
                    SceneManager.LoadScene(sceneList[i], LoadSceneMode.Single);
                    break;
                }
            }
        }

    }
}
