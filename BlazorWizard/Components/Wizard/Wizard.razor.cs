using Microsoft.AspNetCore.Components;
using static System.ArgumentNullException;

namespace BlazorWizard.Components.Wizard
{
    public partial class Wizard
    {
        private List<WizardStep> _steps = [];
        [Parameter] public EventCallback<WizardFinishedResult> OnWizardFinished { get; set; }
        [Parameter] public bool ShowTitle { get; set; } = true;
        [Parameter] public bool ShowNextButton { get; set; }
        [Parameter] public bool ShowPreviousButtonAtFirstStep { get; set; }
        [Parameter] public string? Id { get; set; }
        [Parameter] public string? CssPreviousButton { get; set; } = "btn btn-primary align-self-start";
        [Parameter] public string? CssNextButton { get; set; } = "btn btn-primary align-self-start ms-1";
        [Parameter] public string? CssTitle { get; set; } = "h3 my-2";
        [Parameter] public string? CssWizard { get; set; } = "container d-flex flex-column justify-content-center";
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public WizardStep? ActiveStep { get; set; }
        [Parameter] public int IndexActiveStep { get; set; }
        [Parameter] public bool ShowSteps { get; set; }
        private bool IsLastStep { get; set; }
        private bool IsFirstStep { get; set; }
        public bool ShowSubmitButton { get; set; }

        private void PreviousButtonClicked()
        {
            if (IndexActiveStep > 0)
                SetActive(_steps[IndexActiveStep - 1]);
        }

        private void NextOrSubmitButtonClicked()
        {
            Console.WriteLine(
                $"ActiveStep: {ActiveStep?.StepTitle}, IndexActiveStep: {IndexActiveStep}, IsLastStep: {IsLastStep}");
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
            IsFirstStep = IndexActiveStep == 0;
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
}