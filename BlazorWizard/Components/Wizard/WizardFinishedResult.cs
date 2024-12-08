namespace BlazorWizard.Components.Wizard;

public class WizardFinishedResult(bool isFinished)
{
    public WizardFinishedResult() : this(true)
    {
    }

    public bool IsFinished { get; set; } = isFinished;
    public bool IsNotFinished  => !IsFinished;
}