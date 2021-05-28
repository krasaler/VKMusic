using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VKMusic
{
    public class VKAudioAPI
    {
        private string accessToken;
        private string appId;
        public VKAudioAPI(string accessToken, string appId)
        {
            this.accessToken = accessToken;
            this.appId = appId;
        }
        public List<Audio> getAudioSearch(string q, int auto_complete = 1, int count = 100)
        {
            string url = "https://api.vk.com/method/audio.search?q=" +
                q + "&auto_complete=" + auto_complete + "&v=5.21&count=" + count + "&access_token=" + accessToken;
            List<Audio> data = new List<Audio>();
            var webRequest = HttpWebRequest.Create(url);
            var webResponce = webRequest.GetResponse();
            Stream stream = webResponce.GetResponseStream();
            JToken token = JsonHelper.ReadFrom(stream);
            JToken items = token["response"]["items"];
            for (int i = 0; i < items.Count(); i++)
            {
                Audio vka = new Audio();
                vka.id = items[i]["id"] == null ? -1 : (int)items[i]["id"]; ;
                vka.owner_id = items[i]["owner_id"] == null ? -1 : (int)items[i]["owner_id"];
                vka.title = items[i]["title"] == null ? "" : (string)items[i]["title"];
                vka.artist = items[i]["artist"] == null ? "" : (string)items[i]["artist"];
                vka.duration = items[i]["duration"] == null ? -1 : (int)items[i]["duration"];
                vka.url = items[i]["url"] == null ? "" : (string)items[i]["url"];
                vka.lyrics_id = items[i]["lyrics_id"] == null ? -1 : (int)items[i]["lyrics_id"];
                vka.genre_id = items[i]["genre_id"] == null ? -1 : (int)items[i]["genre_id"];
                data.Add(vka);
            }
            return data;
        }
        public List<Audio> getAudioAll(string owner_id)
        {
            string url = "https://api.vk.com/method/audio.get?owner_id=" +
                 owner_id + "&need_user=0&v=5.21&access_token=" + accessToken;
            List<Audio> data = new List<Audio>();
            var webRequest = HttpWebRequest.Create(url);
            var webResponce = webRequest.GetResponse();
            Stream stream = webResponce.GetResponseStream();
            JToken token = JsonHelper.ReadFrom(stream);
            JToken items = token["response"]["items"];
            for (int i = 0; i < items.Count(); i++)
            {
                Audio vka = new Audio();
                vka.id = items[i]["id"] == null ? -1 : (int)items[i]["id"]; ;
                vka.owner_id = items[i]["owner_id"] == null ? -1 : (int)items[i]["owner_id"];
                vka.title = items[i]["title"] == null ? "" : (string)items[i]["title"];
                vka.artist = items[i]["artist"] == null ? "" : (string)items[i]["artist"];
                vka.duration = items[i]["duration"] == null ? -1 : (int)items[i]["duration"];
                vka.url = items[i]["url"] == null ? "" : (string)items[i]["url"];
                vka.lyrics_id = items[i]["lyrics_id"] == null ? -1 : (int)items[i]["lyrics_id"];
                vka.genre_id = items[i]["genre_id"] == null ? -1 : (int)items[i]["genre_id"];
                data.Add(vka);
            }
            return data;
        }
        public List<Audio> getAudioPopular(int genre_id, int count = 200)
        {
            string url = "https://api.vk.com/method/audio.getPopular?genre_id=" + genre_id + "&count=" + count +
            "&v=5.21&access_token=" + accessToken;
            List<Audio> data = new List<Audio>();
            var webRequest = HttpWebRequest.Create(url);
            var webResponce = webRequest.GetResponse();
            Stream stream = webResponce.GetResponseStream();
            JToken token = JsonHelper.ReadFrom(stream);
            JToken items = token["response"];
            for (int i = 0; i < items.Count(); i++)
            {
                Audio vka = new Audio();
                vka.id = items[i]["id"] == null ? -1 : (int)items[i]["id"]; ;
                vka.owner_id = items[i]["owner_id"] == null ? -1 : (int)items[i]["owner_id"];
                vka.title = items[i]["title"] == null ? "" : (string)items[i]["title"];
                vka.artist = items[i]["artist"] == null ? "" : (string)items[i]["artist"];
                vka.duration = items[i]["duration"] == null ? -1 : (int)items[i]["duration"];
                vka.url = items[i]["url"] == null ? "" : (string)items[i]["url"];
                vka.lyrics_id = items[i]["lyrics_id"] == null ? -1 : (int)items[i]["lyrics_id"];
                vka.genre_id = items[i]["genre_id"] == null ? -1 : (int)items[i]["genre_id"];
                data.Add(vka);
            }
            return data;
        }
        public List<Audio> getAudioRecomend(string owner_id, int count = 200)
        {
            string url = "https://api.vk.com/method/audio.getRecommendations?user_id=" + owner_id
                 + "&count=" + count + "&v=5.21&access_token=" + accessToken;
            List<Audio> data = new List<Audio>();
            var webRequest = HttpWebRequest.Create(url);
            var webResponce = webRequest.GetResponse();
            Stream stream = webResponce.GetResponseStream();
            JToken token = JsonHelper.ReadFrom(stream);
            JToken items = token["response"]["items"];
            for (int i = 0; i < items.Count(); i++)
            {
                Audio vka = new Audio();
                vka.id = items[i]["id"] == null ? -1 : (int)items[i]["id"]; ;
                vka.owner_id = items[i]["owner_id"] == null ? -1 : (int)items[i]["owner_id"];
                vka.title = items[i]["title"] == null ? "" : (string)items[i]["title"];
                vka.artist = items[i]["artist"] == null ? "" : (string)items[i]["artist"];
                vka.duration = items[i]["duration"] == null ? -1 : (int)items[i]["duration"];
                vka.url = items[i]["url"] == null ? "" : (string)items[i]["url"];
                vka.lyrics_id = items[i]["lyrics_id"] == null ? -1 : (int)items[i]["lyrics_id"];
                vka.genre_id = items[i]["genre_id"] == null ? -1 : (int)items[i]["genre_id"];
                data.Add(vka);
            }
            return data;
        }
        public void AddAudio(int owner_id, int aid)
        {
            /*    return getAudioList("https://api.vk.com/method/audio.add?oid=" +
                    owner_id + "&access_token=" + accessToken + "&aid" + aid);*/
        }
    }
}
