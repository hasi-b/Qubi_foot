using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using DG.Tweening;

public class skinManger : MonoBehaviour
{
    // Start is called before the first frame update


    public LeanTweenType easetype;
    public List<Material> skins = new List<Material>();
    private int selectedSkin = 0;
    public GameObject playerSkin;
    private Material[] mats = new Material[2];
    public Camera cm;
    Vector3 rot = new Vector3(0,360,0);
    



    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;

        }
        mats[1] = playerSkin.GetComponent<MeshRenderer>().materials[1];
        mats[0] = skins[selectedSkin];
        playerSkin.GetComponent<MeshRenderer>().materials = mats;
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin<0)
        {
            selectedSkin = skins.Count-1;

        }
        mats[1] = playerSkin.GetComponent<MeshRenderer>().materials[1];
        mats[0] = skins[selectedSkin];
        playerSkin.GetComponent<MeshRenderer>().materials = mats;
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("Skin Number",selectedSkin);
        LevelLoader.Instance.LoadLevel();
        
    }

    private void OnEnable()
    {
        playerSkin.transform.DORotate(rot, 0.1f).SetLoops(-1, LoopType.Incremental);
        //cm.backgroundColor = Random.ColorHSV();
       // playerSkin.transform.DORotate(rot, 0.3f, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
        LeanTween.moveY(playerSkin,1f,1f).setLoopPingPong().setEase(easetype);
    }

}
