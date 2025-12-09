using UnityEngine;
using UnityEngine.UI;  // Make sure to include this for UI elements

public class InputFieldToSlider : MonoBehaviour
{
    public InputField inputField;  // Reference to the Input Field
    public Slider slider;         // Reference to the Slider
    public Text valueText;        // Optional: Reference to display the value

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the slider and input field are initialized
        if (inputField != null && slider != null)
        {
            // Set up listener to handle input changes
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
            
            // Initialize slider value based on the input field value at the start
            SetSliderValueFromInputField();
        }
    }

    // This function will be called when the input field's value changes
    private void OnInputFieldValueChanged(string input)
    {
        SetSliderValueFromInputField();
    }

    // This method updates the slider based on the input field value
    private void SetSliderValueFromInputField()
    {
        float inputValue;
        
        // Try to parse the input field value to a float
        if (float.TryParse(inputField.text, out inputValue))
        {
            // Ensure the slider value is within its valid range (0 to 1)
            inputValue = Mathf.Clamp(inputValue, slider.minValue, slider.maxValue);
            
            // Set the slider's value
            slider.value = inputValue;

            // Optionally update the value text
            if (valueText != null)
            {
                valueText.text = inputValue.ToString("F2"); // Show 2 decimal points
            }
        }
    }
}
