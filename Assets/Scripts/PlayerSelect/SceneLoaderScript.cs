using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    public string LevelText;

    public string LevelOption;

    public Text MapSelectionScreen;

    public Image POneSelect;

    public GameObject MapSelectorContainer;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "mapselector")
        {
            MapSelectionScreen.text = LevelText;
            MapSelectorContainer.GetComponent<MapOptionSelect>().Level = LevelOption;
        }
    }
}