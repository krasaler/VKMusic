using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VKMusic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VKAuthorize vkAuthorize;
        private VKAudioAPI vkAudio;
        private List<Audio> data;
        private int index;
        private string user_id;
        public MainWindow()
        {
            InitializeComponent();
            vkAuthorize = new VKAuthorize("4318298", "audio");
            vkAuthorize.EndRequestEvent += vkAuthorize_EndRequestEvent;
            vkAuthorize.Authorized();
        }

        void vkAuthorize_EndRequestEvent(string AccessToken, string user_id)
        {
            vkAudio = new VKAudioAPI(AccessToken, user_id);
            data = vkAudio.getAudioAll(user_id);
            index = 0;
            label1.Content = data[index].artist;
            label2.Content = data[index].title;
            mediaElement.Source = new Uri(data[index].url);
            mediaElement.UnloadedBehavior = MediaState.Play;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.user_id = user_id;
            if (index == data.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }

            label1.Content = data[index].artist;
            label2.Content = data[index].title;
            mediaElement.Source = new Uri(data[index].url);
            mediaElement.UnloadedBehavior = MediaState.Play;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (index == 0)
            {
                index = data.Count - 1;
            }
            else
            {
                index--;
            }

            label1.Content = data[index].artist;
            label2.Content = data[index].title;
            mediaElement.Source = new Uri(data[index].url);
            mediaElement.UnloadedBehavior = MediaState.Play;
        }

        private void mediaElement_BufferingEnded(object sender, RoutedEventArgs e)
        {
          /*  if (index == data.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }

            label1.Content = data[index].artist;
            label2.Content = data[index].title;
            mediaElement.Source = new Uri(data[index].url);
            mediaElement.UnloadedBehavior = MediaState.Play;*/
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            data = vkAudio.getAudioRecomend(user_id);
            index = 0;
            label1.Content = data[index].artist;
            label2.Content = data[index].title;
            mediaElement.Source = new Uri(data[index].url);
            mediaElement.UnloadedBehavior = MediaState.Play;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            data = vkAudio.getAudioAll(user_id);
            index = 0;
            label1.Content = data[index].artist;
            label2.Content = data[index].title;
            mediaElement.Source = new Uri(data[index].url);
            mediaElement.UnloadedBehavior = MediaState.Play;
        }
    }
}
