using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class gateSelector : MonoBehaviour
{
    public GameObject ORGate;
    public GameObject ANDGate;
    public GameObject NANDGate;
    public GameObject XORGate;

    public Material defaultMaterial;
    public Material selectedMaterial;

    public Light bulbIn1Light;
    public Light bulbIn2Light;
    public Light bulbOutLight;

    public XRBaseInteractable bulbIn1Interactable;
    public XRBaseInteractable bulbIn2Interactable;

    private bool bulbIn1State = false;
    private bool bulbIn2State = false;
    
    public enum GateType { OR, AND, NAND, XOR }
    public GateType currentGateType;

    private Renderer orGateRenderer;
    private Renderer andGateRenderer;
    private Renderer nandGateRenderer;
    private Renderer xorGateRenderer;

    private void Start()
    {
        orGateRenderer = ORGate.GetComponent<Renderer>();
        andGateRenderer = ANDGate.GetComponent<Renderer>();
        nandGateRenderer = NANDGate.GetComponent<Renderer>();
        xorGateRenderer = XORGate.GetComponent<Renderer>();

        bulbIn1Interactable.selectEntered.AddListener((ctx) => ToggleBulb1());
        bulbIn2Interactable.selectEntered.AddListener((ctx) => ToggleBulb2());

        ResetAllGates();
    }

    public void SelectORGate()
    {
        currentGateType = GateType.OR;
        HighlightSelectedGate(orGateRenderer);
        UpdateOutput();
    }

    public void SelectANDGate()
    {
        currentGateType = GateType.AND;
        HighlightSelectedGate(andGateRenderer);
        UpdateOutput();
    }

    public void SelectNANDGate()
    {
        currentGateType = GateType.NAND;
        HighlightSelectedGate(nandGateRenderer);
        UpdateOutput();
    }

    public void SelectXORGate()
    {
        currentGateType = GateType.XOR;
        HighlightSelectedGate(xorGateRenderer);
        UpdateOutput();
    }

    private void ResetAllGates()
    {
        orGateRenderer.material = defaultMaterial;
        andGateRenderer.material = defaultMaterial;
        nandGateRenderer.material = defaultMaterial;
        xorGateRenderer.material = defaultMaterial;
    }

    private void HighlightSelectedGate(Renderer selectedGateRenderer)
    {
        ResetAllGates();  
        selectedGateRenderer.material = selectedMaterial;  
    }

    // method to toggle bulb 1 state
    private void ToggleBulb1()
    {
        bulbIn1State = !bulbIn1State;
        bulbIn1Light.enabled = bulbIn1State;  // turn on/off bulb 1
        UpdateOutput();
    }

    // method to toggle bulb 2 state
    private void ToggleBulb2()
    {
        bulbIn2State = !bulbIn2State;
        bulbIn2Light.enabled = bulbIn2State;  
        UpdateOutput();  
    }

    // method to calculate and update the output state based on the selected gate type
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
