using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
  [SerializeField] private float timeStart = 0;
  [SerializeField] private Text textBox;

  void Start()
  {
    textBox.text = timeStart.ToString("F2");
  }

  void Update()
  {
    timeStart += Time.deltaTime;
    textBox.text = timeStart.ToString("F2");
  }
}
