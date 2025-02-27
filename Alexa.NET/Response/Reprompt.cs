﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Response
{
    public class Reprompt
    {
        public Reprompt()
        {
        }

        public Reprompt(string text)
        {
            OutputSpeech = new PlainTextOutputSpeech {Text = text};
        }

        public Reprompt(Ssml.Speech speech)
        {
            OutputSpeech = new SsmlOutputSpeech {Ssml = speech.ToXml()};
        }

        public static implicit operator Reprompt(string text) => new Reprompt(text);
        public static implicit operator Reprompt(Ssml.Speech speech) => new Reprompt(speech);

        [JsonProperty("outputSpeech", NullValueHandling=NullValueHandling.Ignore)]
        public IOutputSpeech OutputSpeech { get; set; }

        [JsonProperty("directives", NullValueHandling = NullValueHandling.Ignore)]
        public IList<IDirective> Directives { get; set; } = new List<IDirective>();

        public bool ShouldSerializeDirectives()
        {
            return Directives.Count > 0;
        }
    }
}