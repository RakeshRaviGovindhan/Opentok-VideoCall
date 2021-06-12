using System;
using System.IO;
using System.Runtime.CompilerServices;
using VideoChat.OpenTok.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoomPage : ContentPage
    {
        private bool _isRendererSet;
        public ChatRoomPage()
        {
            InitializeComponent();
            CrossOpenTok.Current.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(string message)
        {
            DisplayAlert("Random message received", message, "OK");
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Renderer")
            {
                _isRendererSet = !_isRendererSet;
                if (!_isRendererSet)
                {
                    OnEndCall(this, EventArgs.Empty);
                }
            }
        }
        private void OnEndCall(object sender, EventArgs e)
        {
            CrossOpenTok.Current.EndSession();
            CrossOpenTok.Current.MessageReceived -= OnMessageReceived;
            Navigation.PopModalAsync();
        }

        private void OnMessage(object sender, EventArgs e)
        {
            CrossOpenTok.Current.SendMessageAsync($"Path.GetRandomFileName: {Path.GetRandomFileName()}");
        }

        private void OnSwapCamera(object sender, EventArgs e)
        {
            CrossOpenTok.Current.CycleCamera();
        }

        private void OnShareScreen(object sender, EventArgs e)
        {
            CrossOpenTok.Current.PublisherVideoType = CrossOpenTok.Current.PublisherVideoType == OpenTokPublisherVideoType.Camera
                ? OpenTokPublisherVideoType.Screen
                : OpenTokPublisherVideoType.Camera;
        }
    }
}