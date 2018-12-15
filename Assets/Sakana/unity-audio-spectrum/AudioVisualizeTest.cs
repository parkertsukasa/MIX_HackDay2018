using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizeTest : MonoBehaviour {

    public GameObject Audioplayer;
    public GameObject obj;
    public Material mat;

    private AudioSpectrum _as;
    private List<GameObject> _objs = new List<GameObject>();


    private int _num;
    float _width = 15.0f;
    float _start;
    float _step;


    void Start () {
        _as = Audioplayer.GetComponent<AudioSpectrum>();
        _num = _as.MeanLevels.Length;

        _start = -1.0f * _width / 2.0f;
        _step = _width / _num;




        //for (int i = 0; i < _num; i++) {
        //    _objs.Add(Instantiate(obj));
        //    _objs[i].transform.position = new Vector3(_start + _step*i, 0.0f, 0.0f);
        //    _objs[i].transform.rotation = Quaternion.identity;
        //}
	}
	
	void Update () {
        for (int i = 0; i < _num; i++) {
            mat.SetFloatArray("_vol", _as.MeanLevels);
            //_objs.Add(Instantiate(obj));
            //_objs[i].transform.localScale = new Vector3(_start + _step * i, _as.MeanLevels[i] * 10.0f, 0.0f);
            //_objs[i].transform.position = new Vector3(_start + _step * i, 0.0f, 0.0f);
            //_objs[i].transform.rotation = Quaternion.identity;
        }
        Debug.Log(_as.MeanLevels[0]);
    }
}
