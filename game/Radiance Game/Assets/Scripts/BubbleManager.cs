using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour {

    public ParticleSystem[] particleSystems;
    //public float defButtonStrength = 0.5f;

    private ButtonEvent button;
    public GameObject buttonHandler;
    private WaterLevel wl;
    private bool init = false;

    // Start is called before the first frame update
    void Start()
    {
        InitializeButtonControls();
        for (int i=0; i<particleSystems.Length; i++){
            particleSystems[i].Stop();
        }
        wl = GameObject.Find("WaterTank").GetComponent<WaterLevel>();
    }
    void Update()
    {
        if (!init)
        {
            InitializeButtonControls();
        }
    }

    void InitializeButtonControls()
    {
        buttonHandler = GameObject.Find("ButtonHandler");
        Debug.Log(buttonHandler.GetComponent<ButtonEventDispatcher>().GetEvent());
        button = buttonHandler.GetComponent<ButtonEventDispatcher>().GetEvent();
        if(button != null){
            button.AddListener(OnButtonPush);
            init = true;
        }
    }

    void OnButtonPush(int index, float value)

    {
        StartParticles(index,value);
    }

    void StartParticles(int index,float buttonStrength)
    {
        ParticleSystem particle = particleSystems[index];
        var emission = particle.emission;
        emission.rateOverTime = buttonStrength*10.0f;
        // Debug.Log("Start Bubbles");
        particle.Play();

        float waterLevel = wl.GetWaterLevel(); //here: get water level
        var main = particle.main;
        main.startLifetime = new ParticleSystem.MinMaxCurve(waterLevel *2.0f, waterLevel * 3.0f);
    }
}
