using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostEffectController : MonoBehaviour {

    /*
     0. Edge
     1. Invert
         */

    public Material[] _MatArray;
    private int _currentId = 0;

    [SerializeField]
    private Material _mat;

    #region Shader resouce
    //private Vector2 blur_vec;
    //private int currentId = 0;
    //private RenderTexture _FrameBuffer;
    //private int FrameCount = 0;
    [SerializeField]
    private float _distortion = 3.0f;
    private float _distortion2 = 5.0f;
    private float _rollSpeed = 0.1f;

    private float _DiffX = -0.04f;
    private float _DiffY = 0.03f;
    private int[] index = new int[] { 2, 4, 6, 8};
    float _sliceNum = 10;
    #endregion

    [SerializeField]
    private GameObject camera;
    private PostProcessingBehaviour behaviour;


    void Start () {
        _mat = _MatArray[_currentId];
        behaviour = GetComponent<PostProcessingBehaviour>();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1)) {
            _mat = _MatArray[0];
            behaviour.profile.bloom.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.F2)) {
            _mat = _MatArray[1];
            behaviour.profile.bloom.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.F3)) {
            _mat = _MatArray[2];
            //behaviour.profile.bloom.enabled = false;
        } else if (Input.GetKeyDown(KeyCode.F4)) {
            _mat = _MatArray[3];
            behaviour.profile.bloom.enabled = true;

            if(Time.frameCount % 30 == 0) {
                _sliceNum = Random.Range(10, 20);
            }

            _mat.SetFloat("_sliceNum", _sliceNum);
        } else if (Input.GetKeyDown(KeyCode.F5)) {
            _mat = _MatArray[4];
            behaviour.profile.bloom.enabled = true;
           
            
            _DiffX = Random.RandomRange(-0.045f, 0.045f);
            _DiffY = Random.RandomRange(-0.045f, 0.045f);
            

            _mat.SetFloat("_DiffX", _DiffX);
            _mat.SetFloat("_DiffY", _DiffY);
        } else if (Input.GetKeyDown(KeyCode.F6)) {
            _mat = _MatArray[5];
            behaviour.profile.bloom.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.F7)) {
            _mat = _MatArray[6];
            behaviour.profile.bloom.enabled = true;
            _mat.SetFloat("_distortion", _distortion);
            _mat.SetFloat("_distortion2", _distortion2);
            _mat.SetFloat("_rollSpeed", _rollSpeed);
        } else if (Input.GetKeyDown(KeyCode.F8)) {
            _mat = _MatArray[7];
            behaviour.profile.bloom.enabled = true;
            _mat.SetInt("_BlockNum", index[Random.Range(0, 4)]);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture dest)
    {

        //Graphics.Blit(source, _FrameBuffer);
        //_mat.SetTexture("_Buffer", _FrameBuffer);

        Graphics.Blit(source, dest, _mat);
   
    }
}
