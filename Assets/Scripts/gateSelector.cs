using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class gateSelector : MonoBehaviour
{
    // References to the gates
    public GameObject ORGate;
    public GameObject ANDGate;
    public GameObject NANDGate;
    public GameObject XORGate;

    // Materials for gate visuals
    public Material defaultMaterial;
    public Material selectedMaterial;

    // Lights for input and output
    public Light bulbIn1Light;
    public Light bulbIn2Light;
    public Light bulbOutLight;

    // Interactables for the input bulbs
    public XRBaseInteractable bulbIn1Interactable;
    public XRBaseInteractable bulbIn2Interactable;

    // Current input states
    private bool bulbIn1State = false;
    private bool bulbIn2State = false;

    // Enum for gate types
    public enum GateType { OR, AND, NAND, XOR }
    public GateType currentGateType;

    // Renderer components for the gates
    private Renderer orGateRenderer;
    private Renderer andGateRenderer;
    private Renderer nandGateRenderer;
    private Renderer xorGateRenderer;

    private void Start()
    {
        // Get the Renderer components for each gate
        orGateRenderer = ORGate.GetComponent<Renderer>();
        andGateRenderer = ANDGate.GetComponent<Renderer>();
        nandGateRenderer = NANDGate.GetComponent<Renderer>();
        xorGateRenderer = XORGate.GetComponent<Renderer>();

        // Initialize inputs and events
        bulbIn1Interactable.selectEntered.AddListener((ctx) => ToggleBulb1());
        bulbIn2Interactable.selectEntered.AddListener((ctx) => ToggleBulb2());

        // Set all gates to their default material initially
        ResetAllGates();
    }

    // Method to handle selection of OR gate
    public void SelectORGate()
    {
        currentGateType = GateType.OR;
        HighlightSelectedGate(orGateRenderer);
        UpdateOutput();
    }

    // Method to handle selection of AND gate
    public void SelectANDGate()
    {
        currentGateType = GateType.AND;
        HighlightSelectedGate(andGateRenderer);
        UpdateOutput();
    }

    // Method to handle selection of NAND gate
    public void SelectNANDGate()
    {
        currentGateType = GateType.NAND;
        HighlightSelectedGate(nandGateRenderer);
        UpdateOutput();
    }

    // Method to handle selection of XOR gate
    public void SelectXORGate()
    {
        currentGateType = GateType.XOR;
        HighlightSelectedGate(xorGateRenderer);
        UpdateOutput();
    }

    // Method to reset all gates to default material
    private void ResetAllGates()
    {
        orGateRenderer.material = defaultMaterial;
        andGateRenderer.material = defaultMaterial;
        nandGateRenderer.material = defaultMaterial;
        xorGateRenderer.material = defaultMaterial;
    }

    // Method to highlight the selected gate
    private void HighlightSelectedGate(Renderer selectedGateRenderer)
    {
        ResetAllGates();  // Reset others to default
        selectedGateRenderer.material = selectedMaterial;  // Highlight the selected one
    }

    // Method to toggle bulb 1 state
    private void ToggleBulb1()
    {
        bulbIn1State = !bulbIn1State;
        bulbIn1Light.enabled = bulbIn1State;  // Toggle visual state of bulb 1
        UpdateOutput();  // Update the output based on new input state
    }

    // Method to toggle bulb 2 state
    private void ToggleBulb2()
    {
        bulbIn2State = !bulbIn2State;
        bulbIn2Light.enabled = bulbIn2State;  // Toggle visual state of bulb 2
        UpdateOutput();  // Update the output based on new input state
    }

    // Method to calculate and update the output state based on the selected gate type
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

        // Update the output light based on the calculated output state
        bulbOutLight.enabled = outputState;
    }
}
