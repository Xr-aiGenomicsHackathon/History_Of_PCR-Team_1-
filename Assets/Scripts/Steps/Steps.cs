using System;
using UnityEngine;
using UnityEngine.Events;

namespace Team.One
{
    [RequireComponent(typeof(AudioSource))]
    public class Steps : MonoBehaviour
    {
        public static Steps Instance { get; private set; }

        [SerializeField] private Step[] steps;
        private int currentStepIndex = 0;
        private AudioSource stepSource;
        private Step currentStep;


        private void Awake()
        {
            Instance = Instance ?? this;
        }

        private void Start()
        {
            stepSource = GetComponent<AudioSource>();

            PlayNextStep();
        }
        public void PlayNextStep()
        {
            currentStep?.OnStepCompleted.Invoke();
            stepSource.Stop(); // Stop any currently playing audio
            if (currentStepIndex < steps.Length)
            {
                currentStep = steps[currentStepIndex];
                currentStep.OnStepStarted?.Invoke();
                stepSource.clip = currentStep.StepClip;
                stepSource.Play();
                Debug.Log(currentStep.Subtitle); // Display subtitle in console
                currentStepIndex++;
            }
            else
            {
                Debug.Log("All steps completed.");
            }
        }
    }

    [System.Serializable]
    public class Step
    {
        public AudioClip StepClip;
        [TextArea(3,3)]
        public string Subtitle;
        public UnityEvent OnStepStarted;
        public UnityEvent OnStepCompleted;
    }
}