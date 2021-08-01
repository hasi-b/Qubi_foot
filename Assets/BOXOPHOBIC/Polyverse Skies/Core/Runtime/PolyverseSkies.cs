// Cristian Pop - https://boxophobic.com/

using UnityEngine;
using Boxophobic.StyledGUI;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class PolyverseSkies : StyledMonoBehaviour
{

    bool Night = false;
    float timeStartedLerping;
    public float LerpTime = 5f;
    float time;
    public float speed = 2f;

    [StyledBanner(0.968f, 0.572f, 0.890f, "Polyverse Skies", "", "https://docs.google.com/document/d/1z7A_xKNa2mXhvTRJqyu-ZQsAtbV32tEZQbO1OmPS_-s/edit?usp=sharing")]
    public bool styledBanner;

    [StyledCategory("Scene", 5, 10)]
    public bool categoryScene;

    public GameObject sunDirection;
    public GameObject moonDirection;

    [StyledCategory("Time Of Day")]
    public bool categoryTime;

    [StyledMessage("Info", "The Time Of Day feature will interpolate between two Polyverse Skies materials. Please note that material properties such as textures and keywords will not be interpolated! You will need to enable the same features on both materials in order for the interpolation to work! Toggle Update Lighting to enable Unity's realtime environment lighting! ", 0, 10)]
    public bool categoryTimeMessage = true;

    public Material skyboxDay;
    public Material skyboxNight;
    [Range(0, 1)]
    public float timeOfDay = 0;

    [Space(10)]
    public bool updateLighting = false;

    [StyledSpace(5)]
    public bool styledSpace0;

    Material skyboxMaterial;

    void Start()
    {
        if (skyboxDay != null && skyboxNight != null)
        {
            skyboxMaterial = new Material(skyboxDay);
        }

        StartLerping();


    }

    void StartLerping()
    {
        timeStartedLerping = Time.time;
       

    }

    public float Lerp(float start,float end,float timeStartedLerping,float lerpTime)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageCompleted = timeSinceStarted / lerpTime;
        if(timeOfDay == 1.0f)
        {

        }
        //Debug.Log("Percentage" + percentageCompleted);
        float result = Mathf.Lerp(start,end,percentageCompleted);
        return result;

    }




    void Update()
    {
        if (sunDirection != null)
        {
            Shader.SetGlobalVector("GlobalSunDirection", -sunDirection.transform.forward);
        }
        else
        {
            Shader.SetGlobalVector("GlobalSunDirection", Vector3.zero);
        }

        if (moonDirection != null)
        {
            Shader.SetGlobalVector("GlobalMoonDirection", -moonDirection.transform.forward);
        }
        else
        {
            Shader.SetGlobalVector("GlobalMoonDirection", Vector3.zero);
        }

        if (skyboxDay != null && skyboxNight != null)
        {
            skyboxMaterial.Lerp(skyboxDay, skyboxNight, timeOfDay);
            RenderSettings.skybox = skyboxMaterial;
        }

        if (updateLighting)
        {
            DynamicGI.UpdateEnvironment();
        }


        /*  if (timeOfDay == 1.0f)
          {
              Night = true;
              StartLerping();
              Debug.Log("NIGHT TRUE");
          }
          if(timeOfDay == 0.0f)
          {
              Night = false;

              Debug.Log("NIGHT False");
          }



             timeOfDay = Lerp(0, 1, timeStartedLerping, LerpTime);
        */

        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageCompleted = timeSinceStarted / LerpTime;
        time = Mathf.PingPong(percentageCompleted*speed,1);
        Debug.Log("Time"+ time);
        timeOfDay = time;
       
           
            

       
        







    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (skyboxDay != null && skyboxNight != null)
        {
            skyboxMaterial = new Material(skyboxDay);
        }
    }
#endif
}
