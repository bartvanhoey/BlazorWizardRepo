using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace BlazorWizard.Components
{
    public partial class Wizard
    {
        
        [Parameter] public bool CanGoToNextStep { get; set; }

        private List<WizardStep> _steps = [];
        
        [Parameter]
        public string Id { get; set; }

       
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        
        [Parameter]
        public WizardStep ActiveStep { get; set; }
        
        [Parameter]
        public int ActiveStepIx { get; set; }

        private bool IsLastStep { get; set; }


        private void GoBack()
        {
            if (ActiveStepIx > 0)
                SetActive(_steps[ActiveStepIx - 1]);
        }

        private void GoNext()
        {
            if (ActiveStepIx < _steps.Count - 1)
                SetActive(_steps[_steps.IndexOf(ActiveStep) + 1]);
            CanGoToNextStep = false;
        }


        protected internal void SetActive(WizardStep step)
        {
            ActiveStep = step ?? throw new ArgumentNullException(nameof(step));

            ActiveStepIx = StepsIndex(step);
            if (ActiveStepIx == _steps.Count - 1)
                IsLastStep = true;
            else
                IsLastStep = false;
        }

        public int StepsIndex(WizardStep step) => StepsIndexInternal(step);
        protected int StepsIndexInternal(WizardStep step)
        {
            if (step == null)
                throw new ArgumentNullException(nameof(step));

            return _steps.IndexOf(step);
        }
        protected internal void AddStep(WizardStep step)
        {
            _steps.Add(step);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                SetActive(_steps[0]);
                StateHasChanged();
            }
        }
    }
}