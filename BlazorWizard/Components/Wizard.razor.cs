using Microsoft.AspNetCore.Components;
using static System.ArgumentNullException;

namespace BlazorWizard.Components
{
    public partial class Wizard
    {
        private List<WizardStep> _steps = [];

        [Parameter] public EventCallback<WizardFinishedResult> OnWizardFinished { get; set; }
        [Parameter] public bool ShowNextButton { get; set; }
        [Parameter] public string? Id { get; set; }

        [Parameter] public string? PreviousButton { get; set; } = "Previous";

        [Parameter] public string? NextButton { get; set; } = "Next";

        [Parameter] public string? SubmitButton { get; set; } = "Submit";
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public WizardStep? ActiveStep { get; set; }
        [Parameter] public int IndexActiveStep { get; set; }
        private bool IsLastStep { get; set; }

        private void PreviousButtonClicked()
        {
            if (IndexActiveStep > 0)
                SetActive(_steps[IndexActiveStep - 1]);
        }

        private void NextOrSubmitButtonClicked()
        {
            Console.WriteLine(
                $"ActiveStep: {ActiveStep?.Title}, IndexActiveStep: {IndexActiveStep}, IsLastStep: {IsLastStep}");
            if (IndexActiveStep < _steps.Count - 1)
            {
                SetActive(_steps[_steps.IndexOf(ActiveStep ?? throw new InvalidOperationException()) + 1]);
                ShowNextButton = false;
            }
            else if (IsLastStep)
            {
                OnWizardFinished.InvokeAsync(new WizardFinishedResult());
            }
        }


        private void SetActive(WizardStep step)
        {
            ActiveStep = step ?? throw new ArgumentNullException(nameof(step));
            IndexActiveStep = StepsIndex(step);
            IsLastStep = IndexActiveStep == _steps.Count - 1;
        }

        public int StepsIndex(WizardStep step) => StepsIndexInternal(step);

        private int StepsIndexInternal(WizardStep step)
        {
            ThrowIfNull(step);
            return _steps.IndexOf(step);
        }

        protected internal void AddStep(WizardStep step) => _steps.Add(step);

        protected override void OnAfterRender(bool firstRender)
        {
            if (!firstRender) return;
            SetActive(_steps[0]);
            StateHasChanged();
        }
    }

    public class WizardFinishedResult(bool isFinished)
    {
        public WizardFinishedResult() : this(true)
        {
        }

        public bool IsFinished { get; set; } = isFinished;
    }
}