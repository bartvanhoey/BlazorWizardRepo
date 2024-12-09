using Microsoft.AspNetCore.Components;

namespace BlazorWizard.Components.Wizard
{
    
    public partial class WizardStep
    {
        [CascadingParameter] protected internal Wizard? Parent { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string StepTitle { get; set; } = "";
        [Parameter] public string TextPreviousButton { get; set; } = "Previous";
        [Parameter] public string TextNextButton { get; set; } = "Next";
        [Parameter] public string TextSubmitButton { get; set; } = "Submit";
        [Parameter] public bool ShowSubmitButton { get; set; }
        protected override void OnInitialized()
        {
            if (Parent == null) return;
            Parent.ShowSubmitButton = ShowSubmitButton;
            Parent?.AddStep(this);
        }
    }

    
}