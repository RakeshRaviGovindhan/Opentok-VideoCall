using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VideoChat.OpenTok.Views
{
    public sealed class OpenTokPublisherView : OpenTokView
    {
        public static readonly BindableProperty StreamIdProperty = BindableProperty.Create(nameof(StreamId), typeof(string), typeof(OpenTokPublisherView), null);

        public string StreamId
        {
            get => GetValue(StreamIdProperty) as string;
            set => SetValue(StreamIdProperty, value);
        }
    }
}
