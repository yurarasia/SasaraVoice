using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace SasaraVoice
{
    /// <summary>
    /// windowsの音声認識のラッパー
    /// </summary>
    public class Recognizer : IDisposable
    {
        private SpeechRecognitionEngine _engine;

        public event Action<RecognitionResult> Recognized;
        public event Action<RecognitionResult> Hypothesized;

        public Recognizer()
        {
            _engine = new SpeechRecognitionEngine();
            _engine.SpeechRecognized += (s, e) => Recognized?.Invoke(e.Result);
            _engine.SpeechHypothesized += (s, e) => Hypothesized?.Invoke(e.Result);
            _engine.LoadGrammar(new DictationGrammar());
            _engine.SetInputToDefaultAudioDevice();
            _engine.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void Dispose()
        {
            _engine.Dispose();
        }
    }
}
