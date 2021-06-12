using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoChat.OpenTok.Service;
using Xamarin.Forms;

namespace VideoChat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!CrossOpenTok.Current.TryStartSession())
            {
                return;
            }
            Navigation.PushModalAsync(new ChatRoomPage());
        }
    }
}
