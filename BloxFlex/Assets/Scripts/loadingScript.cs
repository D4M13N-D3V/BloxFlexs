using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class loadingScript : MonoBehaviour {
    public GameObject loadingBar;
    private AsyncOperation async = null; // When assigned, load is in progress.
    public string levelName="Main";
    void Start()
    {
        StartCoroutine(LoadALevel(levelName));
    }
    private IEnumerator LoadALevel(string levelName)
    {
        async = Application.LoadLevelAsync(levelName);
        yield return async;
    }
    void OnGUI()
    {
        if (async != null)
        {

            //GUI.DrawTexture(Rect(0, 0, 100, 50), emptyProgressBar);
            // GUI.DrawTexture(Rect(0, 0, 100 * async.progress, 50), fullProgressBar);
            loadingBar.GetComponent<TextMesh>().text = async.progress + "%";

        }
    }
}
