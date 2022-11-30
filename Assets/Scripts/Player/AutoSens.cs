using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AutoSens : MonoBehaviour
{
  CinemachineVirtualCamera vcam;
  private void Start() {
    vcam = GetComponent<CinemachineVirtualCamera>();
    vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = SensitivityAdjustment.xSens;
    vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = SensitivityAdjustment.ySens;
  }
  private void Update() {
    if (SensitivityAdjustment.sensUpdate) {
      vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = SensitivityAdjustment.xSens;
      vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = SensitivityAdjustment.ySens;
    }
  }

}
