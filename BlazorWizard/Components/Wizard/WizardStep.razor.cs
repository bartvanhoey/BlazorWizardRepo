using Microsoft.AspNetCore.Components;

namespace BlazorWizard.Components.Wizard
{
    
    public partial class WizardStep
    {
        [CascadingParameter] protected internal Components.Wizard.Wizard? Parent { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public string Title { get; set; } = "";
        [Parameter] public bool ShowSubmitButton { get; set; }
        protected override void OnInitialized()
        {
            if (Parent == null) return;
            Parent.ShowSubmitButton = ShowSubmitButton;
            Parent?.AddStep(this);
        }
    }

    
}