using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class logicGates : MonoBehaviour
{
    public XRBaseInteractable bulbIn1Interactable;
    public XRBaseInteractable bulbIn2Interactable;
    public Light bulbIn1Light;
    public Light bulbIn2Light;
    public Light bulbOutLight;

    public enum GateType { OR, AND, NAND, XOR }
    public GateType currentGateType;

    private bool bulbIn1State = false;
    private bool bulbIn2State = false;

    private void Start()
    {
        bulbIn1Interactable.selectEntered.AddListener((ctx) => ToggleBulb1());
        bulbIn2Interactable.selectEntered.AddListener((ctx) => ToggleBulb2());

        UpdateOutput(); 
    }

    // toggle bulb 1
    private void ToggleBulb1()
    {
        bulbIn1State = !bulbIn1State;
        bulbIn1Light.enabled = bulbIn1State;
        UpdateOutput();
    }

    // toggle bulb 2
    private void ToggleBulb2()
    {
        bulbIn2State = !bulbIn2State;
        bulbIn2Light.enabled = bulbIn2State;
        UpdateOutput();
    }

    // change the gate type
    public void ChangeGateType(GateType newGateType)
    {
        currentGateType = newGateType;  // update the gate type
        UpdateOutput();  
    }

    // update the output light based on gate logic
    private void UpdateOutput()
    {
        bool outputState = false;

        switch (currentGateType)
        {
            case GateType.OR:
                outputState = bulbIn1State || bulbIn2State;
                break;
            case GateType.AND:
                outputState = bulbIn1State && bulbIn2State;
                break;
            case GateType.NAND:
                outputState = !(bulbIn1State && bulbIn2State);
                break;
            case GateType.XOR:
                outputState = bulbIn1State ^ bulbIn2State;
                break;
        }

        bulbOutLight.enabled = outputState; 
    }
}
