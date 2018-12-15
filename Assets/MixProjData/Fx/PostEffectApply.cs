using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectApply : MonoBehaviour
{
    #region c# resouce 
    public Material[] _MatArraay;
    
    [SerializeField]
    private Material _mat;
    public Material mat
    {
        get { return _mat; }
        set { _mat = value; }
    }

    [HideInInspector]
    public GameObject _MidiControl;
    //private MidiManager _MidiManager;
    #endregion


    #region Shader resouce
    private Vector2 blur_vec;
    private int currentId = 0;
    private RenderTexture _FrameBuffer;
    private int FrameCount = 0;
    #endregion


    #region c# func

    private void Awake()
    {
       // _MidiManager = _MidiControl.GetComponent<MidiManager>();
    }

    void Start()
    {
        mat = _MatArraay[currentId];
        _FrameBuffer = new RenderTexture(Screen.width, Screen.height, 0);
    }
    
    /*
     post effect
     0: Default
     1: BlackWhiteFx
     2:
     3:
     4:
     5: GlitchFx
     6:
     7: 
     */
    

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            currentId = (currentId + 1) % _MatArraay.Length;
            mat = _MatArraay[currentId];
        }
        
        if (currentId == 1)
        {
                
        }else if (currentId == 5)
        {
            Debug.Log("GlitchFx"); 
            //mat.SetFloat("_Threshold", 0.5f -  _MidiManager.knobValue[0] * 0.5f);
            //mat.SetFloat("_DiffX", _MidiManager.knobValue[1] *0.01f + 0.002f);
            //mat.SetFloat("_DiffY", _MidiManager.knobValue[2]*0.01f + 0.003f);
            ////Coarseness
            //mat.SetFloat("_BlockSizeX", _MidiManager.knobValue[3] * 30f); 
            //mat.SetFloat("_BlockSizeY", _MidiManager.knobValue[4] * 30f);
        }
        
        blur_vec = new Vector2(Random.RandomRange(0.0f, 0.01f), Random.RandomRange(0.0f, 0.01f));
        mat.SetVector("_blur_vec", blur_vec);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture dest)
    {
        
        Graphics.Blit(source, _FrameBuffer);
        mat.SetTexture("_Buffer", _FrameBuffer);

        Graphics.Blit(source, dest, mat);

        FrameCount++;
        if(FrameCount % 4 == 0) _FrameBuffer = source;
    }
    
    #endregion
   
}