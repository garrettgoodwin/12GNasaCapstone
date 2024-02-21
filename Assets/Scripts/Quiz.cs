using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    public Button[] answerButtons;
    public Text coinText;

    private List<int> usedQuestions = new List<int>();
    private List<int> usedOptions = new List<int>();
    private int currentQuestionIndex = 0;
    private int coins = 0;

    // Define the updated questions and their corresponding correct answers
    private List<string> questions = new List<string>
    {
        "What is Psyche?",
        "When was the Psyche mission selected?",
        "What kind of mission is Psyche?",
        "What might visiting the Psyche asteroid teach us?",
        "Why can't we visit Earth's core?",
        "When will the Psyche spacecraft stay in orbit around the asteroid?",
        "How much does the Psyche mission cost?",
        "What is one of the Psyche mission science goals?",
        "Who is leading the Psyche mission?",
        "How can you learn more about the Psyche mission?",
        "When was the Psyche asteroid discovered?",
        "Where is the Psyche asteroid located?",
        "What is the Psyche asteroid likely made of?",
        "How do we know what the Psyche asteroid is made of?",
        "When did we find out what Psyche is made of?",
        "What do scientists think the Psyche asteroid is?",
        "How long is a day on Psyche?",
        "How long is a year on Psyche?",
        "On average, how far is the Psyche asteroid from the Sun?",
        "How much does the Psyche asteroid weigh?",
        "How dense is the Psyche asteroid?",
        "Does the Psyche asteroid have gravity?",
        "How big is the Psyche asteroid?",
        "From ground-based observations, what does the Psyche asteroid look like?",
        "How big is the Psyche spacecraft?",
        "What launch vehicle will the Psyche mission use?",
        "How will the Psyche spacecraft get to Psyche?",
        "What kind of propellant will the Psyche spacecraft use?",
        "How far will the Psyche spacecraft travel?",
        "How will the spacecraft orbit Psyche?",
        "What are the four stages of science operations around Psyche?",
        "How many instruments are on the Psyche spacecraft?",
        "How much raw data does the Psyche mission expect to deliver?",
        "What format will the Psyche mission data be received in?",
        "What does the Psyche Multispectral Imager do?",
        "Where is the team responsible for the Psyche Multispectral Imager based?",
        "What does the Psyche Gamma Ray and Neutron Spectrometer detect?",
        "Where is the team responsible for the Psyche Magnetometer based?",
        "What does the Psyche Gravity Science Investigation measure?",
        "What is the purpose of Deep Space Optical Communication (DSOC)?",
        "How big is the Psyche spacecraft bus (body)?",
        "Who provides the launch vehicle for the Psyche mission?",
        "How long will the Psyche mission travel from launch to the end of the primary mission?",
        "What institution is responsible for the DSOC technology demonstration?",
        "Who is the Principal Investigator (PI) of the Psyche mission?",
        "What does the PI oversee in the Psyche mission?",
        "Who are the Psyche science partners?",
        "Where can you find the full Psyche team list?"
    };

    private List<List<string>> options = new List<List<string>>
    {
        new List<string> { "A planet", "An asteroid", "A star", "A moon" },
        new List<string> { "December 25, 2016", "January 4, 2017", "March 10, 2018", "February 2, 2017" },
        new List<string> { "Human mission", "Space telescope mission", "Robotic orbiter mission", "Mars mission" },
        new List<string> { "Weather patterns", "Composition of gas giants", "Information about planetary formation", "History of comets" },
        new List<string> { "Lack of interest", "Technological limitations", "Prohibitive cost", "Environmental concerns" },
        new List<string> { "At launch", "After reaching Jupiter", "After completing the mission", "Never" },
        new List<string> { "$500 million", "$1 billion", "$850 million", "$2 billion" },
        new List<string> { "Study of exoplanets", "Exploration of gas giants", "Understanding iron cores", "Search for extraterrestrial life" },
        new List<string> { "SpaceX", "NASA’s Ames Research Center", "Arizona State University", "European Space Agency" },
        new List<string> { "Only through newspapers", "Visit psyche.asu.edu", "Watch TV documentaries", " All of the above" },
        new List<string> { "1750", "1852", "1901", "2000" },
        new List<string> { "Between Earth and Venus", "Beyond Pluto", "Main asteroid belt", "Near the Sun" },
        new List<string> { "Only metal", "Only rock", "Mixture of rock and metal", "Ice and gas" },
        new List<string> { "By tasting it", "Using radar albedo and thermal inertia", "Guessing", "By smelling it" },
        new List<string> { "2005", "2010", "2015", "2020" },
        new List<string> { "A piece of the Moon", "Remnants of a comet", "Metal from the core of a planetesimal", "A space station" },
        new List<string> { "12 hours", "24 hours", "4 hours and 12 minutes", "1 hour" },
        new List<string> { "1 Earth year", "10 Earth years", "5 Earth years", "2 Earth years" },
        new List<string> { "50 million miles", "100 million miles", "280 million miles", "500 million miles" },
        new List<string> { "1 sextillion kg", "10 sextillion kg", "27 sextillion kg", "50 sextillion kg" },
        new List<string> { "1,000 kg/m3", "2,500 kg/m3", "3,4004,100 kg/m3", "5,000 kg/m3" },
        new List<string> { "No", "Yes, similar to Earth", "Yes, but much less than Earth", "Yes, more than Earth" },
        new List<string> { "100 x 80 x 60 kilometers", "200 x 150 x 120 kilometers", "279 x 232 x 189 kilometers", "300 x 250 x 200 kilometers" },
        new List<string> { "Smooth and round", "Pixelated black and white image", "Red and dusty", "Covered in ice" },
        new List<string> { "10 meters long", "20 meters long", "~81 feet long", "~100 feet long" },
        new List<string> { "NASA’s SLS", "SpaceX Falcon Heavy", "Blue Origin New Glenn", "Russian Soyuz" },
        new List<string> { "Rocket boosters", "Solar electric propulsion", "Nuclear propulsion", "Chemical thrusters" },
        new List<string> { "Hydrogen", "Kerosene", "Xenon", "Oxygen" },
        new List<string> { "1 billion kilometers", "2 billion kilometers", "3 billion kilometers", "4 billion kilometers" },
        new List<string> { "Fixed orbit", "Circular orbit", "From four staging orbits" },
        new List<string> { "A, B1/B2, C, D", "Alpha, Beta, Gamma, Delta", "First, Second, Third, Fourth", "One, Two, Three, Four" },
        new List<string> { "Two", "Three", "Four", "Five" },
        new List<string> { "500 GB", "1 TB", "620 GB", "800 GB" },
        new List<string> { "JPEG", "PDF", "NASA PDS4 formats", "Excel" },
        new List<string> { "Measures temperature", "Provides high-resolution images", "Detects magnetic fields", "Studies atmospheric composition" },
        new List<string> { "MIT", "OSU", "Arizona State University", "SpaceX" },
        new List<string> { "Temperature changes", "Elemental composition", "Atmospheric pressure", "Surface topography" },
        new List<string> { "APL at Johns Hopkins University", "MIT and DTU", "SpaceX", "Lawrence Livermore National Laboratory" },
        new List<string> { "Atmospheric density", "Gravity field", "Solar radiation", "Magnetic fields" },
        new List<string> { "Capture images of the asteroid", "Test new laser communication technology", "Measure atmospheric composition", "Transmit radio signals" },
        new List<string> { "5 meters long", "~10 feet long by almost 8 feet wide", "15 meters long", "~20 feet long by 15 feet wide" },
        new List<string> { "Blue Origin", "SpaceX", "NASA’s Ames Research Center", "Roscosmos" },
        new List<string> { "~2 billion miles", "~3 billion miles", "~3.3 billion miles", "~4 billion miles" },
        new List<string> { "APL at Johns Hopkins University", "SpaceX", "Jet Propulsion Laboratory", "MIT" },
        new List<string> { "Elon Musk", "ASU President", "NASA Administrator", "Lindy Elkins-Tanton" },
        new List<string> { "Only financial matters", "Scientific integrity and execution", "Social media promotion", "Rocket launch procedures" },
        new List<string> { "Only ASU", "Multiple institutions", "Only SpaceX", "International Space Station (ISS)" },
        new List<string> { "NASA’s official website", "Psyche Mission's Twitter account", "https://psyche.asu.edu/mission/the-team/full-psyche-team/", "Your school's library" },
    };

    private int[] correctAnswers = {
        1, 3, 2, 2, 1, 2, 2, 3, 2, 2, 1, 3, 2, 1, 2, 3, 2, 3, 2, 2, 3, 2, 3, 2, 1, 2, 1, 1, 2, 2, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 3, 3, 2, 3, 2, 2, 3, 2
    };

    void Start()
    {
        ShuffleQuestions();
        ShowQuestion();
    }

    void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            int temp = Random.Range(i, questions.Count);
            Swap(ref questions, i, temp);
            Swap(ref options, i, temp);
            // Swap(ref correctAnswers, i, temp);
        }
    }

    void Swap<T>(ref List<T> list, int a, int b)
    {
        T temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            questionText.text = questions[currentQuestionIndex];

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = options[currentQuestionIndex][i];
                // GameObject.Find("B1").GetComponentInChildren<Text>().text = options[currentQuestionIndex][i];

                string buttonName = i < buttonNames.Length ? buttonNames[i] : "B" + i;
                answerButtons[i].name = buttonName;
                Debug.Log("Button Name: " + answerButtons[i].name);
                Debug.Log("Assigned Text: " + options[currentQuestionIndex][i]);
                Debug.Log("Question Text: " + questionText.text);


                int currentIndex = currentQuestionIndex;
                int buttonIndex = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => CheckAnswer(currentIndex, buttonIndex));
            }
        }
        else
        {
            // Quiz is complete
            Debug.Log("Quiz Complete! Total Coins: " + coins);
        }
    }

    void CheckAnswer(int questionIndex, int selectedOption)
    {
        if (selectedOption == correctAnswers[questionIndex])
        {
            coins += 1000;
        }

        currentQuestionIndex++;
        ShowQuestion();
    }
}
